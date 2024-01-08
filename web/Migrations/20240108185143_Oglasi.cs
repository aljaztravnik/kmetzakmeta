using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    /// <inheritdoc />
    public partial class Oglasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Znamka",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Uporabnik",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Regija",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pasma",
                newName: "Breed");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "KategorijaStroja",
                newName: "MachineType");

            migrationBuilder.DropPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens");
            migrationBuilder.DropPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens", new string[] { "UserId", "LoginProvider", "Name" });
            migrationBuilder.AddPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins", new string[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateTable(
                name: "OglasStroj",
                columns: table => new
                {
                    StrojOglasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    WorkingHours = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegionID = table.Column<int>(type: "int", nullable: true),
                    BrandID = table.Column<int>(type: "int", nullable: true),
                    CategoryMachineTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasStroj", x => x.StrojOglasID);
                    table.ForeignKey(
                        name: "FK_OglasStroj_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OglasStroj_KategorijaStroja_CategoryMachineTypeID",
                        column: x => x.CategoryMachineTypeID,
                        principalTable: "KategorijaStroja",
                        principalColumn: "MachineTypeID");
                    table.ForeignKey(
                        name: "FK_OglasStroj_Regija_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regija",
                        principalColumn: "RegionID");
                    table.ForeignKey(
                        name: "FK_OglasStroj_Znamka_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Znamka",
                        principalColumn: "BrandID");
                });

            migrationBuilder.CreateTable(
                name: "OglasZivina",
                columns: table => new
                {
                    ZivinaOglasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Offspring = table.Column<int>(type: "int", nullable: false),
                    Construction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegionID = table.Column<int>(type: "int", nullable: true),
                    BreedID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasZivina", x => x.ZivinaOglasID);
                    table.ForeignKey(
                        name: "FK_OglasZivina_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OglasZivina_Pasma_BreedID",
                        column: x => x.BreedID,
                        principalTable: "Pasma",
                        principalColumn: "BreedID");
                    table.ForeignKey(
                        name: "FK_OglasZivina_Regija_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regija",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OglasStroj_BrandID",
                table: "OglasStroj",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_OglasStroj_CategoryMachineTypeID",
                table: "OglasStroj",
                column: "CategoryMachineTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_OglasStroj_RegionID",
                table: "OglasStroj",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_OglasStroj_UserId",
                table: "OglasStroj",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasZivina_BreedID",
                table: "OglasZivina",
                column: "BreedID");

            migrationBuilder.CreateIndex(
                name: "IX_OglasZivina_RegionID",
                table: "OglasZivina",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_OglasZivina_UserId",
                table: "OglasZivina",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OglasStroj");

            migrationBuilder.DropTable(
                name: "OglasZivina");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Znamka",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Uporabnik",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Regija",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Breed",
                table: "Pasma",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MachineType",
                table: "KategorijaStroja",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }
    }
}
