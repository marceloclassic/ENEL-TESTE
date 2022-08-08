using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Teste.Domain.Interfaces;

namespace Teste.Domain.Services;
public class HttpService : IHttpService
{
    public async Task<T?> Post<T>(string url, object body)
    {
        using var client = new HttpClient();
        var myContent = JsonConvert.SerializeObject(body);

        var buffer = Encoding.UTF8.GetBytes(myContent);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        HttpResponseMessage result = await client.PostAsync(url, byteContent);
        return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
    }
}