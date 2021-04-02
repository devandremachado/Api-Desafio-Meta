using FluentValidator;
using FluentValidator.Validation;
using Meta.CalculaJuros.Shared.Commands.Interfaces;

namespace Meta.CalculaJuros.Domain.Commands.Requests
{
    public class JurosCompostoCommand : Notifiable, ICommand
    {
        public JurosCompostoCommand(double valor, int meses)
        {
            Valor = valor;
            Meses = meses;
        }

        public double Valor { get; set; }
        public int Meses { get; set; }

        public void Validar()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsGreaterThan(Valor, 0, "Valor", "O valor deve ser maior que zero")
                .IsGreaterThan(Meses, 0, "Meses", "A quantidade de meses deve ser maior que zero")
            );
        }
    }
}
