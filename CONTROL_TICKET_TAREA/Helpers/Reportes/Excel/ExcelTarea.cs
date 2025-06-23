using ClosedXML.Excel;
using CONTROL_TICKET_TAREA.Dtos.Respuestas;

namespace CONTROL_TICKET_TAREA.Helpers.Reportes.Excel
{
    public class ExcelTarea : IExcelService<TbControlTicketTareaResponse>
    {
        public byte[] GenerarExcel(List<TbControlTicketTareaResponse> data)
        {
            using var workbook = new XLWorkbook();
            var hoja = workbook.Worksheets.Add("Tareas");

            // Encabezados
            hoja.Cell("A1").SetValue("ID");
            hoja.Cell("B1").SetValue("GE");
            hoja.Cell("C1").SetValue("EMP");
            hoja.Cell("D1").SetValue("FEC. REG.");
            hoja.Cell("E1").SetValue("TÉCNICO");
            hoja.Cell("F1").SetValue("CONTACTO");
            hoja.Cell("G1").SetValue("PRI");
            hoja.Cell("H1").SetValue("NIV");
            hoja.Cell("I1").SetValue("ITEMS");
            hoja.Cell("J1").SetValue("SERIE");
            hoja.Cell("K1").SetValue("TIPO");
            hoja.Cell("L1").SetValue("ITEM");
            hoja.Cell("M1").SetValue("DESCRIPCIÓN");
            hoja.Cell("N1").SetValue("TICKET");
            hoja.Cell("O1").SetValue("ESTADO");

            hoja.Cell("A2").InsertData(data.Select(t => t.IdTarea).AsEnumerable());
            hoja.Cell("B2").InsertData(data.Select(t => t.SiglaGE).AsEnumerable());
            hoja.Cell("C2").InsertData(data.Select(t => t.SiglaEmpresa).AsEnumerable());
            hoja.Cell("D2").InsertData(data.Select(t => $"{t.FecReg:dd-MM-yyyy}").AsEnumerable());
            hoja.Cell("E2").InsertData(data.Select(t => t.Receptor).AsEnumerable());
            hoja.Cell("F2").InsertData(data.Select(t => t.Contacto).AsEnumerable());
            hoja.Cell("G2").InsertData(data.Select(t => t.Prioridad).AsEnumerable());
            hoja.Cell("H2").InsertData(data.Select(t => t.Nivel).AsEnumerable());
            hoja.Cell("I2").InsertData(data.Select(t => t.CantidadItems).AsEnumerable());
            hoja.Cell("J2").InsertData(data.Select(t => t.NSerie).AsEnumerable());
            hoja.Cell("K2").InsertData(data.Select(t => t.Tipo).AsEnumerable());
            hoja.Cell("L2").InsertData(data.Select(t => t.IdItemCenterDesc).AsEnumerable());
            hoja.Cell("M2").InsertData(data.Select(t => t.Descripcion).AsEnumerable());
            hoja.Cell("N2").InsertData(data.Select(t => t.CodTicket).AsEnumerable());
            hoja.Cell("O2").InsertData(data.Select(t => t.Estado).AsEnumerable());

            var tabla = hoja.Range($"A1:O{data.Count + 1}").CreateTable("Tareas");
            tabla.Theme = XLTableTheme.TableStyleLight16;

            // Alinear todo el contenido en la parte superior
            var rangoDatos = hoja.Range($"A2:O{data.Count + 1}");
            rangoDatos.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;

            var rangoEncabezado = hoja.Range($"A1:O1");
            rangoEncabezado.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Activar ajuste de texto solo en columna M (DESCRIPCIÓN)
            var columnaDescripcion = hoja.Range($"M2:M{data.Count + 1}");
            columnaDescripcion.Style.Alignment.WrapText = true;

            hoja.Columns().AdjustToContents(); // Ajustar ancho
            hoja.ShowGridLines = false; // Quitar lineas de cuadrícula

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
