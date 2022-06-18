using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    public partial class Biblioteca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDeAlquileres",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDeAlquileres", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Edicion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaAlquiler = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_Cliente_Cliente",
                        column: x => x.Cliente,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_EstadoDeAlquileres_Estado",
                        column: x => x.Estado,
                        principalTable: "EstadoDeAlquileres",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_Libros_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Libros",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Reservado" },
                    { 2, "Alquilado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "ISBN", "Autor", "Edicion", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "8445071866", "Cortazar", "1995", "Ediciones Minotauro", "https://picture/sdfdf.jpg", 10, "Casa Tomada" },
                    { "978-84-206-7273-1", "Bioy Casares", "2022", "Alianza Editorial", "https://static.cegal/9788420/9067273.gif", 10, "La invención de Morel" },
                    { "9783150197882", "Borges", "2000", "Emece", "https://isbn/9789500421300-es-300.jpg", 10, "La biblioteca de Babel" },
                    { "9786124507724", "Sabato", "1", "Booket", "https://images/b564d07e519e687f9d51e4.jpg", 10, "El túnel" },
                    { "9788420673615", "Bioy Casares", "2012", "Alianza Editorial", "https://imagessl5/9788420673615.jpg", 10, "El sueño de los héroes" },
                    { "9788432248450", "Neruda", "2012", "Austral", "https://images.bba75516df65156022bb.jpg", 10, "Cien Sonetos de Amor" },
                    { "9789875666474", "Borges", "2011", "DEBOLSILLO", "https://contentv2/974_1.jpg?id_com=1113", 10, "Ficciones" },
                    { "9789875802957", "Neruda", "2008", "Cuspide", "https://9789875802957_1.jpg?id_com=1113", 10, "20 Poemas De Amor Y Una Cancion Des" },
                    { "9789877252538", "Cortazar", "2019", "DEBOLSILLO", "https://ed77b8615c4e99183f6da2.jpg", 10, "Rayuela" },
                    { "9789878317748", "Sabato", "2021", "Booket", "https://contentv2/917748_1.jpg?id_com=1113", 10, "La resistencia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Cliente",
                table: "Alquileres",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Estado",
                table: "Alquileres",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_ISBN",
                table: "Alquileres",
                column: "ISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EstadoDeAlquileres");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
