$(".btn-registrar-ticket").on("click", function () {
    const idTarea = $(this).closest("tr").data('id');
    console.log(idTarea);
    $.post("/Home/RegistrarTicket", { idTarea: idTarea }, function (respuesta) {
        location.reload();
    });
});