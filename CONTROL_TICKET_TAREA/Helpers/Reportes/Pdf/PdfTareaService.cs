using CONTROL_TICKET_TAREA.Dtos.Respuestas;
using QuestPDF.Fluent;

namespace CONTROL_TICKET_TAREA.Helpers.Reportes.Pdf
{
    public class PdfTareaService : IPdfService<TbControlTicketTareaResponse>
    {
        public byte[] GenerarPdf(List<TbControlTicketTareaResponse> data, List<string> nombresReceptores)
        {
            var documento = new PdfTareaDocumento(data, nombresReceptores);
            return documento.GeneratePdf();
        }
    }
}
