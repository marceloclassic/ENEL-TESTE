using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Teste.Domain.Interfaces;

namespace Teste.UI;
public partial class Form1 : Form
{
    public AddIntoListView? @delegate;
    public delegate void AddIntoListView(int value);
    private readonly object _lock = new();
    private readonly IHttpService _httpService;
    private readonly ICsvService _csvService;
    private readonly IConfiguration _configuration;

    public Form1(IWatcherService watcherService, IConfiguration configuration, IHttpService httpService, ICsvService csvService)
    {
        InitializeComponent();
        _httpService = httpService;
        _csvService = csvService;
        _configuration = configuration;
        @delegate = new(AddIntoListViewMethod);
        watcherService.Configure(_configuration.GetValue<string>("path:monitoramento"), _configuration.GetValue<string>("path:copia"), "*.csv");
    }

    public void AddIntoListViewMethod(int value)
    {
        lock (this._lock)
        {
            listViewNumeros.Items.Add(value.ToString());
        }
    }

    private List<decimal> GetItensFromListView()
    {
        var list = new List<decimal>();
        foreach (ListViewItem item in listViewNumeros.Items)
        {
            list.Add(Convert.ToDecimal(item.Text));
        }
        return list;
    }

    private void ListViewNumeros_DoubleClick(object sender, EventArgs e)
    {
        try
        {
            var list = GetItensFromListView();
            var returnValue = Task.Run(async () => await _httpService.Post<List<decimal>>(_configuration.GetValue<string>("endpoint:api"), list)).Result;
            if (returnValue == null)
                throw new Exception("Occoreu um erro ao recuperar a lista da API");
            else
            {
                string fileName = $"{_configuration.GetValue<string>("path:pathNovoCsv")}\\{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                _csvService.GenerateCsv(returnValue, fileName);

                var dialogResult = MessageBox.Show("Arquivo enviado, deseja abrir o resultado?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("notepad.exe", fileName);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}