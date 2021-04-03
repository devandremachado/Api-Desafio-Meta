using System;
using System.Collections.Generic;

namespace Meta.CalculaJuros.UI.Models
{
    public class RetornoApi<T> where T : class
    {
        public RetornoApi()
        {
            Errors = new List<ErrorResponseApi>();
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Data { get; set; }
        public List<ErrorResponseApi> Errors { get; set; }
    }
}
