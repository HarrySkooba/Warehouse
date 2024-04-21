using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7107/api/");
    }

    public async Task<bool> CheckLogin(string username, string password)
    {
        var data = new { Name = username, Password = password };

        HttpResponseMessage response = await _httpClient.GetAsync("login"); 

        if (response.IsSuccessStatusCode)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}