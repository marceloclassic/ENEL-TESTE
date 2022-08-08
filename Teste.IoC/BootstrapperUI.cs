using Microsoft.Extensions.DependencyInjection;
using Teste.Domain;
using Teste.Domain.Interfaces;
using Teste.Domain.Services;

namespace Teste.IoC;
public static class BootstrapperUI
{
    public static void Initialize(IServiceCollection services)
    {
        InitializeTransciente(services);
        InitializeSingleton(services);
    }

    private static void InitializeTransciente(IServiceCollection services)
    {
        services.AddTransient<IWatcherService, WatcherService>();
    }

    private static void InitializeSingleton(IServiceCollection services)
    {
        services.AddSingleton<IHttpService, HttpService>();
    }    

    public static void Form1Delegate(Delegate @delegate, IServiceCollection services)
    {
        services.AddScoped<ICsvService, CsvService>(scope => new(@delegate));
    }
}