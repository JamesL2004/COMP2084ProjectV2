using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2084Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioGenres",
                columns: table => new
                {
                    AudioGenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioGenres", x => x.AudioGenreId);
                });

            migrationBuilder.CreateTable(
                name: "ScreenGenres",
                columns: table => new
                {
                    ScreenGenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenGenres", x => x.ScreenGenreId);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AudioGenreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AudioGenreId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_Albums_AudioGenres_AudioGenreId1",
                        column: x => x.AudioGenreId1,
                        principalTable: "AudioGenres",
                        principalColumn: "AudioGenreId");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Screenwriter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScreenGenreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ScreenGenreId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_ScreenGenres_ScreenGenreId1",
                        column: x => x.ScreenGenreId1,
                        principalTable: "ScreenGenres",
                        principalColumn: "ScreenGenreId");
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShowCreator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScreenGenreId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ScreenGenreId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_Shows_ScreenGenres_ScreenGenreId1",
                        column: x => x.ScreenGenreId1,
                        principalTable: "ScreenGenres",
                        principalColumn: "ScreenGenreId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_AudioGenreId1",
                table: "Albums",
                column: "AudioGenreId1");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ScreenGenreId1",
                table: "Movies",
                column: "ScreenGenreId1");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ScreenGenreId1",
                table: "Shows",
                column: "ScreenGenreId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "AudioGenres");

            migrationBuilder.DropTable(
                name: "ScreenGenres");
        }
    }
}
