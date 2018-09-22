using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Overgear.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Shirt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Boot",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gloves",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "Outerwear",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pants", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gloves");

            migrationBuilder.DropTable(
                name: "Headgear");

            migrationBuilder.DropTable(
                name: "Outerwear");

            migrationBuilder.DropTable(
                name: "Pants");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Shirt");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Boot");
        }
    }
}
