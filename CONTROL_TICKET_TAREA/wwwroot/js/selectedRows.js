//function actualizarVisibilidadAcciones() {
//    const acciones = document.getElementById("accionesSeleccionados");
//    const haySeleccionados = document.querySelectorAll(".row-checkbox:checked").length > 0;

//    if (haySeleccionados) {
//        acciones.classList.remove("d-none");
//        acciones.classList.add("d-flex");
//    } else {
//        acciones.classList.remove("d-flex");
//        acciones.classList.add("d-none");
//    }
//}

//// Al hacer clic en una fila, seleccionar/deseleccionar
//document.querySelectorAll("#tabla-tareas tbody tr").forEach(tr => {
//    tr.addEventListener("click", function (e) {
//        // Evitar conflicto si se hace clic en el checkbox directamente
//        if (e.target.tagName.toLowerCase() === "input") return;

//        const checkbox = this.querySelector("input[type='checkbox']");
//        checkbox.checked = !checkbox.checked;
//        this.classList.toggle("selected", checkbox.checked);

//        actualizarVisibilidadAcciones();
//    });
//});

//// Sincroniza visualmente si ya estaban seleccionadas
//document.querySelectorAll(".row-checkbox").forEach(cb => {
//    cb.closest("tr").classList.toggle("selected", cb.checked);
//    actualizarVisibilidadAcciones();
//});

//// Al usar el checkbox de seleccionar todos
//document.getElementById("checkAll").addEventListener("change", function () {
//    const isChecked = this.checked;
//    document.querySelectorAll(".row-checkbox").forEach(cb => {
//        cb.checked = isChecked;
//        cb.closest("tr").classList.toggle("selected", isChecked);
//    });
//    actualizarVisibilidadAcciones();
//});

//// Si se hace clic en el checkbox directamente, también marcar fila
//document.querySelectorAll(".row-checkbox").forEach(cb => {
//    cb.addEventListener("change", function () {
//        this.closest("tr").classList.toggle("selected", this.checked);
//        actualizarVisibilidadAcciones();
//    });
//});

//// Inicializar visibilidad si ya hay seleccionados al cargar
////actualizarVisibilidadAcciones();

//// Acción: Actualizar
//document.getElementById("btnActualizarSeleccionados").addEventListener("click", function () {
//    const seleccionados = Array.from(document.querySelectorAll(".row-checkbox:checked"))
//        .map(cb => cb.value);

//    if (seleccionados.length === 0) {
//        alert("Selecciona al menos una tarea.");
//        return;
//    }

//    // Aquí puedes hacer algo como redirigir a una vista de edición múltiple o abrir un modal
//    console.log("Actualizar IDs:", seleccionados);

//    // Ejemplo: Redirección (GET)
//    // window.location.href = `/Tareas/EditarMultiples?ids=${seleccionados.join(",")}`;

//    // Ejemplo: POST con AJAX
//    /*
//    $.post("/Tareas/ActualizarMultiples", { ids: seleccionados }, function (respuesta) {
//        location.reload();
//    });
//    */
//});

//// Acción: Eliminar
//// document.getElementById("btnEliminarSeleccionados").addEventListener("click", function () {
////     const seleccionados = Array.from(document.querySelectorAll(".row-checkbox:checked"))
////         .map(cb => cb.value);

////     if (seleccionados.length === 0) {
////         alert("Selecciona al menos una tarea.");
////         return;
////     }

////     if (!confirm("¿Estás seguro de eliminar las tareas seleccionadas?")) return;

////     // POST con AJAX
////     $.ajax({
////         url: "/Tareas/EliminarMultiples",
////         type: "POST",
////         data: { ids: seleccionados },
////         traditional: true,
////         success: function () {
////             location.reload();
////         }
////     });
//// });