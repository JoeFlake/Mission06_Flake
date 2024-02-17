using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_Flake.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false).Annotation("Sqlite:Autoincrement", true), // Configuring MovieId to be auto-generated
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<string>(type: "TEXT", nullable: false),
                    Edited = table.Column<bool>(type: "INTEGER", nullable: true), // Make Edited nullable
                    LentTo = table.Column<string>(type: "TEXT", nullable: true), // Make LentTo nullable
                    Notes = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true) // Make Notes nullable
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId); // Setting MovieId as primary key
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
