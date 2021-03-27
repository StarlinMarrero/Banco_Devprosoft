using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_Devprosoft.Data.Migrations
{
    public partial class PropiedadesenApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "Monto",
            //    table: "Transferencias",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Salario",
                table: "Solicitudes_Prestamos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AddColumn<string>(
            //    name: "Correo",
            //    table: "Solicitudes_Prestamos",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Salario",
                table: "Solicitudes_Cuentas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AddColumn<string>(
            //    name: "Correo",
            //    table: "Solicitudes_Cuentas",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacto_1",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacto_2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transferencias_Cuenta_Origen_ID",
            //    table: "Transferencias",
            //    column: "Cuenta_Origen_ID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Transferencias_Cuentas_Bancarias_Cuenta_Origen_ID",
            //    table: "Transferencias",
            //    column: "Cuenta_Origen_ID",
            //    principalTable: "Cuentas_Bancarias",
            //    principalColumn: "Cuenta_ID",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Transferencias_Cuentas_Bancarias_Cuenta_Origen_ID",
            //    table: "Transferencias");

            //migrationBuilder.DropIndex(
            //    name: "IX_Transferencias_Cuenta_Origen_ID",
            //    table: "Transferencias");

            //migrationBuilder.DropColumn(
            //    name: "Monto",
            //    table: "Transferencias");

            //migrationBuilder.DropColumn(
            //    name: "Correo",
            //    table: "Solicitudes_Prestamos");

            //migrationBuilder.DropColumn(
            //    name: "Correo",
            //    table: "Solicitudes_Cuentas");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Contacto_1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Contacto_2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Salario",
                table: "Solicitudes_Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Salario",
                table: "Solicitudes_Cuentas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
