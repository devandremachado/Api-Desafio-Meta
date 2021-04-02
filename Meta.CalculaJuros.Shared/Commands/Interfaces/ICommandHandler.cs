using System.Threading.Tasks;

namespace Meta.CalculaJuros.Shared.Commands.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
       Task<ICommandResponse> Handle(T command);
    }
}
