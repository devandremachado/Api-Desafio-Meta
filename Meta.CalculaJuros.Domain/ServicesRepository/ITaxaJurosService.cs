using System.Threading.Tasks;

namespace Meta.CalculaJuros.Domain.ServicesRepository
{
    public interface ITaxaJurosService
    {
      Task<double> ObterTaxaJuros();
    }
}
