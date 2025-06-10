$(function () {
    $("#tabla-tareas tbody").sortable({
        helper: fixHelper,
        update: function (event, ui) {
            let orden = [];
            $("#tabla-tareas tbody tr").each(function () {
                orden.push($(this).data("id")); // data-id del tr
            });

            console.log("Nuevo orden:", orden);

            // Ejemplo: enviar al backend
            /*
            $.post("/ruta/ordenar", { orden: orden }, function(response) {
                console.log("Orden guardado");
            });
            */
        }
    });

    // Mantiene el ancho de las celdas al arrastrar
    var fixHelper = function (e, ui) {
        ui.children().each(function () {
            $(this).width($(this).width());
        });
        return ui;
    };
});