using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApiEventosCore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EVENTO",
                columns: table => new
                {
                    EVEN_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EVEN_CANCELADO = table.Column<bool>(type: "bit", nullable: false),
                    EVEN_DATA_DE_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EVEN_DATA_FIM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EVEN_DATA_INICIO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EVEN_DESCRICAO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EVEN_HORA_FIM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EVEN_HORA_INICIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EVEN_NOME = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    EVEN_USUARIO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTO", x => x.EVEN_ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    USUA_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    USUA_DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUA_EMAIL = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    USUA_NOME = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    USUA_SENHA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    USUA_USER_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.USUA_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVENTO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
