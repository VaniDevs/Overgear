using Microsoft.EntityFrameworkCore.Migrations;

namespace Overgear.Migrations
{
    public partial class ShirtToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Shirt",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Shirt",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
