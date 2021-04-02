using FluentValidator;
using Meta.CalculaJuros.Domain.Commands.Requests;
using Meta.CalculaJuros.Domain.Entities;
using Meta.CalculaJuros.Domain.Handlers.Interfaces;
using Meta.CalculaJuros.Domain.Services;
using Meta.CalculaJuros.Shared.Commands;
using Meta.CalculaJuros.Shared.Commands.Interfaces;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Meta.CalculaJuros.Domain.Handlers
{
    public class CalculaJurosHandler :
        Notifiable,
        ICalculaJurosHandler
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculaJurosHandler(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<ICommandResponse> Handle(JurosCompostoRequest request)
        {
            request.Validar();

            if (request.Invalid)
            {
                return new CommandResponseError("Por favor, corrija os campos abaixo", request.Notifications);
            }

            double taxa = await _taxaJurosService.ObterTaxaJuros();

            var juros = new JurosComposto(request.Valor, request.Meses, taxa);

            var resultado = Math.Truncate(juros.Calcular() * 100) / 100;

            return new CommandResponseSuccess(new
            {
                Valor = resultado.ToString("0.00")
            });
        }
    }
}
