using MediatR;
using System.Threading.Tasks;
using System.Threading;
using SBI_Challenge_Caramuto.Queries;
using SBI_Challenge_Caramuto.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System;
using SBI_Challenge_Caramuto.Services;

namespace SBI_Challenge_Caramuto.Handlers
{
    public class GetDummyDataHandler : IRequestHandler<GetDummyDataQuery, List<ServerPost>>
    {
        private readonly IDummyDataService _dummyDataService;

        public GetDummyDataHandler(IDummyDataService dummyDataService)
        {
            _dummyDataService = dummyDataService;
        }
        public async Task<List<ServerPost>> Handle(GetDummyDataQuery request, CancellationToken cancellationToken)
        {
            var serverPostList = await _dummyDataService.GetDummyData();
            return serverPostList;
        }
    }
}
