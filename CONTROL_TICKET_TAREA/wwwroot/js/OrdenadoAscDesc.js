const $tabla = $('#tabla-tareas');
const $ths = $tabla.find('thead th');
const $tbody = $tabla.find('tbody');
let ordenEstado = {}; // Guarda estado por índice
let filasOriginales = $tbody.children().clone(); // Guarda el orden inicial

$ths.css('cursor', 'pointer').on('click', function () {
    const $th = $(this);
    const index = $th.index();
    const estadoActual = ordenEstado[index] || null;

    // Ciclo: null → asc → desc → null
    let nuevoEstado = null;
    if (estadoActual === null) nuevoEstado = 'asc';
    else if (estadoActual === 'asc') nuevoEstado = 'desc';
    else nuevoEstado = null;

    ordenEstado = {}; // Solo un orden activo a la vez
    ordenEstado[index] = nuevoEstado;

    // Limpiar íconos de todos los headers
    $ths.each(function () {
        const texto = $(this).text().replace(/[\u2191\u2193]/g, '').trim();
        $(this).text(texto);
    });

    const textoOriginal = $th.text().replace(/[\u2191\u2193]/g, '').trim();
    if (nuevoEstado === 'asc') {
        $th.text(textoOriginal + ' ↑');
    } else if (nuevoEstado === 'desc') {
        $th.text(textoOriginal + ' ↓');
    } else {
        // Restaurar orden original
        $tbody.empty().append(filasOriginales);
        return;
    }

    // Ordenar filas
    const $filas = $tbody.children().get();
    $filas.sort(function (a, b) {
        const aText = $(a).children().eq(index).text().trim();
        const bText = $(b).children().eq(index).text().trim();

        const aVal = parseFloat(aText.replace(',', '.')) || aText.toLowerCase();
        const bVal = parseFloat(bText.replace(',', '.')) || bText.toLowerCase();

        if (aVal < bVal) return nuevoEstado === 'asc' ? -1 : 1;
        if (aVal > bVal) return nuevoEstado === 'asc' ? 1 : -1;
        return 0;
    });

    $tbody.empty().append($filas);
});
