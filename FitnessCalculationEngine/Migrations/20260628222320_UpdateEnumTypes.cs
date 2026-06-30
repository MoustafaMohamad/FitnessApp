using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCalculationEngine.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnumTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnumId",
                table: "LookupCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 100000000000000001L,
                column: "EnumId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 100000000000000002L,
                column: "EnumId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 100000000000000003L,
                column: "EnumId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 100000000000000004L,
                column: "EnumId",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnumId",
                table: "LookupCategories");
        }
    }
}
