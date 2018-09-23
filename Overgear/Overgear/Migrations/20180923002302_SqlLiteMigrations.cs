using Microsoft.EntityFrameworkCore.Migrations;

namespace Overgear.Migrations
{
    public partial class SqlLiteMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gloves",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gloves", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Headgear",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headgear", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HighVisibility",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighVisibility", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Outerwear",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outerwear", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shirt",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boot");

            migrationBuilder.DropTable(
                name: "Gloves");

            migrationBuilder.DropTable(
                name: "Headgear");

            migrationBuilder.DropTable(
                name: "HighVisibility");

            migrationBuilder.DropTable(
                name: "Outerwear");

            migrationBuilder.DropTable(
                name: "Pants");

            migrationBuilder.DropTable(
                name: "Shirt");

            migrationBuilder.DropTable(
                name: "Shoe");
        }
    }
}
