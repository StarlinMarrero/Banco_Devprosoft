using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_Devprosoft.Data.Migrations
{
    public partial class Cambiospendientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Monto",
                table: "Transferencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Solicitudes_Prestamos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Solicitudes_Cuentas",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transferencias_Cuenta_Destino_ID",
            //    table: "Transferencias",
            //    column: "Cuenta_Destino_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_Cuenta_Origen_ID",
                table: "Transferencias",
                column: "Cuenta_Origen_ID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Transferencias_Cuentas_Bancarias_Cuenta_Destino_ID",
            //    table: "Transferencias",
            //    column: "Cuenta_Destino_ID",
            //    principalTable: "Cuentas_Bancarias",
            //    principalColumn: "Cuenta_ID",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Cuentas_Bancarias_Cuenta_Origen_ID",
                table: "Transferencias",
                column: "Cuenta_Origen_ID",
                principalTable: "Cuentas_Bancarias",
                principalColumn: "Cuenta_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Transferencias_Cuentas_Bancarias_Cuenta_Destino_ID",
            //    table: "Transferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Cuentas_Bancarias_Cuenta_Origen_ID",
                table: "Transferencias");

            //migrationBuilder.DropIndex(
            //    name: "IX_Transferencias_Cuenta_Destino_ID",
            //    table: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_Cuenta_Origen_ID",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Solicitudes_Prestamos");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Solicitudes_Cuentas");
        }
    }
}
