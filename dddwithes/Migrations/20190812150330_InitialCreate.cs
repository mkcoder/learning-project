using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dddwithes.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarDoorsWheelType = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    WheelType = table.Column<string>(nullable: true),
                    VehicleType = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    CarDoors = table.Column<int>(nullable: false),
                    Sunroof = table.Column<bool>(nullable: false),
                    WindowType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
