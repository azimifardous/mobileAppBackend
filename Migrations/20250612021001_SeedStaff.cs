using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrAppApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Bob O'Bits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Bob O�Bits");
        }
    }
}
