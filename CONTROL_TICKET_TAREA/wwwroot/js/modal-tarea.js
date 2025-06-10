
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
        $.get(`/Home/FormTicketTarea/0`, function (html) {
            $('#crearTareaModalContainer').html(html);
            const modal = new bootstrap.Modal(document.getElementById('crearTareaModal'));
            modal.show();
        });
    });

    // Enviar formulario por AJAX
    $(document).on('submit', '#formCrearTarea', function (e) {
        e.preventDefault();

        const form = $(this);
        $.ajax({
            url: form.attr('action'),
            type: 'POST',
            data: form.serialize(),
            success: function (response, textStatus, jqXHR) {
                const contentType = jqXHR.getResponseHeader("Content-Type");

                if (contentType.includes("application/json")) {
                    location.reload();
                } else if (contentType.includes("text/html")) {
                    console.log("Fallo");

                    // Evitar que se cree fondo tras fondo
                        $('#crearTareaModal').remove();
                        $('.modal-backdrop').remove();

                    // Reemplazar el modal con el nuevo contenido con errores
                    $('#crearTareaModalContainer').html(response);

                    const modalElement = document.getElementById('crearTareaModal');
                    if (!modalElement) {
                        console.error("Modal no encontrado en el DOM");
                        return;
                    }

                    const modal = new bootstrap.Modal(modalElement);
                    modal.show();
                }
            }
        });
    });

    $(document).on('dblclick', '.fila-editable', function () {
        const id = $(this).data('id');
        $.get(`/Home/FormTicketTarea/${id}`, function (modalHtml) {
            $('#crearTareaModalContainer').html(modalHtml);
            const modalEl = document.getElementById('crearTareaModal');
            if (modalEl) {
                const modal = new bootstrap.Modal(modalEl);
                modal.show();
            }
        });
    });

    $(document).on('hidden.bs.modal', function () {
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