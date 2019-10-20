$(document).ready(function () {
    $("#cadastrar").click(function (event) {
        event.preventDefault();
        var $this = $("#cadastrar");
        $('#aguardeCEP').show();
        var form = document.getElementById("formEstacionamento");
        var data = $(form).serialize();
        $.post(form.action, data, function (response) {
            if (response && response.Data) {
                if (response.Sucesso === true) {
                    $('#sucesso').modal('show');
                    $('#alertas').css('display', 'none');
                }
                else
                {
                    $('#fracasso').modal('show');
                }
            }
            else
            {
                $('#fracasso').modal('show');
            }
        });
        $('#aguardeCEP').hide();
    });
});