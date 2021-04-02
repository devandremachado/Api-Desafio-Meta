using FluentValidator;
using FluentValidator.Validation;
using System;

namespace Meta.CalculaJuros.Domain.Entities
{
    public class JurosComposto : Notifiable
    {
        public JurosComposto(double valor, int meses, double juros)
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsGreaterThan(valor, 0, "Valor", "O valor deve ser maior que zero")
                .IsGreaterThan(meses, 0, "Meses", "A quantidade de meses deve ser maior que zero")
            );

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
