using FluentValidator;
using Meta.CalculaJuros.Domain.Commands.Requests;
using Meta.CalculaJuros.Domain.Handlers;
using Meta.CalculaJuros.Domain.ServicesRepository;
using Meta.CalculaJuros.Tests.ServicesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.Tests.Handlers
{
    [TestClass]
    public class CalculaJurosHandlerTests
    {
        private readonly ITaxaJurosService _taxaJurosService;
        private readonly CalculaJurosHandler _handler;

        public CalculaJurosHandlerTests()
        {
            _taxaJurosService = new FakeTaxaJurosService();
            _handler = new CalculaJurosHandler(_taxaJurosService);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public async Task Dado_um_comando_valido_o_handler_deve_ser_valido()
        {
            var comando = new JurosCompostoCommand(100, 5);

            var result = await _handler.Handle(comando);
            Assert.AreEqual(result.Sucesso, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public async Task Dado_um_comando_invalido_o_handler_deve_ser_invalido()
        {
            var comando = new JurosCompostoCommand(100, 0);

            var result = await _handler.Handle(comando);
            Assert.AreEqual(result.Sucesso, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public async Task Dado_um_comando_invalido_o_handler_deve_possuir_notificacoes()
        {
            var comando = new JurosCompostoCommand(0, 5);

            var result = await _handler.Handle(comando);

            List<Notification> errors = (List<Notification>)result.GetType().GetProperty("Errors").GetValue(result, null);

            Assert.AreEqual(errors.Count > 0, true);
        }
    }
}
