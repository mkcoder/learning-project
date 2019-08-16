using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dddwithes.Migrations
{
    public partial class AddES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AggregateEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    EventName = table.Column<string>(nullable: true),
                    AggregateId = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    RequestData = table.Column<string>(nullable: true),
                    Request = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggregateEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AggregateEvents");
        }
    }
}
