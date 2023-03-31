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
            List<ServerPost> serverPostList;
            try
            {
                var response = await _client.GetAsync(_url);
                var content = await response.Content.ReadAsStringAsync();
                serverPostList = JsonSerializer.Deserialize<List<ServerPost>>(content);
            }
            catch (Exception)
            {
                return null;
            }

            return serverPostList;
        }
    }
}
