using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2084Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieEntry_MovieList_MovieListId",
                table: "MovieEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieEntry_Movies_MovieId",
                table: "MovieEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowEntry_MovieList_MovieListId",
                table: "ShowEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowEntry_ShowList_ShowListId",
                table: "ShowEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowEntry_Shows_ShowId",
                table: "ShowEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowList",
                table: "ShowList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowEntry",
                table: "ShowEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieList",
                table: "MovieList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieEntry",
                table: "MovieEntry");

            migrationBuilder.RenameTable(
                name: "ShowList",
                newName: "ShowList_1");

            migrationBuilder.RenameTable(
                name: "ShowEntry",
                newName: "ShowEntry_1");

            migrationBuilder.RenameTable(
                name: "MovieList",
                newName: "MovieList_1");

            migrationBuilder.RenameTable(
                name: "MovieEntry",
                newName: "MovieEntry_1");

            migrationBuilder.RenameIndex(
                name: "IX_ShowEntry_ShowListId",
                table: "ShowEntry_1",
                newName: "IX_ShowEntry_1_ShowListId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowEntry_ShowId",
                table: "ShowEntry_1",
                newName: "IX_ShowEntry_1_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowEntry_MovieListId",
                table: "ShowEntry_1",
                newName: "IX_ShowEntry_1_MovieListId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieEntry_MovieListId",
                table: "MovieEntry_1",
                newName: "IX_MovieEntry_1_MovieListId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieEntry_MovieId",
                table: "MovieEntry_1",
                newName: "IX_MovieEntry_1_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowList_1",
                table: "ShowList_1",
                column: "ShowListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowEntry_1",
                table: "ShowEntry_1",
                column: "ShowEntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieList_1",
                table: "MovieList_1",
                column: "MovieListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieEntry_1",
                table: "MovieEntry_1",
                column: "MovieEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieEntry_1_MovieList_1_MovieListId",
                table: "MovieEntry_1",
                column: "MovieListId",
                principalTable: "MovieList_1",
                principalColumn: "MovieListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieEntry_1_Movies_MovieId",
                table: "MovieEntry_1",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowEntry_1_MovieList_1_MovieListId",
                table: "ShowEntry_1",
                column: "MovieListId",
                principalTable: "MovieList_1",
                principalColumn: "MovieListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowEntry_1_ShowList_1_ShowListId",
                table: "ShowEntry_1",
                column: "ShowListId",
                principalTable: "ShowList_1",
                principalColumn: "ShowListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowEntry_1_Shows_ShowId",
                table: "ShowEntry_1",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieEntry_1_MovieList_1_MovieListId",
                table: "MovieEntry_1");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieEntry_1_Movies_MovieId",
                table: "MovieEntry_1");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowEntry_1_MovieList_1_MovieListId",
                table: "ShowEntry_1");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowEntry_1_ShowList_1_ShowListId",
                table: "ShowEntry_1");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowEntry_1_Shows_ShowId",
                table: "ShowEntry_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowList_1",
                table: "ShowList_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowEntry_1",
                table: "ShowEntry_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieList_1",
                table: "MovieList_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieEntry_1",
                table: "MovieEntry_1");

            migrationBuilder.RenameTable(
                name: "ShowList_1",
                newName: "ShowList");

            migrationBuilder.RenameTable(
                name: "ShowEntry_1",
                newName: "ShowEntry");

            migrationBuilder.RenameTable(
                name: "MovieList_1",
                newName: "MovieList");

            migrationBuilder.RenameTable(
                name: "MovieEntry_1",
                newName: "MovieEntry");

            migrationBuilder.RenameIndex(
                name: "IX_ShowEntry_1_ShowListId",
                table: "ShowEntry",
                newName: "IX_ShowEntry_ShowListId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowEntry_1_ShowId",
                table: "ShowEntry",
                newName: "IX_ShowEntry_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_ShowEntry_1_MovieListId",
                table: "ShowEntry",
                newName: "IX_ShowEntry_MovieListId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieEntry_1_MovieListId",
                table: "MovieEntry",
                newName: "IX_MovieEntry_MovieListId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieEntry_1_MovieId",
                table: "MovieEntry",
                newName: "IX_MovieEntry_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowList",
                table: "ShowList",
                column: "ShowListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowEntry",
                table: "ShowEntry",
                column: "ShowEntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieList",
                table: "MovieList",
                column: "MovieListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieEntry",
                table: "MovieEntry",
                column: "MovieEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieEntry_MovieList_MovieListId",
                table: "MovieEntry",
                column: "MovieListId",
                principalTable: "MovieList",
                principalColumn: "MovieListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieEntry_Movies_MovieId",
                table: "MovieEntry",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowEntry_MovieList_MovieListId",
                table: "ShowEntry",
                column: "MovieListId",
                principalTable: "MovieList",
                principalColumn: "MovieListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowEntry_ShowList_ShowListId",
                table: "ShowEntry",
                column: "ShowListId",
                principalTable: "ShowList",
                principalColumn: "ShowListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowEntry_Shows_ShowId",
                table: "ShowEntry",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
