using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCalculationEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddGenericLookupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "UserFitnessStats");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserFitnessStats");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "UserFitnessStats");

            migrationBuilder.AddColumn<long>(
                name: "ActivityLevelId",
                table: "UserFitnessStats",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GenderId",
                table: "UserFitnessStats",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GoalId",
                table: "UserFitnessStats",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CalculatedMetrics",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "LookupCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lookups_LookupCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "LookupCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LookupCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Gender" },
                    { 2L, "ActivityLevel" },
                    { 3L, "Goal" }
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
                    { 11L, 3L, "Get Fitter/Learn the Basic", 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFitnessStats_ActivityLevelId",
                table: "UserFitnessStats",
                column: "ActivityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFitnessStats_GenderId",
                table: "UserFitnessStats",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFitnessStats_GoalId",
                table: "UserFitnessStats",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookups_CategoryId",
                table: "Lookups",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFitnessStats_Lookups_ActivityLevelId",
                table: "UserFitnessStats",
                column: "ActivityLevelId",
                principalTable: "Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFitnessStats_Lookups_GenderId",
                table: "UserFitnessStats",
                column: "GenderId",
                principalTable: "Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFitnessStats_Lookups_GoalId",
                table: "UserFitnessStats",
                column: "GoalId",
                principalTable: "Lookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFitnessStats_Lookups_ActivityLevelId",
                table: "UserFitnessStats");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFitnessStats_Lookups_GenderId",
                table: "UserFitnessStats");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFitnessStats_Lookups_GoalId",
                table: "UserFitnessStats");

            migrationBuilder.DropTable(
                name: "Lookups");

            migrationBuilder.DropTable(
                name: "LookupCategories");

            migrationBuilder.DropIndex(
                name: "IX_UserFitnessStats_ActivityLevelId",
                table: "UserFitnessStats");

            migrationBuilder.DropIndex(
                name: "IX_UserFitnessStats_GenderId",
                table: "UserFitnessStats");

            migrationBuilder.DropIndex(
                name: "IX_UserFitnessStats_GoalId",
                table: "UserFitnessStats");

            migrationBuilder.DropColumn(
                name: "ActivityLevelId",
                table: "UserFitnessStats");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "UserFitnessStats");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "UserFitnessStats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CalculatedMetrics");

            migrationBuilder.AddColumn<string>(
                name: "ActivityLevel",
                table: "UserFitnessStats",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "UserFitnessStats",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "UserFitnessStats",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
