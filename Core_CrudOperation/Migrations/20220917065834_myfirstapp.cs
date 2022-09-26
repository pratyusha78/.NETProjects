using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1_Core.Migrations
{
    public partial class myfirstapp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {   
            migrationBuilder.CreateTable(
                name: "Employeeies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sal = table.Column<int>(type: "int", nullable: false),
                    dept = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zipcode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeeies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employeeies");
        }
    }
}
