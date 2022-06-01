using Microsoft.EntityFrameworkCore.Migrations;

namespace CR_back.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_name = table.Column<string>(nullable: true),
                    ligaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "liga",
                columns: table => new
                {
                    ligaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InCountryID = table.Column<int>(nullable: false),
                    liga_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_liga", x => x.ligaID);
                    table.ForeignKey(
                        name: "FK_liga_Country_InCountryID",
                        column: x => x.InCountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    teamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    liga_idliga = table.Column<int>(nullable: false),
                    teamname = table.Column<string>(nullable: true),
                    cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.teamID);
                    table.ForeignKey(
                        name: "FK_team_liga_liga_idliga",
                        column: x => x.liga_idliga,
                        principalTable: "liga",
                        principalColumn: "ligaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_liga_InCountryID",
                table: "liga",
                column: "InCountryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_team_liga_idliga",
                table: "team",
                column: "liga_idliga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "liga");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
