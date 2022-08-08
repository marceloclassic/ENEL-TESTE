using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teste.Domain.Interfaces;
using Teste.Domain.Services;

namespace Teste.IoC;
public static class BootstrapperApi
{
    public static void Initialize(this IServiceCollection services)
    {
        InitializeScoped(services);
    }

    private static void InitializeScoped(IServiceCollection services)
    {
        services.AddScoped<ICalculadoraService, CalculadoraService>();
    }
}