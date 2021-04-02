using Meta.CalculaJuros.Shared.Commands.Interfaces;

namespace Meta.CalculaJuros.Shared.Commands
{
    public class CommandResponseSuccess : ICommandResponse
    {
        public CommandResponseSuccess(object data, string mensagem = "")
        {
            Sucesso = true;
            Data = data;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}
