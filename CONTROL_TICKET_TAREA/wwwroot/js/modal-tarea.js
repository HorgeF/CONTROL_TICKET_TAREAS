// Cargar el modal
$(document).on('click','#btnNuevaTarea',function () {
    const $btn = $(this);
    const $spinner = $btn.find('.spinner-border');

    $.ajax({
        url: "/Home/FormTicketTarea/0",
        type: "GET",
        beforeSend: function () {
            $btn.prop('disabled', true);
            $spinner.removeClass('d-none');
        },
        success: function (html) {
            $('#guardarTareaModalContainer').html(html);
            const modalElement = document.getElementById('guardarTareaModal');
            const modal = new bootstrap.Modal(modalElement);
            modal.show();

            $(modalElement).on('hidden.bs.modal', function () {
                $btn.prop('disabled', false);
                $spinner.addClass('d-none');
            });
        },
        error: function (err) {
            $btn.prop('disabled', false);
            $spinner.addClass('d-none');
            console.error("Error inesperado: " + err);
            AlertaUtils.mostrar('error','Error al cargar el formulario'); 
        },
    });
});

let enviandoFormulario = false;

// Enviar formulario por AJAX
$(document).on('submit', '#formGuardarTarea', function (e) {
    e.preventDefault();

    if (enviandoFormulario) return;

    enviandoFormulario = true;

    const $btnGuardar = $("#btnGuardar");
    const $spinner = $btnGuardar.find('.spinner-border');
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        type: 'POST',
        data: form.serialize(),
        beforeSend: function () {
            $btnGuardar.prop('disabled', true);
            $spinner.removeClass('d-none');
        },
        success: function (response, textStatus, jqXHR) {
            const contentType = jqXHR.getResponseHeader("Content-Type");

            if (contentType.includes("application/json")) {
                $('#guardarTareaModal').remove();
                $('.modal-backdrop').remove();
                AlertaUtils.mostrar('success', '¡Guardado exitosamente!',1500);
                setTimeout(() => {
                    location.reload();
                },1500)
            } else if (contentType.includes("text/html")) {
                // Evitar que se cree fondo tras fondo
                $('#guardarTareaModal').remove();
                $('.modal-backdrop').remove();

                // Reemplazar el modal con el nuevo contenido con errores
                $('#guardarTareaModalContainer').html(response);

                const modalElement = document.getElementById('guardarTareaModal');
                if (!modalElement) {
                    AlertaUtils.mostrar('error', 'Modal no encontrado');
                    return;
                }

                const modal = new bootstrap.Modal(modalElement);
                modal.show();
            }
        },
        error: function (err) {
            AlertaUtils.mostrar('error', 'Error inesperado: ' + err.responseJSON.mensaje);
        },
        complete: function () {
            enviandoFormulario = false;
            $btnGuardar.prop('disabled', false);
            $spinner.addClass('d-none');
        }
    });
});

$(document).on('dblclick', '.fila-editable', function () {
    const $fila = $(this);
    const id = $(this).data('id');

    // Agregar efecto visual de carga
    $('.fila-editable').removeClass('loading-border').addClass('disabled-row pe-none');
    $fila.removeClass('disabled-row').addClass('loading-border');

    $.get(`/Home/FormTicketTarea/${id}`, function (modalHtml) {
        $('#guardarTareaModalContainer').html(modalHtml);
        const modalEl = document.getElementById('guardarTareaModal');
        if (modalEl) {
            const modal = new bootstrap.Modal(modalEl);
            modal.show();

            $(modalEl).on('hidden.bs.modal', function () {
                $('.fila-editable').removeClass('loading-border disabled-row pe-none');
            });
        }
    }).fail(function () {
        $('.fila-editable').removeClass('loading-border disabled-row pe-none');
        AlertaUtils.mostrar('error',"Ocurrio un problema al cargar el formulario para editar.");
    })
});

$(document).on('hidden.bs.modal', function () {
    const $btn = $("#btnNuevaTarea");
    const $spinner = $btn.find('.spinner-border');

    $btn.prop('disabled', false);
    $spinner.addClass('d-none');

    $('.fila-editable').removeClass('loading-border disabled-row pe-none');

    // Asegura que el scroll se restaure
    $('body').css('overflow', 'auto');
    $('body').css('padding-right', '0');
});