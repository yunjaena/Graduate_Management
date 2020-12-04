using Microsoft.EntityFrameworkCore.Migrations;

namespace KoreatechGraduateManagement.Migrations.MvcSubject
{
    public partial class SubjectName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "Subject");
        }
    }
}
