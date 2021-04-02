using Meta.CalculaJuros.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Meta.CalculaJuros.Api.Controllers
{
    [Route("api/showmethecode")]
    [ApiController]
    public class ShowmeTheCodeController : ControllerBase
    {
        /// <summary>
        /// Retorna URL do projeto no github
        /// </summary>
        [HttpGet]
        public IActionResult GetPerfil()
        {
            var response = new CommandResponseSuccess(new{Url = "https://github.com/devandremachado/Api-Desafio-Meta"}, ":)");
            return Ok(response);
        }
    }
}
