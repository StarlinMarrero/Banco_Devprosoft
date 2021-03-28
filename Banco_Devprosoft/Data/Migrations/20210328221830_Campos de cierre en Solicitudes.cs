using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_Devprosoft.Data.Migrations
{
    public partial class CamposdecierreenSolicitudes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cerrada",
                table: "Solicitudes_Prestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cerrada",
                table: "Solicitudes_Cuentas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cerrada",
                table: "Solicitudes_Prestamos");

            migrationBuilder.DropColumn(
                name: "Cerrada",
                table: "Solicitudes_Cuentas");
        }
    }
}
