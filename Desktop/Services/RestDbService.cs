using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desktop.Services;

public class RestDbService
{
    private readonly HttpClient _httpClient;

    public RestDbService(string baseUrl, string apiKey)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(baseUrl);
        _httpClient.DefaultRequestHeaders.Add("x-apikey", apiKey);
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );
    }

    public async Task<List<T>> GetAllAsync<T>(string collection)
    {
        var response = await _httpClient.GetAsync($"/rest/{collection}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<T>>(json)
               ?? new List<T>();
    }

    public async Task AddAsync<T>(string collection, T item)
    {
        var json = JsonSerializer.Serialize(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"/rest/{collection}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task PatchAsync<T>(string collection, string id, T item)
    {
        var json = JsonSerializer.Serialize(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PatchAsync(
            $"/rest/{collection}/{id}",
            content
        );

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string collection, string id)
    {
        var response = await _httpClient.DeleteAsync($"/rest/{collection}/{id}");
        response.EnsureSuccessStatusCode();
    }
}