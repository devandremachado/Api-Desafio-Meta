using Meta.CalculaJuros.UI.Models;
using System;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.UI.Services
{
    public class ServiceAPI : IDisposable
    {
        private readonly RestService _restService;

        public ServiceAPI()
        {
            _restService = new RestService("http://localhost:58000/api");
        }

        public async Task<RetornoApi<JurosComposto>> CalculaJurosComposto(double valorInicial, int meses)
        {
            var response = await _restService.Get<JurosComposto>($"calculajuros", $"valorInicial={valorInicial}&meses={meses}");
            return response;
        }

        public void Dispose()
        {
            _restService.Dispose();
        }
    }
}
