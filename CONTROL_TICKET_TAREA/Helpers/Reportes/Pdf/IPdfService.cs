namespace CONTROL_TICKET_TAREA.Helpers.Reportes.Pdf
{
    public interface IPdfService<T> where T : class
    {
        byte[] GenerarPdf(List<T> data, List<string> nombresReceptores);
    }
}
