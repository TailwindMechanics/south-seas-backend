using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SouthSeas.Migrations
{
    /// <inheritdoc />
    public partial class Migration_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "movement");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "player",
                type: "text",
                nullable: false,
                defaultValue: "Untitled",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Speed",
                table: "movement",
                type: "real",
                nullable: false,
                defaultValue: 1f,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car",
                type: "text",
                nullable: false,
                defaultValue: "Untiled",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "player",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Untitled");

            migrationBuilder.AlterColumn<float>(
                name: "Speed",
                table: "movement",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 1f);

            migrationBuilder.AddColumn<float>(
                name: "Direction",
                table: "movement",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Untiled");
        }
    }
}
