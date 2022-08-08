namespace Teste.Domain.Interfaces;
public interface IWatcherService
{
    void Configure(string pathMonitoramento, string pathCopia, string filter);
}