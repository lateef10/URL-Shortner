using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace URLShortnerAPI.Migrations
{
    public partial class updateseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "uRLs",
                keyColumn: "Id",
                keyValue: 1000000);

            migrationBuilder.InsertData(
                table: "uRLs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OriginalUrl", "URLCode" },
                values: new object[] { 100, null, new DateTime(2022, 2, 18, 23, 49, 40, 361, DateTimeKind.Local).AddTicks(2522), null, null, "google.com", "11PVWGSpX7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "uRLs",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.InsertData(
                table: "uRLs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OriginalUrl", "URLCode" },
                values: new object[] { 1000000, null, new DateTime(2022, 2, 15, 20, 1, 11, 779, DateTimeKind.Local).AddTicks(9087), null, null, "https://google.com", "1a" });
        }
    }
}
