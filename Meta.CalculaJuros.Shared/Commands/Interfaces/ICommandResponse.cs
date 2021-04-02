namespace Meta.CalculaJuros.Shared.Commands.Interfaces
{
    public interface ICommandResponse
    {
        string Mensagem { get; set; }
        bool Sucesso { get; set; }
    }
}
