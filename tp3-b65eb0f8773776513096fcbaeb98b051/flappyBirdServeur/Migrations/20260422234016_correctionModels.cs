using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flappyBirdServeur.Migrations
{
    /// <inheritdoc />
    public partial class correctionModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoresUsers");

            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Scores",
                newName: "Visibilité");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Chrono",
                table: "Scores",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_UserId",
                table: "Scores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AspNetUsers_UserId",
                table: "Scores",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AspNetUsers_UserId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_UserId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Chrono",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "Visibilité",
                table: "Scores",
                newName: "IsPublic");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ScoresUsers",
                columns: table => new
                {
                    ScoresId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoresUsers", x => new { x.ScoresId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ScoresUsers_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoresUsers_Scores_ScoresId",
                        column: x => x.ScoresId,
                        principalTable: "Scores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoresUsers_UsersId",
                table: "ScoresUsers",
                column: "UsersId");
        }
    }
}
