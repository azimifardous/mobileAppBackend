using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HrAppApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedHrRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HrRequests",
                columns: new[] { "Id", "Date", "Status", "Title", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "Vacation", "Leave" },
                    { 2, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Sick Leave", "Leave" },
                    { 3, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected", "Vacation", "Leave" }
                });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Bob O�Bits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HrRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HrRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HrRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Bob O’Bits");
        }
    }
}
