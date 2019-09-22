﻿$(document).ready(function () {

    $("#cadastrar").click(function (event) {
        event.preventDefault();
        var $this = $("#cadastrar");
        $this.button('loading');
        var form = document.getElementById("formCarro");
        var data = $(form).serialize();
        $.post(form.action, data, function (response) {
            debugger;
            if (response && response.Data) {
                if (response.Serializado === true) {
                    $('#sucesso').css('display', 'block');
                    $('#alertas').css('display', 'none');
                } else {
                    $('#fracasso').css('display', 'block');
                }
            }
            $('#cadcarro').remove();
        });
    });
});