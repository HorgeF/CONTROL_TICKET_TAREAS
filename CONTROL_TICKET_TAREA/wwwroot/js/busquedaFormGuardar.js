// RESPONSABLE

$(document).on('input', '#txtResponsable', function () {
    let nombre = $(this).val();
    $('#IdReceptor').val("0");

    if (nombre.length < 3) {
        $('#suggestions-receptor').empty();
        return;
    }

    $.get('/Home/BuscarResponsables', { nombre: nombre }, function (data) {
        let suggestions = $('#suggestions-receptor');
        suggestions.empty();    

        data.forEach(item => {
            suggestions.append(`<a href="#" class="list-group-item list-group-item-action" data-id="${item.idUsuario}">${item.nombre}</a>`);
        });
    });
});

// Click con el mouse
$(document).on('click', '#suggestions-receptor a', function (e) {
    e.preventDefault();
    $('#txtResponsable').val($(this).text());
    $('#IdReceptor').val($(this).data('id'));
    $('#suggestions-receptor').empty();
});

// Ocultar sugerencias si se hace clic fuera
$(document).on('click',function (e) {
    if (!$(e.target).closest('#suggestions-receptor, #txtResponsable').length) {
        $('#suggestions-receptor').empty();
    }
});

// GRUPO ECONÓMICO

$(document).on('input', '#txtGE', function () {
    let nombre = $(this).val();
    $('#IdGE').val("0");

    if (nombre.length < 2) {
        $('#suggestions-GE').empty();
        return;
    }

    $.get('/Home/BuscarGE', { nombre: nombre }, function (data) {
        let suggestions = $('#suggestions-GE');
        suggestions.empty();

        data.forEach(item => {
            suggestions.append(`<a href="#" class="list-group-item list-group-item-action" data-id="${item.idGe}">${item.nombre}</a>`);
        });
    });
});
    
// Seleccionar GE del autocompletado
$(document).on('click', '#suggestions-GE a', function (e) {
    e.preventDefault();

    const idGE = $(this).data('id');
    const nombreGE = $(this).text();

    $('#txtGE').val(nombreGE);
    $('#IdGE').val(idGE);
    $('#suggestions-GE').empty();

    // Cargar empresas asociadas
    $('#cboEntidad').empty().append('<option value="0">Cargando...</option>');

    $.ajax({
        url: '/Home/ListarEmpresasParaSelect',
        type: 'GET',
        data: { grupoId: idGE },
        success: function (data) {
            $('#cboEntidad').empty().append('<option value="0">-SELECCIONAR-</option>');
            data.forEach(function (empresa) {
                $('#cboEntidad').append(`<option value="${empresa.value}">${empresa.text}</option>`);
            });
        },
        error: function () {
            $('#cboEntidad').empty().append('<option value="0">Error al cargar</option>');
        }
    });
});

// Ocultar sugerencias si se hace clic fuera
$(document).on('click', function (e) {
    if (!$(e.target).closest('#suggestions-GE, #txtGE').length) {
        $('#suggestions-GE').empty();
    }
});

// ITEMS

$(document).on('input', '#txtItem', function () {
    let nombre = $(this).val();
    $('#IdItemCenter').val("0");
    $("#txtNuevoItem").prop('disabled', false);

    if (nombre.length < 3) {
        $('#suggestions-item').empty();
        return;
    }

    $.get('/Home/BuscarItems', { nombre: nombre }, function (data) {
        let suggestions = $('#suggestions-item');
        suggestions.empty();

        data.forEach(item => {
            suggestions.append(`<a href="#" class="list-group-item list-group-item-action" data-id="${item.idItemCenter}">${item.descripcion}</a>`);
        });
    });
});

// Click con el mouse
$(document).on('click', '#suggestions-item a', function (e) {
    e.preventDefault();
    const $txtNuevoItem = $("#txtNuevoItem");
    $txtNuevoItem.prop('disabled', true);
    $txtNuevoItem.val('');
    $('#txtItem').val($(this).text());
    $('#IdItemCenter').val($(this).data('id'));
    $('#suggestions-item').empty();
});

// Ocultar sugerencias si se hace clic fuera
$(document).on('click', function (e) {
    if (!$(e.target).closest('#suggestions-item, #txtItem').length) {
        $('#suggestions-item').empty();
    }
});

