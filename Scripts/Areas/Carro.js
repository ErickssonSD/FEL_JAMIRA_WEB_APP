$(document).ready(function () {

    $("#formCarro input[type=submit]").click(function (event) {
        event.preventDefault();
        debugger;
        var form = document.getElementById("formCarro");
        var data = $(form).serialize();
        $.post(form.action, data, function (response) {
            if (response && response.data)
                alert(response.data);
        });
    });
});