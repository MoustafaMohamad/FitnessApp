using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCalculationEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumIdToLookup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.AddColumn<int>(
                name: "EnumId",
                table: "Lookups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "LookupCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 100000000000000001L, "Gender" },
                    { 100000000000000002L, "ActivityLevel" },
                    { 100000000000000003L, "Goal" },
                    { 100000000000000004L, "Status" }
                });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CategoryId", "EnumId", "Name", "Value" },
                values: new object[,]
                {
                    { 200000000000000001L, 100000000000000001L, 1, "Male", 1.0 },
                    { 200000000000000002L, 100000000000000001L, 2, "Female", 2.0 },
                    { 200000000000000003L, 100000000000000002L, 3, "Rookie", 1.2 },
                    { 200000000000000004L, 100000000000000002L, 4, "Beginner", 1.375 },
                    { 200000000000000005L, 100000000000000002L, 5, "Intermediate", 1.55 },
                    { 200000000000000006L, 100000000000000002L, 6, "Advance", 1.7250000000000001 },
                    { 200000000000000007L, 100000000000000002L, 7, "TrueBeast", 1.8999999999999999 },
                    { 200000000000000008L, 100000000000000003L, 8, "Lose Weight", -500.0 },
                    { 200000000000000009L, 100000000000000003L, 9, "Gain Weight", 300.0 },
                    { 200000000000000010L, 100000000000000003L, 10, "Gain More Flexible", 150.0 },
                    { 200000000000000011L, 100000000000000003L, 11, "Get Fitter/Learn the Basic", 0.0 },
                    { 200000000000000012L, 100000000000000004L, 12, "Weak", 0.0 },
                    { 200000000000000013L, 100000000000000004L, 13, "Normal", 0.0 },
                    { 200000000000000014L, 100000000000000004L, 14, "Hard", 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000001L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000002L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000003L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000004L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000005L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000006L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000007L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000008L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000009L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000010L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000011L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000012L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000013L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 200000000000000014L);

            migrationBuilder.DeleteData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 100000000000000001L);

            migrationBuilder.DeleteData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 100000000000000002L);

            migrationBuilder.DeleteData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 100000000000000003L);

            migrationBuilder.DeleteData(
                table: "LookupCategories",
                keyColumn: "Id",
                keyValue: 100000000000000004L);

            migrationBuilder.DropColumn(
                name: "EnumId",
                table: "Lookups");

            migrationBuilder.InsertData(
                table: "LookupCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Gender" },
                    { 2L, "ActivityLevel" },
                    { 3L, "Goal" },
                    { 4L, "Status" }
                });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CategoryId", "Name", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, "Male", 1.0 },
                    { 2L, 1L, "Female", 2.0 },
                    { 3L, 2L, "Rookie", 1.2 },
                    { 4L, 2L, "Beginner", 1.375 },
                    { 5L, 2L, "Intermediate", 1.55 },
                    { 6L, 2L, "Advance", 1.7250000000000001 },
                    { 7L, 2L, "TrueBeast", 1.8999999999999999 },
                    { 8L, 3L, "Lose Weight", -500.0 },
                    { 9L, 3L, "Gain Weight", 300.0 },
                    { 10L, 3L, "Gain More Flexible", 150.0 },
                    { 11L, 3L, "Get Fitter/Learn the Basic", 0.0 },
                    { 12L, 4L, "Weak", 0.0 },
                    { 13L, 4L, "Normal", 0.0 },
                    { 14L, 4L, "Hard", 0.0 }
                });
        }
    }
}
