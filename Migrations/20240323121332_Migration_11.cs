using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SouthSeas.Migrations
{
    /// <inheritdoc />
    public partial class Migration_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float[]>(
                name: "scale",
                table: "transform",
                type: "real[]",
                nullable: false,
                defaultValue: new[] { 1f, 1f, 1f },
                oldClrType: typeof(float[]),
                oldType: "real[]");

            migrationBuilder.AlterColumn<float[]>(
                name: "rotation",
                table: "transform",
                type: "real[]",
                nullable: false,
                defaultValue: new[] { 0f, 0f, 0f },
                oldClrType: typeof(float[]),
                oldType: "real[]");

            migrationBuilder.AlterColumn<float[]>(
                name: "position",
                table: "transform",
                type: "real[]",
                nullable: false,
                defaultValue: new[] { 0f, 0f, 0f },
                oldClrType: typeof(float[]),
                oldType: "real[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float[]>(
                name: "scale",
                table: "transform",
                type: "real[]",
                nullable: false,
                oldClrType: typeof(float[]),
                oldType: "real[]",
                oldDefaultValue: new[] { 1f, 1f, 1f });

            migrationBuilder.AlterColumn<float[]>(
                name: "rotation",
                table: "transform",
                type: "real[]",
                nullable: false,
                oldClrType: typeof(float[]),
                oldType: "real[]",
                oldDefaultValue: new[] { 0f, 0f, 0f });

            migrationBuilder.AlterColumn<float[]>(
                name: "position",
                table: "transform",
                type: "real[]",
                nullable: false,
                oldClrType: typeof(float[]),
                oldType: "real[]",
                oldDefaultValue: new[] { 0f, 0f, 0f });
        }
    }
}
