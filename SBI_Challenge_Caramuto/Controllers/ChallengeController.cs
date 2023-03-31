using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SBI_Challenge_Caramuto.DTO;
using SBI_Challenge_Caramuto.Queries;
using System.Threading.Tasks;

namespace SBI_Challenge_Caramuto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ChallengeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetDummyData")]
        public async Task<IActionResult> GetDummyData(int id)
        {
            var dummyDataquery = new GetDummyDataQuery();
            var dummyDataresponse = await _mediator.Send(dummyDataquery);
            var dummyDataelement = dummyDataresponse.Find(item => item.id == id);
            Salida salida = _mapper.Map<Salida>(dummyDataelement);
            return Ok(salida);
        }
    }
}
