using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CR_back.Migrations
{
    public partial class CountryContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    playerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inTeamID = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true),
                    cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.playerID);
                    table.ForeignKey(
                        name: "FK_player_team_inTeamID",
                        column: x => x.inTeamID,
                        principalTable: "team",
                        principalColumn: "teamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_player_inTeamID",
                table: "player",
                column: "inTeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
