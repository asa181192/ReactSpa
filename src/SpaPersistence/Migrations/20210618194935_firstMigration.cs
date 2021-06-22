using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaPersistence.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    AlumnoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Apellidos = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FotoPerfil = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.AlumnoId);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FotoPortada = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Apellidos = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Grado = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FotoPerfil = table.Column<string>(unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Puntaje = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentario_Alumno",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "AlumnoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Curso",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Precio",
                columns: table => new
                {
                    PrecioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioActual = table.Column<decimal>(type: "numeric(14, 2)", nullable: true),
                    Promocion = table.Column<decimal>(type: "numeric(14, 2)", nullable: true),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio", x => x.PrecioId);
                    table.ForeignKey(
                        name: "FK_Precio_Curso",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CursoInstructor",
                columns: table => new
                {
                    CursoInstructorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoId = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoInstructor", x => x.CursoInstructorId);
                    table.ForeignKey(
                        name: "FK_CursoInstructor_Curso",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CursoInstructor_Instructor",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_AlumnoId",
                table: "Comentario",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_CursoId",
                table: "Comentario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoInstructor_CursoId",
                table: "CursoInstructor",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoInstructor_InstructorId",
                table: "CursoInstructor",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_CursoId",
                table: "Precio",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "CursoInstructor");

            migrationBuilder.DropTable(
                name: "Precio");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
