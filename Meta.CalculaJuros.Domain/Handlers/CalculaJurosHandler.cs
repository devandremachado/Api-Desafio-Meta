using FluentValidator;
using Meta.CalculaJuros.Domain.Commands.Requests;
using Meta.CalculaJuros.Domain.Entities;
using Meta.CalculaJuros.Domain.ServicesRepository;
using Meta.CalculaJuros.Shared.Commands;
using Meta.CalculaJuros.Shared.Commands.Interfaces;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.Domain.Handlers
{
    public class CalculaJurosHandler : Notifiable, ICommandHandler<JurosCompostoCommand>
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculaJurosHandler(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task <ICommandResponse> Handle(JurosCompostoCommand command)
        {
            command.Validar();
            if (command.Invalid)
                return new CommandResponseError("Parâmetros inválidos", command.Notifications);

            var taxa = await _taxaJurosService.ObterTaxaJuros();

            var juros = new JurosComposto(command.Valor, command.Meses, taxa);

            AddNotifications(juros.Notifications);
            if (Invalid)
                return new CommandResponseError("Por favor, corrija os campos abaixo", juros.Notifications);

            var resultado = Math.Truncate(juros.Calcular() * 100) / 100;

            return new CommandResponseSuccess(new { Valor = string.Format(CultureInfo.InvariantCulture, "{0:0.00}", resultado) });
        }
    }
}
