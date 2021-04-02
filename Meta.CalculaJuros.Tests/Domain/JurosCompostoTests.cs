using Meta.CalculaJuros.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Meta.CalculaJuros.Tests.Domain
{
    [TestClass]
    public class JurosCompostoTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_algum_valor_obrigatorio_incorreto_o_objeto_deve_ser_invalido()
        {
            var juros = new JurosComposto(100, 0, 0);
            Assert.AreEqual(juros.Valid, false);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_todos_valores_o_calculo_deve_estar_correto()
        {
            var resultadoEsperado = 105.10;

            var juros = new JurosComposto(100, 5, 0.01);
            var resultado = Math.Truncate(juros.Calcular() * 100) / 100;

            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
}
