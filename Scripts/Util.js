$(document).ready(function () {
    var url = location.href;

    if (url.indexOf("RegistrarEstacionamento") !== -1) {
        var $Cnpj = $("#CNPJ");
        $Cnpj.mask('00.000.000/0000-00', { reverse: true });
    }

    var $Cpf = $("#CPF");
    $Cpf.mask('000.000.000-00', { reverse: true });

    var $Rg = $("#RG");
    $Rg.mask('00.000.000-0', { reverse: true });

    var $Cep = $("#CEP");
    $Cep.mask('00000-000', { reverse: true });
});