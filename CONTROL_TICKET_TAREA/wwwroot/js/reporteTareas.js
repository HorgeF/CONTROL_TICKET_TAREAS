$(document).on('click', '#btnReportar', function () {
    const $btn = $(this);
    const $spinner = $btn.find('.spinner-border');

    $.ajax({
        url: "/Home/GenerarReporte",
        type: "GET",
        beforeSend: function () {
            $btn.prop('disabled', true);
            $spinner.removeClass('d-none');
        },
        success: function (html) {
            $('#reporteTareaModalContainer').html(html);

            InicializarTomSelect();

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

let enviandoFormularioReporte = false;

// Enviar formulario por AJAX
$(document).on('submit', '#formUsuarios', function (e) {
    e.preventDefault();

    if (enviandoFormularioReporte) return;

    enviandoFormularioReporte = true;

    const $spinner = $("#spinnerLoading");
    const form = $(this);

    $.ajax({
        url: form.attr('action'),
        type: 'GET',
        data: form.serialize(),
        beforeSend: function () {
            $spinner.removeClass('d-none');
        },
        success: function (response, textStatus, jqXHR) {

            // Evitar que se cree fondo tras fondo
            $('#reporteTareaModal').remove();
            $('.modal-backdrop').remove();

            // Reemplazar el modal con el nuevo contenido con errores
            $('#reporteTareaModalContainer').html(response);

            InicializarTomSelect();

            const modalElement = document.getElementById('reporteTareaModal');
            if (!modalElement) {
                console.error("Modal no encontrado en el DOM");
                return;
            }

            const modal = new bootstrap.Modal(modalElement);
            modal.show();
        },
        error: function (err) {
            console.error("Error inesperado: " + err.responseJSON.mensaje);
        },
        complete: function () {
            enviandoFormularioReporte = false;
            $spinner.addClass('d-none');
        }
    });
});

let selectUsuariosInstance = null;

function InicializarTomSelect() {
    if (selectUsuariosInstance) {
        selectUsuariosInstance.destroy();
    }

    selectUsuariosInstance = new TomSelect("#usuarios", {
        maxItems: null,
        valueField: "idUsuario",
        labelField: "nombre",
        searchField: "nombre",
        placeholder: "Buscar receptores...",
        loadThrottle: 300,
        persist: false,
        restore_on_backspace: false,
        render: {
            option: function (data, escape) {
                return `<div>
                            <strong>${escape(data.nombre)}</strong><br>
                        </div>`;
            },
            item: function (data, escape) {
                return `<div>${escape(data.nombre)}</div>`;
            },
            no_results: function (data, escape) {
                return `<div class="no-results">No se encontraron resultados</div>`;
            }
        },
        load: function (query, callback) {
            fetch("/Home/BuscarResponsables?nombre=" + encodeURIComponent(query))
                .then(res => {
                    if (!res.ok) throw new Error("Error del servidor");
                    return res.json();
                })
                .then(users => {
                    callback(users);
                })
                .catch(() => {
                    callback();
                    const dropdown = document.querySelector('.ts-dropdown .no-results');
                    if (dropdown) {
                        dropdown.innerHTML = "Ocurrió un error al buscar";
                    }
                });
        }
    });

    //selectUsuariosInstance.on("item_add", function (value, item) {
    //    console.log("➕ Usuario agregado:", value);
    //});

    //selectUsuariosInstance.on("item_remove", function (value) {
    //    console.log("➖ Usuario quitado:", value);
    //});
}

$(document).on('hidden.bs.modal', function () {
    const $btnReportar = $("#btnReportar")
    const $spinner = $btnReportar.find('.spinner-border');

    $btnReportar.prop('disabled', false);
    $spinner.addClass('d-none');

    // Asegura que el scroll se restaure
    $('body').css('overflow', 'auto');
    $('body').css('padding-right', '0');
});


//const selectUsuarios = new TomSelect("#usuarios", {
//    maxItems: null,
//    valueField: "idUsuario",
//    labelField: "nombre",
//    searchField: "nombre",
//    placeholder: "Buscar usuarios...",
//    loadThrottle: 300,
//    persist: false,
//    restore_on_backspace: false,
//    render: {
//        option: function (data, escape) {
//            return `<div>
//                            <strong>${escape(data.nombre)}</strong><br>
//                        </div>`;
//        },
//        item: function (data, escape) {
//            return `<div>${escape(data.nombre)}</div>`;
//        },
//        no_results: function (data, escape) {
//            return `<div class="no-results">No se encontraron resultados</div>`;
//        }
//    },
//    load: function (query, callback) {
//        fetch("/Home/BuscarResponsables?nombre=" + encodeURIComponent(query))
//            .then(res => {
//                if (!res.ok) throw new Error("Error del servidor");
//                return res.json();
//            })
//            .then(users => {
//                callback(users);
//            })
//            .catch(() => {
//                callback();
//                const dropdown = document.querySelector('.ts-dropdown .no-results');
//                if (dropdown) {
//                    dropdown.innerHTML = "Ocurrio un error al buscar";
//                }
//            });
//    }
//});

// Para ver en consola lo que se selecciona
//document.getElementById("formUsuarios").addEventListener("submit", function (e) {
//    e.preventDefault();
//    const select = document.getElementById("usuarios");
//    const valores = Array.from(select.selectedOptions).map(opt => opt.value);
//    console.log("Usuarios seleccionados:", valores);
//    alert("IDs seleccionados: " + valores.join(", "));
//});

//selectUsuarios.on("item_add", function (value, item) {
//    console.log("➕ Usuario agregado:", value);
//});

//selectUsuarios.on("item_remove", function (value) {
//    console.log("➖ Usuario quitado:", value);
//});