using System;

namespace Meta.CalculaJuros.Domain.Entities
{
    public class JurosComposto
    {
        public JurosComposto(double valor, int meses, double juros)
        {
            Valor = valor;
            Meses = meses;
            Juros = juros;
        }

        public double Valor { get; private set; }
        public int Meses { get; private set; }
        public double Juros { get; private set; }

        public double Calcular()
        {
            return Valor * (Math.Pow(1 + Juros, Meses));
        }
    }
}
