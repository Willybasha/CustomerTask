using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastrcutureLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ALZaher_ELGiesh Street", "MohamedWaleedHassan12@gmail.com", false, "Mohamed Waleed Hassan", "01095494490" },
                    { 2, "ALZaher_ELGiesh Street", "NewUser2@gmail.com", false, "NewUser2", "01111112222" },
                    { 3, "Cairo", "NewUser3@gmail.com", false, "NewUser3", "01111112222" },
                    { 4, "Cairo", "NewUser4@gmail.com", false, "NewUser4", "01111112222" },
                    { 5, "Cairo", "NewUser5@gmail.com", false, "NewUser5", "01111112222" },
                    { 6, "Cairo", "NewUser6@gmail.com", false, "NewUser6", "01111112222" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
