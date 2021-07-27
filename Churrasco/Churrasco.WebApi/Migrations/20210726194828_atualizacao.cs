using Microsoft.EntityFrameworkCore.Migrations;

namespace Churrasco.WebApi.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participante_EventoChurrasco_ChurrascoId",
                table: "Participante");

            migrationBuilder.DropIndex(
                name: "IX_Participante_ChurrascoId",
                table: "Participante");

            migrationBuilder.AddColumn<int>(
                name: "EventoChurrascoId",
                table: "Participante",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participante_EventoChurrascoId",
                table: "Participante",
                column: "EventoChurrascoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participante_EventoChurrasco_EventoChurrascoId",
                table: "Participante",
                column: "EventoChurrascoId",
                principalTable: "EventoChurrasco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participante_EventoChurrasco_EventoChurrascoId",
                table: "Participante");

            migrationBuilder.DropIndex(
                name: "IX_Participante_EventoChurrascoId",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "EventoChurrascoId",
                table: "Participante");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_ChurrascoId",
                table: "Participante",
                column: "ChurrascoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participante_EventoChurrasco_ChurrascoId",
                table: "Participante",
                column: "ChurrascoId",
                principalTable: "EventoChurrasco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
