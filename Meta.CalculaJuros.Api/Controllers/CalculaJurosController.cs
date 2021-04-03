using Meta.CalculaJuros.Domain.Commands.Requests;
using Meta.CalculaJuros.Domain.Handlers;
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
        private readonly CalculaJurosHandler _handler;

        public CalculaJurosController(CalculaJurosHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Calcula o juros composto
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CalculaJuros(double valorInicial, int meses)
        {
            try
            {
                var request = new JurosCompostoCommand(valorInicial, meses);
                var result = await _handler.Handle(request);

                if (result.Sucesso == false) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new CommandResponseError("Ocorreu um erro inesperado. Verifique se a API 1 está em execução.", ex.Message));
            }
        }
    }
}
