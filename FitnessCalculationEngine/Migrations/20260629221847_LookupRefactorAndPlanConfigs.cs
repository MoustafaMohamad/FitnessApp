using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCalculationEngine.Migrations
{
    /// <inheritdoc />
    public partial class LookupRefactorAndPlanConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lookups_LookupCategories_CategoryId",
                table: "Lookups");

            migrationBuilder.DropTable(
                name: "LookupCategories");

            migrationBuilder.DropIndex(
                name: "IX_Lookups_CategoryId",
                table: "Lookups");

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

            migrationBuilder.DropColumn(
                name: "EnumId",
                table: "Lookups");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CalculatedMetrics");

            migrationBuilder.AlterColumn<int>(
                name: "GoalId",
                table: "UserFitnessStats",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "UserFitnessStats",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityLevelId",
                table: "UserFitnessStats",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Lookups",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Lookups",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "CalculatedMetrics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CategoryId", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Male", 1.0 },
                    { 2, 1, "Female", 2.0 },
                    { 3, 2, "Rookie", 1.2 },
                    { 4, 2, "Beginner", 1.375 },
                    { 5, 2, "Intermediate", 1.55 },
                    { 6, 2, "Advance", 1.7250000000000001 },
                    { 7, 2, "TrueBeast", 1.8999999999999999 },
                    { 8, 3, "Lose Weight", -500.0 },
                    { 9, 3, "Gain Weight", 300.0 },
                    { 10, 3, "Gain More Flexible", 150.0 },
                    { 11, 3, "Get Fitter/Learn the Basic", 0.0 },
                    { 12, 4, "Weak", 0.0 },
                    { 13, 4, "Normal", 0.0 },
                    { 14, 4, "Hard", 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculatedMetrics_StatusId",
                table: "CalculatedMetrics",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalculatedMetrics_Lookups_StatusId",
                table: "CalculatedMetrics",
                column: "StatusId",
                principalTable: "Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculatedMetrics_Lookups_StatusId",
                table: "CalculatedMetrics");

            migrationBuilder.DropIndex(
                name: "IX_CalculatedMetrics_StatusId",
                table: "CalculatedMetrics");

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "CalculatedMetrics");

            migrationBuilder.AlterColumn<long>(
                name: "GoalId",
                table: "UserFitnessStats",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "GenderId",
                table: "UserFitnessStats",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ActivityLevelId",
                table: "UserFitnessStats",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Lookups",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Lookups",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EnumId",
                table: "Lookups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CalculatedMetrics",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LookupCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EnumId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LookupCategories",
                columns: new[] { "Id", "EnumId", "Name" },
                values: new object[,]
                {
                    { 100000000000000001L, 1, "Gender" },
                    { 100000000000000002L, 2, "ActivityLevel" },
                    { 100000000000000003L, 3, "Goal" },
                    { 100000000000000004L, 4, "Status" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Lookups_CategoryId",
                table: "Lookups",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lookups_LookupCategories_CategoryId",
                table: "Lookups",
                column: "CategoryId",
                principalTable: "LookupCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
