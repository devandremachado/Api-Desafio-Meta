var calculaJuros = (function () {
    const campos = {
        valorInicial: $('#txtValorInicial'),
        meses: $('#txtMeses'),
        btnCalcular: $('#btnCalcular')
    }

    $(document).ready(function () {
        CalcularClick();
    });

    function CalcularClick() {
        $('#btnCalcular').on('click', async function () {
            await CalculaTaxa();
        });
    }

    function CalculaTaxa() {
        Utility.BlockUI();

        var data = {
            valorInicial: campos.valorInicial.val(),
            meses: campos.meses.val()
        };

        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'POST',
                url: Actions.Calcula,
                dataType: 'json',
                data: data,
                success: function (result) {
                    if (result.sucesso) {
                        Utility.ModalMensagem.Sucesso(`O Resultado é: ${result.data.valor.toFixed(2)}`);
                    }

                    else {
                        let msgErros = '';
                        if (result.errors) result.errors.map((e) => { msgErros += `${e.mensagem} <br>`; });

                        Utility.ModalMensagem.Aviso(`${msgErros}`, result.mensagem);
                    }

                    resolve();
                },
                error: function (erro) {
                    Utility.ModalMensagem.Erro(`${erro.statusText}<br> Verifique se as API 1 e 2 estão em execução.`);
                    console.log(erro);
                    reject(erro);
                },
                complete: function () {
                    Utility.UnblockUI();
                }
            });
        });
    }

})();