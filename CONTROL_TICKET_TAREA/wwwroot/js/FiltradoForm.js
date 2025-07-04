﻿$(document).on("click", '.btnOk', function () {
    // Reiniciar filtros individuales
    $('input[name="prioridadInd"], input[name="nivelInd"]').prop('checked', false);
    $('button[data-target^="prioridadGrafico"], button[data-target^="nivelGrafico"]').removeClass('active btn-primary btn-outline-primary');

    // Enviar formulario
    $('#filtroForm')[0].submit();
});

$('#cboReceptor').SumoSelect({
    selectAll: true,
    search: true,
    okCancelInMulti: true,
    placeholder: "Buscar receptores...",
    searchText: 'Buscar receptores...',
    noMatch: 'No se encontraron coincidencias',
    forceCustomRendering: true
});

// Cambio de estilos al seleccionar los botones que filtran la lista
$('button[data-target]').on('click', function () {
    const $button = $(this);
    const targetId = $button.data('target').replace('#', '');
    const $checkbox = $('#' + targetId);

    if (!$checkbox.length) return;

    const esPrioridadGrafico = targetId.startsWith('prioridadGrafico');
    const esNivelGrafico = targetId.startsWith('nivelGrafico');
    const esGrafico = esPrioridadGrafico || esNivelGrafico;
    const esComun = !esGrafico;

    const $cboFiltradoEstado = $('#cboFiltroEstado');
    const $cboReceptor = $('#cboReceptor');

    if (esGrafico) {
        const isChecked = $checkbox.prop('checked');

        // Si ya estaba activo, lo desactiva
        if (isChecked) {
            $checkbox.prop('checked', false);
            $button.removeClass('active btn-primary').addClass('btn-outline-primary');
        } else {
            // Desactiva todos los gráficos
            $('input[name="prioridadInd"], input[name="nivelInd"]').prop('checked', false);
            $('button[data-target^="prioridadGrafico"], button[data-target^="nivelGrafico"]').removeClass('active btn-primary btn-outline-primary');

            $cboFiltradoEstado.val('0');
            $cboReceptor.val('');

            // Marca este nuevo gráfico
            $checkbox.prop('checked', true);
            $button.addClass('active btn-primary').removeClass('btn-outline-primary');

            // Desmarca todos los comunes
            $('input[name="prioridad"], input[name="nivel"]').prop('checked', false);
            $('button[data-target^="prioridad"]:not([data-target^="prioridadGrafico"]), button[data-target^="nivel"]:not([data-target^="nivelGrafico"])')
                .removeClass('active btn-primary btn-outline-primary');
        }
    }

    if (esComun) {
        // ✅ Permitir múltiples comunes, pero desactivar cualquier gráfico
        const isChecked = $checkbox.prop('checked');
        $checkbox.prop('checked', !isChecked);
        $button.toggleClass('active btn-primary btn-outline-primary');

        // Desmarcar todos los gráficos
        $('input[name="prioridadInd"], input[name="nivelInd"]').prop('checked', false);
        $('button[data-target^="prioridadGrafico"], button[data-target^="nivelGrafico"]')
            .removeClass('active btn-primary btn-outline-primary');
    }

    // Finalmente, enviar el formulario
    $('#filtroForm')[0].submit();
});

$("#cboFiltroEstado").on('change', function () {

    $('input[name="prioridadInd"], input[name="nivelInd"]').prop('checked', false);
    $('button[data-target^="prioridadGrafico"], button[data-target^="nivelGrafico"]').removeClass('active btn-primary btn-outline-primary');

    $('#filtroForm')[0].submit();
});
