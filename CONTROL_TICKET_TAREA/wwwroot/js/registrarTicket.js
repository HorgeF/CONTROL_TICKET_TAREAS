let crearTicketCargando = false;

$(document).on("click", ".btn-registrar-ticket", function (e) {
    e.preventDefault();

    Swal.fire({
        title: "¿Estás seguro de crear un ticket para esta tarea?",
        text: "No serás capaz de revertir esto una vez creado",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Si",
        cancelButtonText: "No",
        confirmButtonColor: "#28A745",
        cancelButtonColor: "#DC3545",
    }).then((result) => {
        if (result.isConfirmed) {
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

                    // Restaurar spinner
                    $spinner.addClass('d-none');

                    if (respuesta.codTicket) {
                        // Reemplazar el botón actual por el código del ticket
                        $btnRegistrarTicketPorId.closest("td").html(respuesta.codTicket);

                        // Volver a habilitar los botones restantes (que aún no fueron reemplazados)
                        $(".btn-registrar-ticket").not($btnRegistrarTicketPorId).prop('disabled', false);

                        AlertaUtils.mostrar('success', 'Ticket ' + respuesta.codTicket + " creado exitosamente");
                    } else {
                        // Si no se recibió codTicket, reactivar todos los botones
                        $(".btn-registrar-ticket").prop('disabled', false);
                        AlertaUtils.mostrar('error', "No se logro recibir un código de ticket.");
                    }

                    crearTicketCargando = false;
                },
                error: function (err) {
                    crearTicketCargando = false;
                    $(".btn-registrar-ticket").prop('disabled', false);
                    $spinner.addClass('d-none');

                    if (err.status === 409 && err.responseJSON?.codTicket) {
                        $btnRegistrarTicketPorId.closest("td").html(err.responseJSON.codTicket);
                        AlertaUtils.mostrar('info', err.responseJSON.mensaje)
                    } else {
                        console.error("Error inesperado: " + err);
                        let mensajeError = err.responseJSON?.mensaje ? "Ocurrió un error al registrar el ticket: " + err.responseJSON?.mensaje : "Ocurrio un error al registrar el ticket"
                        AlertaUtils.mostrar('error', mensajeError);
                    }
                }
            });
        }
    });
});
