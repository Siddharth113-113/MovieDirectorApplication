using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDirectorApplicationAPI.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    directorName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    awardCount = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.directorName);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    movieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    boxOfficeCollection = table.Column<int>(type: "int", nullable: false),
                    Ratings = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.movieId);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieId = table.Column<int>(type: "int", nullable: false),
                    directorName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieDirector_Director_directorName",
                        column: x => x.directorName,
                        principalTable: "Director",
                        principalColumn: "directorName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieDirector_Movie_movieId",
                        column: x => x.movieId,
                        principalTable: "Movie",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirector_directorName",
                table: "MovieDirector",
                column: "directorName");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirector_movieId",
                table: "MovieDirector",
                column: "movieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDirector");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
