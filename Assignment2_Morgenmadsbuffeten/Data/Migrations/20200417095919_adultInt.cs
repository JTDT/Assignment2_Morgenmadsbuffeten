//using Microsoft.EntityFrameworkCore.Migrations;

//namespace Assignment2_Morgenmadsbuffeten.Data.Migrations
//{
//    public partial class adultInt : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropColumn(
//                name: "Adults",
//                table: "CheckedInGuests");

//            migrationBuilder.AddColumn<int>(
//                name: "Adult",
//                table: "CheckedInGuests",
//                nullable: false,
//                defaultValue: 0);
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropColumn(
//                name: "Adult",
//                table: "CheckedInGuests");

//            migrationBuilder.AddColumn<int>(
//                name: "Adults",
//                table: "CheckedInGuests",
//                type: "int",
//                nullable: false,
//                defaultValue: 0);
//        }
//    }
//}
