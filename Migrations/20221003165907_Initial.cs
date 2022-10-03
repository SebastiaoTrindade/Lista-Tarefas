using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaTarefas.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importancia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TarefaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
