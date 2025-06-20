window.AlertaUtils = window.AlertaUtils || {};

AlertaUtils.mostrar = function (tipo, titulo, tiempo = 2000) {
    Swal.fire({
        toast: true,
        position: 'top-end',
        icon: tipo,
        title: titulo,
        showConfirmButton: false,
        timer: tiempo,
        timerProgressBar: true,
    });
}