using Meta.CalculaJuros.Domain.ServicesRepository;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.Tests.ServicesRepository
{
    public class FakeTaxaJurosService : ITaxaJurosService
    {
        public Task<double> ObterTaxaJuros()
        {
            var taxa = 0.01;

            return Task.FromResult(taxa);
        }
    }
}
