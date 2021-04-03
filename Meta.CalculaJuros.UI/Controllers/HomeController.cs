using Meta.CalculaJuros.UI.Models;
using Meta.CalculaJuros.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.UI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calcula(double valorInicial, int meses)
        {
            var service = new ServiceAPI();
            var resultado = await service.CalculaJurosComposto(valorInicial, meses);

            return Json(resultado);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
