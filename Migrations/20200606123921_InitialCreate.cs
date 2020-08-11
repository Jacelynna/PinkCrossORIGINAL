using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace PinkCross.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonorProfile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorName = table.Column<string>(nullable: false),
                    Donornric = table.Column<string>(maxLength: 60, nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    DonorNumber = table.Column<string>(maxLength: 60, nullable: true),
                    DonorAddress = table.Column<string>(nullable: true),
       
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorProfile", x => x.ID);
                }) ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorProfile");
        }
    }
}
