namespace Meta.CalculaJuros.Shared.Commands.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResponse Handle(T command);
    }
}
