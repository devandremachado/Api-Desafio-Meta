using Newtonsoft.Json;

namespace Meta.CalculaJuros.UI.Models
{
    public class ErrorResponseApi
    {
        [JsonProperty(PropertyName = "property")]
        public string Propriedade { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Mensagem { get; set; }
    }
}
