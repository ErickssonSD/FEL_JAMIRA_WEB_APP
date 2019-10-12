function Aprovar(idSolicitacao)
{
    debugger;
        valor = String(idSolicitacao);
         $.ajax({
              url: "/Estacionamento/AprovarSolicitacao",
              type : 'post',
              data : {
                   id: valor
              },
              beforeSend : function () {
                   //$("#resultado").html("ENVIANDO...");
                  alert('feitoo');
                }
         })
        .done(function (msg) {
            alert('feito');
            $('#' + idSolicitacao + '--').remove();
        })
        .fail(function (jqXHR, textStatus, msg) {
              alert(msg);
        }); 
}

function Reprovar(idSolicitacao) {

}