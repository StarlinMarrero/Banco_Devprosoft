using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_Devprosoft.Data.Migrations
{
    public partial class EliminarFKdePagosatablatarjeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Prestamos_Servicio_ID",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Tarjetas_Servicio_ID",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_Servicio_ID",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "Servicio_ID",
                table: "Pagos");

            migrationBuilder.AddColumn<int>(
                name: "Prestamo_ID",
                table: "Pagos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Prestamo_ID",
                table: "Pagos",
                column: "Prestamo_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Prestamos_Prestamo_ID",
                table: "Pagos",
                column: "Prestamo_ID",
                principalTable: "Prestamos",
                principalColumn: "Prestamo_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Prestamos_Prestamo_ID",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_Prestamo_ID",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "Prestamo_ID",
                table: "Pagos");

            migrationBuilder.AddColumn<int>(
                name: "Servicio_ID",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Servicio_ID",
                table: "Pagos",
                column: "Servicio_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Prestamos_Servicio_ID",
                table: "Pagos",
                column: "Servicio_ID",
                principalTable: "Prestamos",
                principalColumn: "Prestamo_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Tarjetas_Servicio_ID",
                table: "Pagos",
                column: "Servicio_ID",
                principalTable: "Tarjetas",
                principalColumn: "Tarjeta_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
