using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_Devprosoft.Data.Migrations
{
    public partial class CreaciondeTablasPrestamossolicitudCuentasTarjeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Creacion",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Nacimiento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Ocupacion",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sueldo",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Trabaja",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Cuentas_Bancarias",
                columns: table => new
                {
                    Cuenta_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Cuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    Cerrada = table.Column<bool>(type: "bit", nullable: false),
                    Monto_Maximo = table.Column<int>(type: "int", nullable: false),
                    Fecha_De_Corte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Limite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Cierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Propietario_ID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas_Bancarias", x => x.Cuenta_ID);
                    table.ForeignKey(
                        name: "FK_Cuentas_Bancarias_AspNetUsers_Propietario_ID",
                        column: x => x.Propietario_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Prestamo_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Propietario_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_De_Corte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_de_Pagos = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Aprobacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_De_Cierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Proyectada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pago_Pendiente = table.Column<bool>(type: "bit", nullable: false),
                    Monto_Aprobado = table.Column<int>(type: "int", nullable: false),
                    Monto_Mensual = table.Column<int>(type: "int", nullable: false),
                    Cuotas = table.Column<int>(type: "int", nullable: false),
                    Tasa_de_Interes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Prestamo_ID);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes_Cuentas",
                columns: table => new
                {
                    Solicitud_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_De_Cuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuario_Registrado = table.Column<bool>(type: "bit", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empleado = table.Column<bool>(type: "bit", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<int>(type: "int", nullable: false),
                    Ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Cierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Solicitud = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes_Cuentas", x => x.Solicitud_ID);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes_Prestamos",
                columns: table => new
                {
                    Solicitud_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto_Solicitado = table.Column<int>(type: "int", nullable: false),
                    Plazo_Solicitado = table.Column<int>(type: "int", nullable: false),
                    Aprobado = table.Column<bool>(type: "bit", nullable: false),
                    Aprobado_Por = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuario_Registrado = table.Column<bool>(type: "bit", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empleado = table.Column<bool>(type: "bit", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<int>(type: "int", nullable: false),
                    Ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Cierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Solicitud = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes_Prestamos", x => x.Solicitud_ID);
                });

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Transferencia_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuenta_Origen_ID = table.Column<int>(type: "int", nullable: false),
                    Cuenta_Destino_ID = table.Column<int>(type: "int", nullable: false),
                    Fecha_Transaccion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Transferencia_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    Tarjeta_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_Tarjeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Emision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuenta_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Tarjeta_ID);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Cuentas_Bancarias_Cuenta_ID",
                        column: x => x.Cuenta_ID,
                        principalTable: "Cuentas_Bancarias",
                        principalColumn: "Cuenta_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Pago_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servicio_Pagado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuenta_Origen_ID = table.Column<int>(type: "int", nullable: false),
                    Monto_Parcial = table.Column<int>(type: "int", nullable: false),
                    Mora = table.Column<int>(type: "int", nullable: false),
                    Monto_Total = table.Column<int>(type: "int", nullable: false),
                    Fecha_Pago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Servicio_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Pago_ID);
                    table.ForeignKey(
                        name: "FK_Pagos_Prestamos_Servicio_ID",
                        column: x => x.Servicio_ID,
                        principalTable: "Prestamos",
                        principalColumn: "Prestamo_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Tarjetas_Servicio_ID",
                        column: x => x.Servicio_ID,
                        principalTable: "Tarjetas",
                        principalColumn: "Tarjeta_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_Bancarias_Propietario_ID",
                table: "Cuentas_Bancarias",
                column: "Propietario_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Servicio_ID",
                table: "Pagos",
                column: "Servicio_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_Cuenta_ID",
                table: "Tarjetas",
                column: "Cuenta_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Solicitudes_Cuentas");

            migrationBuilder.DropTable(
                name: "Solicitudes_Prestamos");

            migrationBuilder.DropTable(
                name: "Transferencias");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Cuentas_Bancarias");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fecha_Creacion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fecha_Nacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ocupacion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sueldo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Trabaja",
                table: "AspNetUsers");
        }
    }
}
