using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Churrasco.WebApi.Migrations
{
    public partial class implantacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventoChurrasco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 120, nullable: true),
                    ValorChurrasco = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ValorComBebida = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoChurrasco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    TipoDeParticipacao = table.Column<int>(nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ChurrascoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participante_EventoChurrasco_ChurrascoId",
                        column: x => x.ChurrascoId,
                        principalTable: "EventoChurrasco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participante_ChurrascoId",
                table: "Participante",
                column: "ChurrascoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participante");

            migrationBuilder.DropTable(
                name: "EventoChurrasco");
        }
    }
}
