using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Teste.IoC;

namespace Teste.UI;
internal static class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    [STAThread]
    static void Main()
    {
        ServiceProvider = CreateHostBuilder().Build().Services;
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(ServiceProvider.GetRequiredService<Form1>());
    }
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((c, s) =>
            {
                Program.AddJsonFile(s);
                Program.BootstrapperForms(s);
                BootstrapperUI.Initialize(s);
                BootstrapperUI.Form1Delegate((int value) =>
                {
                    Form1? form1 = ServiceProvider?.GetRequiredService<Form1>();
                    form1?.Invoke(form1.@delegate, value);
                }, s);
            });
    }

    private static void AddJsonFile(IServiceCollection services)
    {
        services.AddSingleton<IConfiguration>(new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build());
    }

    private static void BootstrapperForms(IServiceCollection services)
    {
        services.AddSingleton<Form1>();
    }
}