using Teste.Domain.Interfaces;

namespace Teste.Domain.Services;
public class WatcherService : IWatcherService, IDisposable
{
    private FileSystemWatcher? _watcher;
    private readonly ICsvService _svService;
    public WatcherService(ICsvService svService)
    {
        _svService = svService;
    }
    public void Dispose() => _watcher?.Dispose();
    private static void ValidarDiretorios(string pathMonitoramento, string pathCopia)
    {
        if (!Directory.Exists(pathMonitoramento))
            Directory.CreateDirectory(pathMonitoramento);

        if (!Directory.Exists(pathCopia))
            Directory.CreateDirectory(pathCopia);
    }
    private static string CopyFile(FileSystemEventArgs @event, string pathCopia)
    {
        string newPathFile = $@"{pathCopia}\{@event.Name}";
        File.Copy(@event.FullPath, newPathFile, true);
        return newPathFile;
    }

    public void Configure(string pathMonitoramento, string pathCopia, string filter)
    {
        WatcherService.ValidarDiretorios(pathMonitoramento, pathCopia);
        _watcher = new FileSystemWatcher(pathMonitoramento, filter);
        _watcher.Created += new FileSystemEventHandler((source, @event) => { WatcherOnChangedEvent(source, @event, pathCopia); });
        _watcher.EnableRaisingEvents = true;
    }

    private void WatcherOnChangedEvent(object source, FileSystemEventArgs @event, string pathCopia)
    {
        string newPathFile = WatcherService.CopyFile(@event, pathCopia);
        new Thread(() => _svService.ReadColumn(newPathFile, 'a')).Start();
        new Thread(() => _svService.ReadColumn(newPathFile, 'b')).Start();       
    }
}