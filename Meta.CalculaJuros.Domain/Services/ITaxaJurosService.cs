using System.Threading.Tasks;

namespace Meta.CalculaJuros.Domain.Services
{
    public interface ITaxaJurosService
    {
      Task<double> ObterTaxaJuros();
    }
}
