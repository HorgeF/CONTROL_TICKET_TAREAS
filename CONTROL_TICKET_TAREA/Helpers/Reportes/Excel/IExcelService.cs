namespace CONTROL_TICKET_TAREA.Helpers.Reportes.Excel
{
    public interface IExcelService<T> where T : class
    {
        byte[] GenerarExcel(List<T> data);
    }
}
