using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pilotos.Migrations
{
    /// <inheritdoc />
    public partial class InitialPiloto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nacionalidades",
                columns: table => new
                {
                    NacionalidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nacionalidades", x => x.NacionalidadId);
                });

            migrationBuilder.CreateTable(
                name: "pilotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NacionalidadId = table.Column<int>(type: "int", nullable: false),
                    CantHorasVuelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pilotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pilotos_nacionalidades_NacionalidadId",
                        column: x => x.NacionalidadId,
                        principalTable: "nacionalidades",
                        principalColumn: "NacionalidadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "nacionalidades",
                columns: new[] { "NacionalidadId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Argentino" },
                    { 2, "Uruguayo" },
                    { 3, "Chileno" }
                });

            migrationBuilder.InsertData(
                table: "pilotos",
                columns: new[] { "Id", "CantHorasVuelo", "Email", "NacionalidadId", "Name", "Password" },
                values: new object[,]
                {
                    { 1, 123, "MANU@UNAM", 1, "Manu", "qweqweqwe" },
                    { 2, 111, "ggg@ggg", 3, "Guille", "123123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pilotos_NacionalidadId",
                table: "pilotos",
                column: "NacionalidadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pilotos");

            migrationBuilder.DropTable(
                name: "nacionalidades");
        }
    }
}
