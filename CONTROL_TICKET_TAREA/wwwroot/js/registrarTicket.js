let crearTicketCargando = false;

$(".btn-registrar-ticket").on("click", function (e) {
    e.preventDefault();

    if (crearTicketCargando) return;
    crearTicketCargando = true;

    const idTarea = $(this).closest("tr").data('id');
    const $btnRegistrarTicketPorId = $(`#btn-registrar-ticket-${idTarea}`);
    const $spinner = $btnRegistrarTicketPorId.find(".spinner-border");

    $.ajax({
        url: "/Home/RegistrarTicket",
        type: "POST",
        data: { idTarea: idTarea },
        beforeSend: function () {
            // Deshabilitar todos los botones
            $(".btn-registrar-ticket").prop('disabled', true);

            // Activar spinner solo en el botón actual
            $spinner.removeClass('d-none');
        },
        success: function (respuesta) {
            crearTicketCargando = false;

            // Restaurar spinner
            $spinner.addClass('d-none');

            if (respuesta.codTicket) {
                // Reemplazar el botón actual por el código del ticket
                $btnRegistrarTicketPorId.closest("td").html(respuesta.codTicket);

                // Volver a habilitar los botones restantes (que aún no fueron reemplazados)
                $(".btn-registrar-ticket").not($btnRegistrarTicketPorId).prop('disabled', false);
            } else {
                // Si no se recibió codTicket, reactivar todos los botones
                $(".btn-registrar-ticket").prop('disabled', false);
                alert("No se recibió un código de ticket.");
            }   
        },
        error: function (err) {
            crearTicketCargando = false;
            $(".btn-registrar-ticket").prop('disabled', false);
            $spinner.addClass('d-none');
            console.error("Error inesperado: " + err);
            alert("Ocurrió un error al registrar el ticket.");
        }
    });
});
