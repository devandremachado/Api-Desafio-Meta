using Meta.CalculaJuros.Shared.Commands.Interfaces;

namespace Meta.CalculaJuros.Shared.Commands
{
    public class CommandResponseError : ICommandResponseError
    {
        public CommandResponseError(string mensagem, object erros)
        {
            Sucesso = false;
            Mensagem = mensagem;
            Errors = erros;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Errors { get; set; }
    }
}
