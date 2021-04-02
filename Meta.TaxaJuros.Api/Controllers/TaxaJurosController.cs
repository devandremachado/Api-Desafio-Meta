using Microsoft.AspNetCore.Mvc;

namespace Meta.Api.Controllers
{
    [Route("api/taxaJuros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("0,01");
        }
    }
}
