using Microsoft.AspNetCore.Mvc;
using MicroTask.Domain.Interface;
using MicroTask.Domain.Models;

namespace MicroTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VendasController : ControllerBase
    {
        private readonly ILogger<VendasController> logger;
        private readonly IVendasService vendasService;

        public VendasController(ILoggerFactory loggerFactory, IVendasService vendasService)
        {
            logger = loggerFactory.CreateLogger<VendasController>()
                ?? throw new ArgumentNullException(nameof(loggerFactory));
            this.vendasService = vendasService
                ?? throw new ArgumentNullException(nameof(vendasService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            logger.LogInformation($"Inicio do método {nameof(GetAllAsync)}");

            var vendas = await vendasService.GetAllAsync();

            logger.LogInformation($"Finalizado método {nameof(GetAllAsync)}");

            return Ok(vendas);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            logger.LogInformation($"Inicio do método {nameof(GetByIdAsync)}. Id da consulta {id}.");

            var venda = await vendasService.GetByIdAsync(id);

            if (venda == null)
            {
                return NotFound();
            }

            logger.LogInformation($"Finalizado método {nameof(GetByIdAsync)}");

            return Ok(venda);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] Vendas venda)
        {
            var result = await vendasService.AddAsync(venda);
            return Ok(venda); 
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] Vendas venda)
        {
            await vendasService.UpdateAsync(venda);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await vendasService.DeleteAsync(id);
            return NoContent();            
        }
    }
}
