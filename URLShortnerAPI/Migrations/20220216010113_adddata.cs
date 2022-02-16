using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace URLShortnerAPI.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "uRLs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OriginalUrl", "URLCode" },
                values: new object[] { 1000000, null, new DateTime(2022, 2, 15, 20, 1, 11, 779, DateTimeKind.Local).AddTicks(9087), null, null, "https://google.com", "1a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "uRLs",
                keyColumn: "Id",
                keyValue: 1000000);
        }
    }
}
