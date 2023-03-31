using MediatR;
using SBI_Challenge_Caramuto.Model;
using System.Collections.Generic;

namespace SBI_Challenge_Caramuto.Queries
{
    public class GetDummyDataQuery : IRequest<List<ServerPost>> { }
}
