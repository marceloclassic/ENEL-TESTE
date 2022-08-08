namespace Teste.Domain.Interfaces;
public interface IHttpService
{
    Task<T?> Post<T>(string url, object body);
}