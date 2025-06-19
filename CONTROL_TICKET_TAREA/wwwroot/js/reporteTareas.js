$(document).on('click', '#btnReportar', function () {
    const $btn = $(this);
    const $spinner = $btn.find('.spinner-border');

    const data = $('#filtroForm').serialize();

    console.log("DATA A ENVIAR:", data);

    $.ajax({
        url: "/Home/GenerarReporteSemanal",
        type: "GET",
        data: data,
        beforeSend: function () {
            $btn.prop('disabled', true);
            $spinner.removeClass('d-none');
        },
        success: function (html) {
            $('#reporteTareaModalContainer').html(html);

            const modalElement = document.getElementById('reporteTareaModal');
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
            alert('Error al cargar el formulario');
        },
    });
});

$(document).on('shown.bs.modal', '#reporteTareaModal', function () {
    const $tabla = $('#tabla-tareas-reporte');
    TablaUtils.habilitarOrdenTabla($tabla);
});

$(document).on('hidden.bs.modal', function () {
    const $btnReportar = $("#btnReportar")
    const $spinner = $btnReportar.find('.spinner-border');

    $btnReportar.prop('disabled', false);
    $spinner.addClass('d-none');

    // Asegura que el scroll se restaure
    $('body').css('overflow', 'auto');
    $('body').css('padding-right', '0');
});
