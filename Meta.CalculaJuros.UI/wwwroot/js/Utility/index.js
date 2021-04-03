var Utility = (function () {

    var ModalMensagem = (function () {

        function ModeloSwalMensagem(mensagem, titulo, icone, callback, permitirClickExterno = true) {
            Swal.fire({
                icon: icone,
                title: titulo,
                html: mensagem,
                confirmButtonText: 'OK',
                allowEnterKey: false,
                allowOutsideClick: permitirClickExterno
            }).then((result) => {
                if (result.value) {
                    if (callback) {
                        return callback();
                    }
                }
            });
        }

        function Sucesso(mensagem, titulo = 'Sucesso!', callback, permitirClickExterno = true) {
            if (!titulo)
                titulo = 'Sucesso!';

            ModeloSwalMensagem(mensagem, titulo, 'success', callback, permitirClickExterno);
        }

        function Erro(mensagem, titulo = 'Algo deu errado...', callback, permitirClickExterno = true) {
            if (!titulo)
                titulo = 'Algo deu errado...';

            ModeloSwalMensagem(mensagem, titulo, 'error', callback, permitirClickExterno);
        }

        function Aviso(mensagem, titulo = 'Oops...', callback, permitirClickExterno = true) {
            if (!titulo)
                titulo = 'Oops...';

            ModeloSwalMensagem(mensagem, titulo, 'warning', callback, permitirClickExterno);
        }

        return {
            Sucesso: Sucesso,
            Erro: Erro,
            Aviso: Aviso
        };
    })();

    function BlockUI(mensagem = '') {
        $.blockUI({
            baseZ: 9999999999,
            fadeIn: 0,
            message: `<div><img src="imagens/loading.gif" width="120" /><p>${mensagem}</p><\div>`,
            css: {
                border: 'none',
                padding: '15px',
                backgroundColor: 'none',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: 1,
                color: '#ffffff'
            },

            overlayCSS: {
                backgroundColor: '#ffffff',
                opacity: 0.8,
                cursor: 'wait'
            }
        });
    }

    function UnblockUI() {
        $.unblockUI();
    }

    return {
        ModalMensagem: ModalMensagem,
        BlockUI: BlockUI,
        UnblockUI: UnblockUI
    };

})();