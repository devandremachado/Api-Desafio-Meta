using Meta.CalculaJuros.Domain.Commands.Requests;
using Meta.CalculaJuros.Shared.Commands.Interfaces;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.Domain.Handlers.Interfaces
{
    public interface ICalculaJurosHandler
    {
       Task<ICommandResponse>  Handle(JurosCompostoRequest request);
    }
}
