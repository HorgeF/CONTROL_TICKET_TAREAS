using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONTROL_TICKET_TAREA.Migrations
{
    /// <inheritdoc />
    public partial class CampoDNIAgregado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "TB_CONTROL_TICKET_TAREA",
                type: "varchar(8)",
                unicode: false,
                maxLength: 8,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNI",
                table: "TB_CONTROL_TICKET_TAREA");
        }
    }
}
