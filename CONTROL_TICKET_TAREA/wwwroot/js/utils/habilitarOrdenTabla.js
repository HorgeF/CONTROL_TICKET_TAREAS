window.TablaUtils = window.TablaUtils || {};

TablaUtils.habilitarOrdenTabla = function ($tabla) {
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
            $tbody.empty().append(filasOriginales);
            return;
        }

        // Ordenar filas
        const $filas = $tbody.children().get();
        $filas.sort(function (a, b) {
            const aText = $(a).children().eq(index).text().trim();
            const bText = $(b).children().eq(index).text().trim();

            let aVal = aText;
            let bVal = bText;

            // Intenta parsear como fecha (formato dd/MM/yyyy o dd-MM-yyyy)
            const fechaRegex = /^(\d{2})[\/\-](\d{2})[\/\-](\d{4})$/;

            if (fechaRegex.test(aText) && fechaRegex.test(bText)) {
                const aParts = aText.match(fechaRegex);
                const bParts = bText.match(fechaRegex);
                if (aParts && bParts) {
                    aVal = new Date(aParts[3], aParts[2] - 1, aParts[1]); // yyyy, MM-1, dd
                    bVal = new Date(bParts[3], bParts[2] - 1, bParts[1]);
                }
            } else {
                // Fallback a número o texto
                aVal = parseFloat(aText.replace(',', '.')) || aText.toLowerCase();
                bVal = parseFloat(bText.replace(',', '.')) || bText.toLowerCase();
            }

            if (aVal < bVal) return nuevoEstado === 'asc' ? -1 : 1;
            if (aVal > bVal) return nuevoEstado === 'asc' ? 1 : -1;
            return 0;
        });

        $tbody.empty().append($filas);
    });
}