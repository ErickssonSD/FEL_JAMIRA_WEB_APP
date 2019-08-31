$(document).ready(function () {
    $("#mes2").click(function (e) {
        //e.preventDefault();

        $("#myModal").show();

        var data = {
            username: '1'
        };

        $.ajax({
            url: '/Menu/BuscarValor',
            method: 'GET',
            dataType: 'json',
            async: false,
            data: { username: '1' },
            success: function (response) {
                $('.modal-body').html(response.Nome);
            },
            error: function (response) {
                $('.modal-body').html(response);
            }
        });
    }); 

    $("#btnRecebimentos").click(function (e) {
        //e.preventDefault();

        $("#myModal").show();

        $.ajax({
            url: '/Menu/BuscarValor',
            method: 'GET',
            dataType: 'json',
            async: false,
            data: { username: '1' },
            success: function (response) {
                $('.modal-body').html(response.Nome);
            },
            error: function (response) {
                $('.modal-body').html(response);
            }
        });
    }); 
});