using FluentValidator;
using Meta.CalculaJuros.Domain.Commands.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Meta.CalculaJuros.Tests.Commands
{
    [TestClass]
    public class JurosCompostoCommandTests
    {
        [TestMethod]
        [TestCategory("Commands")]
        public void Dado_um_comando_valido_o_comando_deve_ser_valido()
        {
            var comando = new JurosCompostoCommand(100, 3);
            comando.Validar();

            Assert.AreEqual(comando.Valid, true);
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void Dado_um_comando_invalido_o_comando_deve_ser_invalido()
        {
            var comando = new JurosCompostoCommand(100, 0);
            comando.Validar();

            Assert.AreEqual(comando.Valid, false);
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void Dado_um_comando_invalido_o_comando_deve_possuir_notificacoes()
        {
            var comando = new JurosCompostoCommand(100, 0);
            comando.Validar();

            List<Notification> errors = (List<Notification>)comando.GetType().GetProperty("Notifications").GetValue(comando, null);

            Assert.AreEqual(errors.Count > 0, true);
        }
    }
}
