using SBI_Challenge_Caramuto.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBI_Challenge_Caramuto.Services
{
    public interface IDummyDataService
    {
        Task<List<ServerPost>> GetDummyData();
    }
}
