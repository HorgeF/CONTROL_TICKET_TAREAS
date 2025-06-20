using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONTROL_TICKET_TAREA.Migrations
{
    /// <inheritdoc />
    public partial class cambiodenombrefecActporfecCierre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FEC_ACT",
                table: "TB_CONTROL_TICKET_TAREA",
                newName: "FEC_CIERRE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FEC_CIERRE",
                table: "TB_CONTROL_TICKET_TAREA",
                newName: "FEC_ACT");
        }
    }
}
