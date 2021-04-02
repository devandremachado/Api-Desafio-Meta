namespace Meta.CalculaJuros.Shared.Commands.Interfaces
{
    public interface ICommandResponseError : ICommandResponse
    {
        object Errors { get; set; }
    }
}
