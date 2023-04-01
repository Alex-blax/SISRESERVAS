using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SISRESERVAS.Migrations
{
    /// <inheritdoc />
    public partial class migra1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    departamentoid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombredep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.departamentoid);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "viaje",
                columns: table => new
                {
                    viajeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    asientosdis = table.Column<int>(type: "int", nullable: false),
                    conductor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    horario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_viaje", x => x.viajeid);
                });

            migrationBuilder.CreateTable(
                name: "departamentoviaje",
                columns: table => new
                {
                    Iddevia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    viajeid = table.Column<int>(type: "int", nullable: false),
                    departamentoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentoviaje", x => x.Iddevia);
                    table.ForeignKey(
                        name: "FK_departamentoviaje_departamento_departamentoid",
                        column: x => x.departamentoid,
                        principalTable: "departamento",
                        principalColumn: "departamentoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_departamentoviaje_viaje_viajeid",
                        column: x => x.viajeid,
                        principalTable: "viaje",
                        principalColumn: "viajeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    departamentoviajeIddevia = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reserva_departamentoviaje_departamentoviajeIddevia",
                        column: x => x.departamentoviajeIddevia,
                        principalTable: "departamentoviaje",
                        principalColumn: "Iddevia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reserva_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departamentoviaje_departamentoid",
                table: "departamentoviaje",
                column: "departamentoid");

            migrationBuilder.CreateIndex(
                name: "IX_departamentoviaje_viajeid",
                table: "departamentoviaje",
                column: "viajeid");

            migrationBuilder.CreateIndex(
                name: "IX_reserva_departamentoviajeIddevia",
                table: "reserva",
                column: "departamentoviajeIddevia");

            migrationBuilder.CreateIndex(
                name: "IX_reserva_UsuarioId",
                table: "reserva",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reserva");

            migrationBuilder.DropTable(
                name: "departamentoviaje");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "viaje");
        }
    }
}
