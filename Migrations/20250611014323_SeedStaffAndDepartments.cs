using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HrAppApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedStaffAndDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Staff");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Staff",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -5, "Human Resources" },
                    { -4, "Marketing" },
                    { -3, "Finance" },
                    { -2, "Information Communications Technology" },
                    { -1, "General" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "City", "Country", "DepartmentId", "Name", "Phone", "State", "Street", "Zip" },
                values: new object[,]
                {
                    { 1, "Javaville", "Australia", -2, "John Smith", "02 9988 2211", "NSW", "1 Code Lane", "0100" },
                    { 2, "Byte Cove", "Australia", -3, "Sue White", "03 8899 2255", "QLD", "16 Bit Way", "1101" },
                    { 3, "Cloud Hills", "Australia", -4, "Bob O’Bits", "05 7788 2255", "VIC", "8 Silicon Road", "1001" },
                    { 4, "Appletson", "Australia", -3, "Mary Blue", "06 4455 9988", "NT", "4 Processor Boulevard", "1010" },
                    { 5, "Bufferland", "Australia", -4, "Mick Green", "02 9988 1122", "NSW", "700 Bandwidth Street", "0110" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DepartmentId",
                table: "Staff",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Departments_DepartmentId",
                table: "Staff",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Departments_DepartmentId",
                table: "Staff");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Staff_DepartmentId",
                table: "Staff");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Staff");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Staff",
                type: "TEXT",
                nullable: true);
        }
    }
}
