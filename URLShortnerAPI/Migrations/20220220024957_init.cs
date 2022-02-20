using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace URLShortnerAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uRLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    OriginalUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    URLCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uRLs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "uRLs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OriginalUrl", "URLCode" },
                values: new object[] { 100, null, new DateTime(2022, 2, 19, 21, 49, 57, 161, DateTimeKind.Local).AddTicks(1694), null, null, "google.com", "11PVWGSpX7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uRLs");
        }
    }
}
