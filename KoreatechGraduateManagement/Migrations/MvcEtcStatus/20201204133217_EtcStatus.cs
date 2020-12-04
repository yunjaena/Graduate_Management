using Microsoft.EntityFrameworkCore.Migrations;

namespace KoreatechGraduateManagement.Migrations.MvcEtcStatus
{
    public partial class EtcStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIPPFinish = table.Column<bool>(type: "bit", nullable: false),
                    IsEngineerCertificationFinish = table.Column<bool>(type: "bit", nullable: false),
                    IsEnglishCertificationFinish = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
