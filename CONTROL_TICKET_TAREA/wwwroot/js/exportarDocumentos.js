$(document).on('click', '#btnExportarExcelTarea', function () {
    const query = $('#filtroForm').serialize();
    window.location.href = "/TicketTarea/ExportarExcel?" + query;
});

$(document).on('click', '#btnExportarPdfTarea', function () {
    const query = $('#filtroForm').serialize();
    window.location.href = "/TicketTarea/ExportarPdf?" + query;
});