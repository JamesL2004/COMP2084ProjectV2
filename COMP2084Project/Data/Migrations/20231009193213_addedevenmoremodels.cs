using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2084Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedevenmoremodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieList",
                columns: table => new
                {
                    MovieListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieListDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieList", x => x.MovieListId);
                });

            migrationBuilder.CreateTable(
                name: "ShowList",
                columns: table => new
                {
                    ShowListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowListDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowList", x => x.ShowListId);
                });

            migrationBuilder.CreateTable(
                name: "MovieEntry",
                columns: table => new
                {
                    MovieEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MovieListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieEntry", x => x.MovieEntryId);
                    table.ForeignKey(
                        name: "FK_MovieEntry_MovieList_MovieListId",
                        column: x => x.MovieListId,
                        principalTable: "MovieList",
                        principalColumn: "MovieListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEntry_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowEntry",
                columns: table => new
                {
                    ShowEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    ShowListId = table.Column<int>(type: "int", nullable: false),
                    MovieListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowEntry", x => x.ShowEntryId);
                    table.ForeignKey(
                        name: "FK_ShowEntry_MovieList_MovieListId",
                        column: x => x.MovieListId,
                        principalTable: "MovieList",
                        principalColumn: "MovieListId");
                    table.ForeignKey(
                        name: "FK_ShowEntry_ShowList_ShowListId",
                        column: x => x.ShowListId,
                        principalTable: "ShowList",
                        principalColumn: "ShowListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowEntry_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieEntry_MovieId",
                table: "MovieEntry",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieEntry_MovieListId",
                table: "MovieEntry",
                column: "MovieListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowEntry_MovieListId",
                table: "ShowEntry",
                column: "MovieListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowEntry_ShowId",
                table: "ShowEntry",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowEntry_ShowListId",
                table: "ShowEntry",
                column: "ShowListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieEntry");

            migrationBuilder.DropTable(
                name: "ShowEntry");

            migrationBuilder.DropTable(
                name: "MovieList");

            migrationBuilder.DropTable(
                name: "ShowList");
        }
    }
}
