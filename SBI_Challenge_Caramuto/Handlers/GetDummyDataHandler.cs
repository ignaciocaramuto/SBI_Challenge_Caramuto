using MediatR;
using System.Threading.Tasks;
using System.Threading;
using SBI_Challenge_Caramuto.Queries;
using SBI_Challenge_Caramuto.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System;

namespace SBI_Challenge_Caramuto.Handlers
{
    public class GetDummyDataHandler : IRequestHandler<GetDummyDataQuery, List<ServerPost>>
    {
        private HttpClient _client;
        private string _url;

        public GetDummyDataHandler()
        {
            _client = new HttpClient();
            _url = "https://jsonplaceholder.typicode.com/posts";
        }
        public async Task<List<ServerPost>> Handle(GetDummyDataQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _client.GetAsync(_url);
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

            finally { _client.Dispose(); }
        }
    }
}
