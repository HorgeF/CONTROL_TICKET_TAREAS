
    $(document).on('change', '#cboGrupoEconomico', function () {
        const grupoId = $(this).val();

        console.log("Id grupo economico:" + grupoId);

        $('#cboEntidad').empty();
        $('#cboEntidad').append('<option value="">Cargando...</option>');

        if (grupoId) {
            $.ajax({
                url: '/Home/ListarEmpresasParaSelect',
                type: 'GET',
                data: { grupoId: grupoId },
                success: function (data) {
                    $('#cboEntidad').empty();
                    $('#cboEntidad').append('<option value="">-SELECCIONAR-</option>');
                    $.each(data, function (i, empresa) {
                        $('#cboEntidad').append(`<option value="${empresa.value}">${empresa.text}</option>`);
                    });
                },
                error: function () {
                    $('#cboEntidad').empty();
                    $('#cboEntidad').append('<option value="">Error al cargar</option>');
                }
            });
        } else {
            $('#cboEntidad').html('<option value="">-SELECCIONAR-</option>');
        }
    });

    // Cargar el modal con AJAX
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
                alert('Error al cargar el formulario'); 
            }
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
                    location.reload();
                } else if (contentType.includes("text/html")) {
                    console.log("Fallo");

                    // Evitar que se cree fondo tras fondo
                    $('#guardarTareaModal').remove();
                    $('.modal-backdrop').remove();

                    // Reemplazar el modal con el nuevo contenido con errores
                    $('#guardarTareaModalContainer').html(response);

                    const modalElement = document.getElementById('guardarTareaModal');
                    if (!modalElement) {
                        console.error("Modal no encontrado en el DOM");
                        return;
                    }

                    const modal = new bootstrap.Modal(modalElement);
                    modal.show();
                }

                enviandoFormulario = false;
                $btnGuardar.prop('disabled', false);
                $spinner.addClass('d-none');
            },
            error: function (err) {
                enviandoFormulario = false;
                $btnGuardar.prop('disabled', false);
                $spinner.addClass('d-none');
                console.error("Error inesperado: " + err);
            }
        });
    });

    let tareaCargando = false;

    $(document).on('dblclick', '.fila-editable', function () {
        if (tareaCargando) return;

        tareaCargando = true;

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
            }

            tareaCargando = false;
            $('.fila-editable').removeClass('loading-border disabled-row pe-none');
        }).fail(function () {
            tareaCargando = false;
            $('.fila-editable').removeClass('loading-border disabled-row pe-none');
            alert("Ocurrio un problema al cargar el formulario para editar.");
        });
    });

    $(document).on('hidden.bs.modal', function () {
        const $btn = $("#btnNuevaTarea");
        const $spinner = $btn.find('.spinner-border');

        $btn.prop('disabled', false);
        $spinner.addClass('d-none');

        // Asegura que el scroll se restaure
        $('body').css('overflow', 'auto');
        $('body').css('padding-right', '0');

    });

    $(document).on('change', '#cboItem', function () {
        const seleccionado = $(this).val();
        const txtItem = $('#txtItem');

        console.log("Item seleccionado: " + seleccionado);

        if (txtItem.length) {
            const debeDeshabilitar = seleccionado !== "0";
            txtItem.prop('disabled', debeDeshabilitar);
            if (debeDeshabilitar) {
                txtItem.val('');
            }
        }
    });