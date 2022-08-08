using System.Text;
using Teste.Domain.Interfaces;

namespace Teste.Domain.Services;
public class CsvService : ICsvService
{
    private readonly Delegate? @delegate;
    private readonly object _lock;
    public CsvService(Delegate delegateInstance)
    {
        @delegate = delegateInstance;
        _lock = new();
    }
    public CsvService()
    {
        @delegate = null;
        _lock = new();
    }

    public void ReadColumn(string pathFile, int indexColumn)
    {
        if (@delegate == null)
            throw new Exception("Delegate is mandatory");

        lock (_lock)
        {
            using FileStream fs = new(pathFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using StreamReader sr = new(fs);
            sr.ReadLine(); //Header(A;B)
            while (sr.Peek() >= 0)
            {
                string? linha = sr.ReadLine();
                int value = Convert.ToInt32(linha?.Split(';')[indexColumn]);
                @delegate?.DynamicInvoke(value);
            }
        }
    }

    public void ReadColumn(string pathFile, char letter)
    {
        int index = char.ToUpper(letter) - 64;
        this.ReadColumn(pathFile, (index - 1));
    }

    public void GenerateCsv(List<decimal> values, string filename)
    {
        using var streamWriter = new StreamWriter(filename, false);
        streamWriter.WriteLine("R");
        values.ForEach(value => streamWriter.WriteLine(value.ToString("0.#")));
    }
}