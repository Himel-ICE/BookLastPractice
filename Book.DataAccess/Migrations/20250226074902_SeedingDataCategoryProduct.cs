using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataCategoryProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryId", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 4, null, 1, "Action" },
                    { 5, null, 1, "Scifi" },
                    { 6, null, 1, "History" },
                    { 20, null, 1, "Drama" },
                    { 30, null, 1, "World War" },
                    { 40, null, 1, "Economy" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageURL", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "John Doe", 4, "A comprehensive guide to learning C#", "978-1-23456-789-0", "", 29.989999999999998, 25.989999999999998, 27.989999999999998, "C# Fundamentals" },
                    { 2, "Jane Smith", 6, "Master ASP.NET Core with practical projects", "978-1-98765-432-1", "", 39.990000000000002, 34.990000000000002, 37.990000000000002, "ASP.NET Core Essentials" },
                    { 11, "John Doe", 20, "A comprehensive guide to learning C#", "978-1-23456-789-0", "", 29.989999999999998, 25.989999999999998, 27.989999999999998, "C# Fundamentals" },
                    { 12, "Jane Smith", 40, "Master ASP.NET Core with practical projects", "978-1-98765-432-1", "", 39.990000000000002, 34.990000000000002, 37.990000000000002, "ASP.NET Core Essentials" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
