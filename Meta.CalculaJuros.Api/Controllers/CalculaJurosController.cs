using Meta.CalculaJuros.Domain.Commands.Requests;
using Meta.CalculaJuros.Domain.Handlers.Interfaces;
using Meta.CalculaJuros.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.Api.Controllers
{
    [Route("api/calculajuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosHandler _handler;

        public CalculaJurosController(ICalculaJurosHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaxaJuros(double valorInicial, int meses)
        {
            try
            {
                var request = new JurosCompostoRequest(valorInicial, meses);
                var result = await _handler.Handle(request);

                if (result.Sucesso == false) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new CommandResponseError("Ocorreu um erro inesperado", ex.Message));
            }
        }
    }
}
