using Meta.CalculaJuros.Domain.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.Infra.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private const string _baseUrl = "http://localhost:59000/api/";

        public async Task<double> ObterTaxaJuros()
        {

            using HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync(_baseUrl + "taxaJuros");
            using HttpContent content = response.Content;

            var result = content.ReadAsStringAsync().Result;
            return Convert.ToDouble(result);
        }
    }
}
