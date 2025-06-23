$(document).on('click', '#btnExportarExcelTarea', function () {
    const query = $('#filtroForm').serialize();
    window.location.href = "/Home/ExportarExcelReporteTarea?" + query;
});

$(document).on('click', '#btnExportarPdfTarea', function () {
    const query = $('#filtroForm').serialize();
    window.location.href = "/Home/ExportarPdfReporteTarea?" + query;
});