using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2084Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class switchedtoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AudioGenres_AudioGenreId1",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_ScreenGenres_ScreenGenreId1",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_ScreenGenres_ScreenGenreId1",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_ScreenGenreId1",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ScreenGenreId1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Albums_AudioGenreId1",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ScreenGenreId1",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "ScreenGenreId1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "AudioGenreId1",
                table: "Albums");

            migrationBuilder.AlterColumn<int>(
                name: "ScreenGenreId",
                table: "Shows",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ScreenGenreId",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AudioGenreId",
                table: "Albums",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ScreenGenreId",
                table: "Shows",
                column: "ScreenGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ScreenGenreId",
                table: "Movies",
                column: "ScreenGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_AudioGenreId",
                table: "Albums",
                column: "AudioGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AudioGenres_AudioGenreId",
                table: "Albums",
                column: "AudioGenreId",
                principalTable: "AudioGenres",
                principalColumn: "AudioGenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_ScreenGenres_ScreenGenreId",
                table: "Movies",
                column: "ScreenGenreId",
                principalTable: "ScreenGenres",
                principalColumn: "ScreenGenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_ScreenGenres_ScreenGenreId",
                table: "Shows",
                column: "ScreenGenreId",
                principalTable: "ScreenGenres",
                principalColumn: "ScreenGenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AudioGenres_AudioGenreId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_ScreenGenres_ScreenGenreId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_ScreenGenres_ScreenGenreId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_ScreenGenreId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ScreenGenreId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Albums_AudioGenreId",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "ScreenGenreId",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ScreenGenreId1",
                table: "Shows",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScreenGenreId",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ScreenGenreId1",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AudioGenreId",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AudioGenreId1",
                table: "Albums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ScreenGenreId1",
                table: "Shows",
                column: "ScreenGenreId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ScreenGenreId1",
                table: "Movies",
                column: "ScreenGenreId1");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_AudioGenreId1",
                table: "Albums",
                column: "AudioGenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AudioGenres_AudioGenreId1",
                table: "Albums",
                column: "AudioGenreId1",
                principalTable: "AudioGenres",
                principalColumn: "AudioGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_ScreenGenres_ScreenGenreId1",
                table: "Movies",
                column: "ScreenGenreId1",
                principalTable: "ScreenGenres",
                principalColumn: "ScreenGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_ScreenGenres_ScreenGenreId1",
                table: "Shows",
                column: "ScreenGenreId1",
                principalTable: "ScreenGenres",
                principalColumn: "ScreenGenreId");
        }
    }
}
