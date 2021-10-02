using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resources.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookedQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ResourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourcesDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcesDbSet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BookingDbSet",
                columns: new[] { "Id", "BookedQuantity", "DateFrom", "DateTo", "ResourceId" },
                values: new object[] { 1, 1, new DateTime(2021, 10, 2, 2, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 6, 2, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "BookingDbSet",
                columns: new[] { "Id", "BookedQuantity", "DateFrom", "DateTo", "ResourceId" },
                values: new object[] { 2, 2, new DateTime(2021, 10, 3, 2, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 8, 2, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "BookingDbSet",
                columns: new[] { "Id", "BookedQuantity", "DateFrom", "DateTo", "ResourceId" },
                values: new object[] { 3, 3, new DateTime(2021, 10, 4, 2, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 5, 2, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "ResourcesDbSet",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[] { 1, "Resource 1", 10 });

            migrationBuilder.InsertData(
                table: "ResourcesDbSet",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[] { 2, "Resource 2", 5 });

            migrationBuilder.InsertData(
                table: "ResourcesDbSet",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[] { 3, "Resource 3", 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDbSet");

            migrationBuilder.DropTable(
                name: "ResourcesDbSet");
        }
    }
}
