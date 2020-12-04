using Microsoft.EntityFrameworkCore.Migrations;

namespace KoreatechGraduateManagement.Migrations.MvcEtcStatus
{
    public partial class StatusUpdate_12_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "EtcStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EtcStatus",
                table: "EtcStatus",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EtcStatus",
                table: "EtcStatus");

            migrationBuilder.RenameTable(
                name: "EtcStatus",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }
    }
}
