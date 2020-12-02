using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSI.TI.GestaoEscolar.Data.Migrations
{
    public partial class Matriculas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Alunos");

            migrationBuilder.AlterColumn<Guid>(
                name: "TurmaId",
                table: "Disciplinas",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    AlunoId = table.Column<Guid>(nullable: false),
                    TurmaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => new { x.AlunoId, x.TurmaId });
                    table.ForeignKey(
                        name: "FK_Matriculas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_TurmaId",
                table: "Matriculas",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.AlterColumn<Guid>(
                name: "TurmaId",
                table: "Disciplinas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TurmaId",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
