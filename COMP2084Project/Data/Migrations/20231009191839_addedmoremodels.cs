using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2084Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedmoremodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioList",
                columns: table => new
                {
                    AudioListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioListDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioList", x => x.AudioListId);
                });

            migrationBuilder.CreateTable(
                name: "AudioEntry",
                columns: table => new
                {
                    AudioEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    AudioListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioEntry", x => x.AudioEntryId);
                    table.ForeignKey(
                        name: "FK_AudioEntry_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioEntry_AudioList_AudioListId",
                        column: x => x.AudioListId,
                        principalTable: "AudioList",
                        principalColumn: "AudioListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioEntry_AlbumId",
                table: "AudioEntry",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioEntry_AudioListId",
                table: "AudioEntry",
                column: "AudioListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioEntry");

            migrationBuilder.DropTable(
                name: "AudioList");
        }
    }
}
