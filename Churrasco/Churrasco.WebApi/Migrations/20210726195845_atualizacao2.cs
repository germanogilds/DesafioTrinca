using Microsoft.EntityFrameworkCore.Migrations;

namespace Churrasco.WebApi.Migrations
{
    public partial class atualizacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participante_EventoChurrasco_EventoChurrascoId",
                table: "Participante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participante",
                table: "Participante");

            migrationBuilder.DropIndex(
                name: "IX_Participante_EventoChurrascoId",
                table: "Participante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventoChurrasco",
                table: "EventoChurrasco");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "ChurrascoId",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "EventoChurrascoId",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventoChurrasco");

            migrationBuilder.AddColumn<int>(
                name: "IdParticipante",
                table: "Participante",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EventoChurrascoIdEventoChurrasco",
                table: "Participante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEventoChurrasco",
                table: "Participante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEventoChurrasco",
                table: "EventoChurrasco",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participante",
                table: "Participante",
                column: "IdParticipante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventoChurrasco",
                table: "EventoChurrasco",
                column: "IdEventoChurrasco");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_EventoChurrascoIdEventoChurrasco",
                table: "Participante",
                column: "EventoChurrascoIdEventoChurrasco");

            migrationBuilder.AddForeignKey(
                name: "FK_Participante_EventoChurrasco_EventoChurrascoIdEventoChurrasco",
                table: "Participante",
                column: "EventoChurrascoIdEventoChurrasco",
                principalTable: "EventoChurrasco",
                principalColumn: "IdEventoChurrasco",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participante_EventoChurrasco_EventoChurrascoIdEventoChurrasco",
                table: "Participante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participante",
                table: "Participante");

            migrationBuilder.DropIndex(
                name: "IX_Participante_EventoChurrascoIdEventoChurrasco",
                table: "Participante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventoChurrasco",
                table: "EventoChurrasco");

            migrationBuilder.DropColumn(
                name: "IdParticipante",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "EventoChurrascoIdEventoChurrasco",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "IdEventoChurrasco",
                table: "Participante");

            migrationBuilder.DropColumn(
                name: "IdEventoChurrasco",
                table: "EventoChurrasco");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Participante",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ChurrascoId",
                table: "Participante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventoChurrascoId",
                table: "Participante",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventoChurrasco",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participante",
                table: "Participante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventoChurrasco",
                table: "EventoChurrasco",
                column: "Id");

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
    }
}
