using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_Morgenmadsbuffeten.Data.Migrations
{
    public partial class Guests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckedInGuests",
                columns: table => new
                {
                    CheckedInGuestId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    Adults = table.Column<int>(nullable: false),
                    Children = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckedInGuests", x => x.CheckedInGuestId);
                });

            migrationBuilder.CreateTable(
                name: "ExpectedGuests",
                columns: table => new
                {
                    ExpectedGuestId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    Adults = table.Column<int>(nullable: false),
                    Children = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpectedGuests", x => x.ExpectedGuestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckedInGuests");

            migrationBuilder.DropTable(
                name: "ExpectedGuests");
        }
    }
}
