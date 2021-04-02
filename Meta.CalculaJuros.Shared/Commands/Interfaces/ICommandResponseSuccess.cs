namespace Meta.CalculaJuros.Shared.Commands.Interfaces
{
    public interface ICommandResponseSuccess : ICommandResponse
    {
        object Data { get; set; }
    }
}
