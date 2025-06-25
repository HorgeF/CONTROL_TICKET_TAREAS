using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CONTROL_TICKET_TAREA.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposIdProyectoyIdSubProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_PROYECTO",
                table: "TB_CONTROL_TICKET_TAREA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_SUB_PROYECTO",
                table: "TB_CONTROL_TICKET_TAREA",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_PROYECTO",
                table: "TB_CONTROL_TICKET_TAREA");

            migrationBuilder.DropColumn(
                name: "ID_SUB_PROYECTO",
                table: "TB_CONTROL_TICKET_TAREA");
        }
    }
}
