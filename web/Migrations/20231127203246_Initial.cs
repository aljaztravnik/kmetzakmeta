using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KategorijaStroja",
                columns: table => new
                {
                    MachineTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaStroja", x => x.MachineTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Pasma",
                columns: table => new
                {
                    BreedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasma", x => x.BreedID);
                });

            migrationBuilder.CreateTable(
                name: "Regija",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regija", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Znamka",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Znamka", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Uporabnik",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uporabnik", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Uporabnik_Regija_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regija",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uporabnik_RegionID",
                table: "Uporabnik",
                column: "RegionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategorijaStroja");

            migrationBuilder.DropTable(
                name: "Pasma");

            migrationBuilder.DropTable(
                name: "Uporabnik");

            migrationBuilder.DropTable(
                name: "Znamka");

            migrationBuilder.DropTable(
                name: "Regija");
        }
    }
}
