using SBI_Challenge_Caramuto.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SBI_Challenge_Caramuto.Services
{
    public class DummyDataService : IDummyDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public DummyDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _url = "https://jsonplaceholder.typicode.com/posts";
        }

        public async Task<List<ServerPost>> GetDummyData()
        {
            try
            {
                var response = await _httpClient.GetAsync(_url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var serverPostList = JsonSerializer.Deserialize<List<ServerPost>>(content);
                    return serverPostList;
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error fetching dummy data from API: {response.StatusCode} - {errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error connecting to dummy data API: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error ocurred: {ex.Message}");
            }
        }
    }
}
