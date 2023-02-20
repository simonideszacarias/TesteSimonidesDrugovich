using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteSimonides2.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GruposClientes_Clientes_ClienteCodigo",
                table: "GruposClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_GruposClientes_Grupos_GrupoCodigo",
                table: "GruposClientes");

            migrationBuilder.DropIndex(
                name: "IX_GruposClientes_ClienteCodigo",
                table: "GruposClientes");

            migrationBuilder.DropIndex(
                name: "IX_GruposClientes_GrupoCodigo",
                table: "GruposClientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GruposClientes_ClienteCodigo",
                table: "GruposClientes",
                column: "ClienteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_GruposClientes_GrupoCodigo",
                table: "GruposClientes",
                column: "GrupoCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_GruposClientes_Clientes_ClienteCodigo",
                table: "GruposClientes",
                column: "ClienteCodigo",
                principalTable: "Clientes",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GruposClientes_Grupos_GrupoCodigo",
                table: "GruposClientes",
                column: "GrupoCodigo",
                principalTable: "Grupos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
