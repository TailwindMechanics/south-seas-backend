using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SouthSeas.Migrations
{
    /// <inheritdoc />
    public partial class Cards_Scene_7_M_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    column_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "text", nullable: false, defaultValue: "Untitled Player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.column_id);
                });

            migrationBuilder.CreateTable(
                name: "transform",
                columns: table => new
                {
                    column_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    position = table.Column<float[]>(type: "real[]", nullable: false, defaultValue: new[] { 0f, 0f, 0f }),
                    rotation = table.Column<float[]>(type: "real[]", nullable: false, defaultValue: new[] { 0f, 0f, 0f }),
                    scale = table.Column<float[]>(type: "real[]", nullable: false, defaultValue: new[] { 1f, 1f, 1f })
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transform", x => x.column_id);
                });

            migrationBuilder.CreateTable(
                name: "cards_scene_7",
                columns: table => new
                {
                    row_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    tags = table.Column<string[]>(type: "text[]", nullable: true),
                    suit = table.Column<string>(type: "text", nullable: true),
                    rank = table.Column<string>(type: "text", nullable: true),
                    owner = table.Column<Guid>(type: "uuid", nullable: true),
                    player = table.Column<Guid>(type: "uuid", nullable: true),
                    transform = table.Column<Guid>(type: "uuid", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards_scene_7", x => x.row_id);
                    table.ForeignKey(
                        name: "FK_cards_scene_7_player_owner",
                        column: x => x.owner,
                        principalTable: "player",
                        principalColumn: "column_id");
                    table.ForeignKey(
                        name: "FK_cards_scene_7_player_player",
                        column: x => x.player,
                        principalTable: "player",
                        principalColumn: "column_id");
                    table.ForeignKey(
                        name: "FK_cards_scene_7_transform_transform",
                        column: x => x.transform,
                        principalTable: "transform",
                        principalColumn: "column_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cards_scene_7_owner",
                table: "cards_scene_7",
                column: "owner");

            migrationBuilder.CreateIndex(
                name: "IX_cards_scene_7_player",
                table: "cards_scene_7",
                column: "player");

            migrationBuilder.CreateIndex(
                name: "IX_cards_scene_7_transform",
                table: "cards_scene_7",
                column: "transform");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cards_scene_7");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "transform");
        }
    }
}
