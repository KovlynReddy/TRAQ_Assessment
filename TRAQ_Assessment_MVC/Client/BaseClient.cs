using System.Text;
using System.Text.Json;

namespace TRAQ_Assessment_MVC.Client;

public class BaseClient<T>
{
    private static readonly HttpClient client = new HttpClient();
    private string Url { get; set; }

    public BaseClient(string controllerName)
    {
        this.Url = $"https://localhost:7258/api/{controllerName}";
    }

    public async Task<T> GetById(int id)
    {
        var response = await client.GetAsync(Url+$"/{id}");
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(responseJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task<List<T>> GetList()
    {
        var response = await client.GetAsync(Url);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<T>>(responseJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task<List<T>> GetList(int id)
    {
        var response = await client.GetAsync(Url+$"/list/{id}");
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<T>>(responseJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task<List<T>> Search(string query)
    {
        var response = await client.GetAsync(Url+$"/search/{query}");
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<T>>(responseJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task<T?> PostJsonAsync(T body)
    {
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(Url, content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(responseJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }


    public async Task<T?> PatchJsonSync(T body)
    {
        var json = JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PatchAsync(Url, content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(responseJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

}
