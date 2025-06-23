using CONTROL_TICKET_TAREA.Dtos.Respuestas;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CONTROL_TICKET_TAREA.Helpers.Reportes.Pdf
{
    public class PdfTareaDocumento(List<TbControlTicketTareaResponse> tareas, List<string> nombresReceptores) : IDocument
    {
        private readonly List<TbControlTicketTareaResponse> _tareas = tareas;
        private readonly List<string> _nombresReceptores = nombresReceptores;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(20);

                    page.Header().Element(ComponenteEncabezado);
                    page.Content().Element(ComponenteContenido);
                    page.Footer().AlignRight().Text(x =>
                    {
                        x.Span("Página ").FontSize(10);
                        x.CurrentPageNumber().FontSize(10);
                        x.Span(" de ").FontSize(10);
                        x.TotalPages().FontSize(10);
                    });
                });
        }

        void ComponenteEncabezado(IContainer container)
        {
            int fontSizeTitulo = 9;
            int fontSizeTexto = 5;

            string fecRango = "No hay fechas disponibles";

            if (_tareas.Any())
            {
                DateTime fecInicio = _tareas.Min(t => t.FechaTicketTarea);
                DateTime fecFinal = _tareas.Max(t => t.FechaTicketTarea);

                if (fecInicio.Date == fecFinal.Date)
                    fecRango = $"{fecInicio:dddd dd/MM/yyyy}".ToUpper();
                else
                    fecRango = $"{fecInicio:dddd dd/MM/yyyy} - {fecFinal:dddd dd-MM-yyyy}".ToUpper();
            }

            var tecnicosForm = _nombresReceptores.Count == 0 ? "TODOS" : string.Join(", ", _nombresReceptores) + ".";

            container.Row(row =>
            {
                // Izquierda (ancho 2 de 3)
                row.RelativeItem(2).Column(column =>
                {
                    column.Spacing(7);

                    column.Item()
                        .Text("REPORTE TAREAS")
                        .FontSize(fontSizeTitulo).SemiBold().FontColor(Colors.Blue.Medium);

                    column.Item().Text(text =>
                    {
                        text.Span($"{fecRango}".ToUpper()).FontSize(fontSizeTexto);
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("TÉCNICO(S): ").SemiBold().FontSize(fontSizeTexto);
                        text.Span(tecnicosForm).FontSize(fontSizeTexto);
                    });
                });

                // Derecha (ancho 1 de 3, alineado a la derecha)
                row.RelativeItem(1).AlignRight().Column(column =>
                {
                    column.Spacing(7);

                    column.Item().Text(text =>
                    {
                        text.Span("FEC. CREACIÓN: ").SemiBold().FontSize(fontSizeTexto);
                        text.Span($"{DateTime.Now:dddd dd-MM-yyyy}".ToUpper()).FontSize(fontSizeTexto);
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("N° TAREAS ENCONTRADAS: ").SemiBold().FontSize(fontSizeTexto);
                        text.Span(_tareas.Count.ToString()).FontSize(fontSizeTexto);
                    });
                });
            });
        }

        void ComponenteContenido(IContainer container)
        {
            float fontSizeEncabezado = 5;
            float fontSizeContenido = 4.5f;

            container.PaddingVertical(10).Column(col =>         
            {
                Color colorBorder = Colors.Grey.Darken2;

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(1); // ID
                        columns.RelativeColumn(1); // GE
                        columns.RelativeColumn(1); // EMP
                        columns.RelativeColumn(1.7f); // FEC. REG
                        columns.RelativeColumn(2); // TÉCNICO
                        columns.RelativeColumn(2); // CONTACTO
                        columns.RelativeColumn(1.8f); // PRI
                        columns.RelativeColumn(0.8f); // NIV
                        columns.RelativeColumn(1.3f); // ITEMS
                        columns.RelativeColumn(); // SERIE
                        columns.RelativeColumn(2); // TIPO
                        columns.RelativeColumn(3.4f); // ITEM
                        columns.RelativeColumn(6.5f); // DESCRIPCIÓN
                        columns.RelativeColumn(2); // TICKET
                        columns.RelativeColumn(2); // ESTADO
                    });

                    table.Header(header =>
                    {
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("ID").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("GE").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("EMP").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("FEC. REG.").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("TÉCNICO").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("CONTACTO").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("PRI").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("NIV").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("ITEMS").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("SERIE").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("TIPO").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("ITEM").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("DESCRIPCIÓN").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("TICKET").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                        header.Cell().Background("#d50").Border(0.1f).BorderColor(colorBorder).Padding(2).Text("ESTADO").FontColor("#fff").AlignCenter().FontSize(fontSizeEncabezado);
                    });

                    if(_tareas.Count != 0)
                    {
                        foreach(var tarea in _tareas)
                        {
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.IdTarea.ToString()).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.SiglaGE).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.SiglaEmpresa).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text($"{tarea.FecReg:dd-MM-yyyy}").FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.Receptor).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.Contacto).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.Prioridad).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.Nivel).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.CantidadItems.ToString()).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.NSerie).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.Tipo).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.IdItemCenterDesc).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.Descripcion).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.CodTicket).FontSize(fontSizeContenido);
                            table.Cell().Border(0.1f).BorderColor(colorBorder).Padding(2).Text(tarea.Estado).FontSize(fontSizeContenido);
                        }
                    } else
                    {
                        table.Cell().ColumnSpan(15)
                            .Border(0.5f).BorderColor(colorBorder)
                            .AlignCenter().PaddingVertical(10)
                            .Text("No se encontraron tareas")
                            .FontColor(Colors.Grey.Darken1)
                            .FontSize(fontSizeContenido + 0.5f);
                    }

                     col.Spacing(10);
                });
            });

        }
    }
}
