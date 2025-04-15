using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiClientes.Migrations
{
    /// <inheritdoc />
    public partial class createdbcliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCliente = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstaAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
