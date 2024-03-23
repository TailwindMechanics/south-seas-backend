using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SouthSeas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "movement",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Speed = table.Column<float>(type: "real", nullable: false),
                    Direction = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transform",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    position = table.Column<float[]>(type: "real[]", nullable: false),
                    rotation = table.Column<float[]>(type: "real[]", nullable: false),
                    scale = table.Column<float[]>(type: "real[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transform", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scene",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransformId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    MovementId = table.Column<Guid>(type: "uuid", nullable: true),
                    CarId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scene", x => x.id);
                    table.ForeignKey(
                        name: "FK_scene_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_scene_movement_MovementId",
                        column: x => x.MovementId,
                        principalTable: "movement",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_scene_player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "player",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_scene_transform_TransformId",
                        column: x => x.TransformId,
                        principalTable: "transform",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scene_CarId",
                table: "scene",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_scene_MovementId",
                table: "scene",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_scene_PlayerId",
                table: "scene",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_scene_TransformId",
                table: "scene",
                column: "TransformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scene");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "movement");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "transform");
        }
    }
}
