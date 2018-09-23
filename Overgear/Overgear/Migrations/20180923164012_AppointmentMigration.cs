using Microsoft.EntityFrameworkCore.Migrations;

namespace Overgear.Migrations
{
    public partial class AppointmentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Request");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Outerwear",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: true),
                    start = table.Column<string>(nullable: true),
                    end = table.Column<string>(nullable: true),
                    allDay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Request",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Outerwear",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
