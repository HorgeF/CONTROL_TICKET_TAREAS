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

                    page.Header().Element(container =>
                    {
                        container.ShowOnce().Element(ComponenteEncabezado);
                    });
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
                        columns.RelativeColumn(1); // PROY
                        columns.RelativeColumn(1); // SUB_PROY
                        columns.RelativeColumn(1.7f); // FEC. REG
                        columns.RelativeColumn(2); // TÉCNICO
                        columns.RelativeColumn(2.5f); // CONTACTO
                        columns.RelativeColumn(1.3f); // PRI
                        columns.RelativeColumn(0.8f); // NIV
                        columns.RelativeColumn(1f); // ITEMS
                        columns.RelativeColumn(2); // SERIE
                        columns.RelativeColumn(2.5f); // TIPO
                        columns.RelativeColumn(3.4f); // ITEM
                        columns.RelativeColumn(6.5f); // DESCRIPCIÓN
                        columns.RelativeColumn(2); // TICKET
                        columns.RelativeColumn(2); // ESTADO
                    });

                    var columnas = new[]
                    {
                        "ID", "GE", "EMP","PRO", "SPRO" , "FEC. REG.", "TÉCNICO", "CONTACTO", "PRI", "NIV",
                        "ITEMS", "SERIE", "TIPO", "ITEM", "DESCRIPCIÓN", "TICKET", "ESTADO"
                    };


                    table.Header(header =>
                    {
                        foreach (var titulo in columnas)
                        {
                            header.Cell()
                                .Background("#d50")
                                .Border(0.1f).BorderColor(colorBorder)
                                .Padding(2)
                                .Text(titulo)
                                .FontColor("#fff")
                                .AlignCenter()
                                .FontSize(fontSizeEncabezado);
                        }
                    });

                    if (_tareas.Count != 0)
                    {
                        foreach(var tarea in _tareas)
                        {
                            DibujarFila(table, tarea.IdTarea.ToString());
                            DibujarFila(table, tarea.SiglaGE);
                            DibujarFila(table, tarea.SiglaEmpresa);
                            DibujarFila(table, tarea.SiglaProyecto);
                            DibujarFila(table, tarea.SiglaSubProyecto);
                            DibujarFila(table, $"{tarea.FecReg:dd-MM-yyyy}");
                            DibujarFila(table, tarea.Receptor);
                            DibujarFila(table, tarea.Contacto);
                            DibujarFila(table, tarea.Prioridad);
                            DibujarFila(table, tarea.Nivel);
                            DibujarFila(table, tarea.CantidadItems.ToString());
                            DibujarFila(table, tarea.NSerie);
                            DibujarFila(table, tarea.Tipo);
                            DibujarFila(table, tarea.IdItemCenterDesc);
                            DibujarFila(table, tarea.Descripcion);
                            DibujarFila(table, tarea.CodTicket);
                            DibujarFila(table, tarea.Estado);
                        }
                    } else
                    {
                        table.Cell().ColumnSpan(17)
                            .Border(0.5f).BorderColor(colorBorder)
                            .AlignCenter().PaddingVertical(10)
                            .Text("No se encontraron tareas")
                            .FontColor(Colors.Grey.Darken1)
                            .FontSize(fontSizeContenido + 0.5f);
                    }

                     col.Spacing(10);
                });
            });

            void DibujarFila(TableDescriptor table, string? data)
            {
                table.Cell().Border(0.1f).BorderColor(Colors.Grey.Darken2).Padding(2).Text(data).FontSize(4.5f);
            }

        }
    }
}
