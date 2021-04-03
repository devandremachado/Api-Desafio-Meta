using Meta.CalculaJuros.UI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.UI.Services
{
    public class RestService
    {
        private readonly HttpClient _client;
        private readonly string _apiUrl;

        public RestService(string apiUrl)
        {
            _apiUrl = apiUrl;

            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<RetornoApi<T>> Get<T>(string action, string query = "") where T : class
        {
            var apiResponse = new RetornoApi<T>();

            var result = await _client.GetAsync($"{_apiUrl}/{action}?{query}");
            var jsonResult = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

            var sucesso = (bool) JObject.Parse(jsonResult)["sucesso"];
            var mensagem = (string) JObject.Parse(jsonResult)["mensagem"];
            var data = JsonConvert.SerializeObject(JObject.Parse(jsonResult)["data"]);
            var errors = JObject.Parse(jsonResult)["errors"]?.ToObject<List<ErrorResponseApi>>();

            apiResponse.Sucesso = sucesso;
            apiResponse.Mensagem = mensagem;
            apiResponse.Data = JsonConvert.DeserializeObject<T>(data);
            apiResponse.Errors = errors;

            return apiResponse;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
