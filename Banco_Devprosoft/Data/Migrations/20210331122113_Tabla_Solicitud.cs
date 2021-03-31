using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_Devprosoft.Data.Migrations
{
    public partial class Tabla_Solicitud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo_Cuenta",
                table: "Solicitudes_Prestamos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Cuenta",
                table: "Solicitudes_Cuentas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo_Cuenta",
                table: "Solicitudes_Prestamos");

            migrationBuilder.DropColumn(
                name: "Tipo_Cuenta",
                table: "Solicitudes_Cuentas");
        }
    }
}
