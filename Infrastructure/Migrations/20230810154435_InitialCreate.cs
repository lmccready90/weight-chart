using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightLog", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Description", "Symbol" },
                values: new object[,]
                {
                    { 1, "Pounds", "lb" },
                    { 2, "Kilograms", "kg" },
                    { 3, "Stone", "st" }
                });

            migrationBuilder.InsertData(
                table: "WeightLog",
                columns: new[] { "Id", "Date", "Unit", "Weight" },
                values: new object[,]
                {
                    { new Guid("211627cf-ebf9-4a9e-9cab-a2c52c09c9c2"), new DateTime(2023, 5, 10, 15, 44, 35, 805, DateTimeKind.Utc).AddTicks(1602), 1, 212m },
                    { new Guid("317beecf-3fce-4f7d-9639-6d83a017a6b5"), new DateTime(2023, 4, 10, 15, 44, 35, 805, DateTimeKind.Utc).AddTicks(1599), 1, 216m },
                    { new Guid("5bf4ce4c-13b1-469e-9e6a-c082410a88c2"), new DateTime(2023, 3, 10, 15, 44, 35, 805, DateTimeKind.Utc).AddTicks(1589), 1, 220m },
                    { new Guid("6e6e3f65-16bc-43ac-b29a-149444ce933b"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), 1, 200m },
                    { new Guid("a1a030c7-c45e-4c74-8df2-ee22396f91c9"), new DateTime(2023, 6, 10, 15, 44, 35, 805, DateTimeKind.Utc).AddTicks(1603), 1, 208m },
                    { new Guid("ea6963b2-09f1-4c29-9deb-d45cb04ceb48"), new DateTime(2023, 7, 10, 15, 44, 35, 805, DateTimeKind.Utc).AddTicks(1605), 1, 204m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "WeightLog");
        }
    }
}
