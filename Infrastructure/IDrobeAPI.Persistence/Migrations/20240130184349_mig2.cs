using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDrobeAPI.Persistence.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryDetailsValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDetailsValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDetailsValue_CategoryDetails_CategoryDetailId",
                        column: x => x.CategoryDetailId,
                        principalTable: "CategoryDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryDetailsValue_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(3314), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Computers", new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(3225) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(3340), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Music", new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(3352), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Computers", new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(3341) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(5171), new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(5175), new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(5173) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(5177), new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(5176) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(5180), new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(5179) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 406, DateTimeKind.Local).AddTicks(3057), "Consequatur iusto est libero quis.", "Voluptatibus.", new DateTime(2024, 1, 30, 22, 43, 48, 406, DateTimeKind.Local).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 406, DateTimeKind.Local).AddTicks(3118), "Eveniet non officia molestiae ab.", "Vel aperiam.", new DateTime(2024, 1, 30, 22, 43, 48, 406, DateTimeKind.Local).AddTicks(3059) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 406, DateTimeKind.Local).AddTicks(3165), "Sit repellat et corrupti quae.", "Sunt.", new DateTime(2024, 1, 30, 22, 43, 48, 406, DateTimeKind.Local).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Price", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 411, DateTimeKind.Local).AddTicks(3418), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 321.15m, "Rustic Frozen Bacon", new DateTime(2024, 1, 30, 22, 43, 48, 411, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Price", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 411, DateTimeKind.Local).AddTicks(3457), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 507.91m, "Rustic Frozen Soap", new DateTime(2024, 1, 30, 22, 43, 48, 411, DateTimeKind.Local).AddTicks(3420) });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDetailsValue_CategoryDetailId",
                table: "CategoryDetailsValue",
                column: "CategoryDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDetailsValue_ProductId",
                table: "CategoryDetailsValue",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryDetailsValue");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(5886), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Industrial", new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(6430), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Jewelery, Tools & Sports", new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(5904) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(6447), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Toys", new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(6432) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(7792), new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(7789) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(7794), new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(7793) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(7797), new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(7796) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(7799), new DateTime(2024, 1, 30, 21, 5, 48, 42, DateTimeKind.Local).AddTicks(7798) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 45, DateTimeKind.Local).AddTicks(914), "Nostrum velit eum magni soluta.", "Suscipit.", new DateTime(2024, 1, 30, 21, 5, 48, 45, DateTimeKind.Local).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 45, DateTimeKind.Local).AddTicks(969), "Tempora nemo repellat nihil soluta.", "Ea nisi.", new DateTime(2024, 1, 30, 21, 5, 48, 45, DateTimeKind.Local).AddTicks(917) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 45, DateTimeKind.Local).AddTicks(1093), "Corporis quidem et eum quo.", "Mollitia.", new DateTime(2024, 1, 30, 21, 5, 48, 45, DateTimeKind.Local).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Price", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 49, DateTimeKind.Local).AddTicks(821), "The Football Is Good For Training And Recreational Purposes", 41.74m, "Sleek Granite Pants", new DateTime(2024, 1, 30, 21, 5, 48, 49, DateTimeKind.Local).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Price", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 5, 48, 49, DateTimeKind.Local).AddTicks(864), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 893.78m, "Rustic Concrete Chips", new DateTime(2024, 1, 30, 21, 5, 48, 49, DateTimeKind.Local).AddTicks(823) });
        }
    }
}
