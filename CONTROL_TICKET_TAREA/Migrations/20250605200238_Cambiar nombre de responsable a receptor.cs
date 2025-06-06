using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONTROL_TICKET_TAREA.Migrations
{
    /// <inheritdoc />
    public partial class Cambiarnombrederesponsableareceptor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                    name: "ID_RESPONSABLE",
                    table: "TB_CONTROL_TICKET_TAREA",
                    newName: "ID_RECEPTOR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "ID_RECEPTOR",
            table: "TB_CONTROL_TICKET_TAREA",
            newName: "ID_RESPONSABLE");
        }
    }
}
