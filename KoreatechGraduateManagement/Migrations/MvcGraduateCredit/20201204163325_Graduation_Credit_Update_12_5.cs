using Microsoft.EntityFrameworkCore.Migrations;

namespace KoreatechGraduateManagement.Migrations.MvcGraduateCredit
{
    public partial class Graduation_Credit_Update_12_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GraduateCredit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntranceYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalGraduateCredit = table.Column<int>(type: "int", nullable: false),
                    ElectivesNormalCredit = table.Column<int>(type: "int", nullable: false),
                    ElectivesNecessaryCredit = table.Column<int>(type: "int", nullable: false),
                    CoreClassNormalCredit = table.Column<int>(type: "int", nullable: false),
                    CoreClassNecessaryCredit = table.Column<int>(type: "int", nullable: false),
                    HRDNormalCredit = table.Column<int>(type: "int", nullable: false),
                    HRDClassNecessaryCredit = table.Column<int>(type: "int", nullable: false),
                    MSCNormalCredit = table.Column<int>(type: "int", nullable: false),
                    MSCNecessaryCredit = table.Column<int>(type: "int", nullable: false),
                    FreeCredit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduateCredit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GraduateCredit");
        }
    }
}
