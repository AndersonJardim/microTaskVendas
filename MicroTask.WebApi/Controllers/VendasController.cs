using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MicroTask.Domain.Interface;

namespace MicroTask.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendasService _vendasService;

        public VendasController(IVendasService vendasService)
        {
            _vendasService = vendasService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            //logger.LogInformation($"Inicio do método {nameof(GetAllAsync)}");

            var vendas = await _vendasService.GetAllAsync();

            //logger.LogInformation($"Finalizado método {nameof(GetAllAsync)}");

            return Ok(vendas);
        }


    }
}
