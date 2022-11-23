using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresas.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    IDEMPRESA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEFANTASIA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RAZAOSOCIAL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.IDEMPRESA);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_CNPJ",
                table: "EMPRESA",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_RAZAOSOCIAL",
                table: "EMPRESA",
                column: "RAZAOSOCIAL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPRESA");
        }
    }
}
