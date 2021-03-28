using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_Devprosoft.Data.Migrations
{
    public partial class PropiedadesagregadasaApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "AspNetUsers");
        }
    }
}
