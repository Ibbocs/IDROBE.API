using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDrobeAPI.Persistence.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "BrandName");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BrandName", "CreatedDate", "Description", "UpdateDate" },
                values: new object[] { "Electronics & Beauty", new DateTime(2024, 2, 6, 1, 31, 54, 704, DateTimeKind.Local).AddTicks(686), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandName", "CreatedDate", "Description", "UpdateDate" },
                values: new object[] { "Shoes", new DateTime(2024, 2, 6, 1, 31, 54, 704, DateTimeKind.Local).AddTicks(736), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandName", "BrandType", "CreatedDate", "Description", "UpdateDate" },
                values: new object[] { "Industrial & Outdoors", "Brands", new DateTime(2024, 2, 6, 1, 31, 54, 704, DateTimeKind.Local).AddTicks(820), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 6, 1, 31, 54, 704, DateTimeKind.Local).AddTicks(3348), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 6, 1, 31, 54, 704, DateTimeKind.Local).AddTicks(3356), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 6, 1, 31, 54, 704, DateTimeKind.Local).AddTicks(3358), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 6, 1, 31, 54, 704, DateTimeKind.Local).AddTicks(3360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 6, 1, 31, 54, 710, DateTimeKind.Local).AddTicks(6379), "Maiores ipsam non magnam voluptatibus.", "Est.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 6, 1, 31, 54, 710, DateTimeKind.Local).AddTicks(6485), "Dolore esse ut quae qui.", "Sint officiis.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 6, 1, 31, 54, 710, DateTimeKind.Local).AddTicks(6588), "Voluptas nobis odio quis ea.", "Quia.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "CreatedDate", "ImagePath", "Price", "Title", "UpdateDate" },
                values: new object[] { "teal", new DateTime(2024, 2, 6, 1, 31, 54, 721, DateTimeKind.Local).AddTicks(5), "http://lorempixel.com/640/480/transport", 721.26m, "Licensed Fresh Chips", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "CreatedDate", "Description", "ImagePath", "Price", "Title", "UpdateDate" },
                values: new object[] { "yellow", new DateTime(2024, 2, 6, 1, 31, 54, 721, DateTimeKind.Local).AddTicks(143), "The Football Is Good For Training And Recreational Purposes", "http://lorempixel.com/640/480/technics", 575.77m, "Tasty Fresh Fish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BrandName",
                table: "Brands",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(3482), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Shoes, Garden & Beauty", new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(3514), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Books", new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandType", "CreatedDate", "Description", "Name", "UpdateDate" },
                values: new object[] { "Brends", new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(3543), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Kids & Movies", new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(3516) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(5242), new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(5240) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(5245), new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(5244) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(5248), new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(5247) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(5251), new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(5250) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 487, DateTimeKind.Local).AddTicks(2455), "Unde magni corporis alias velit.", "Non.", new DateTime(2024, 2, 4, 3, 30, 52, 487, DateTimeKind.Local).AddTicks(2224) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 487, DateTimeKind.Local).AddTicks(2532), "Quas dignissimos aut temporibus et.", "Quos aspernatur.", new DateTime(2024, 2, 4, 3, 30, 52, 487, DateTimeKind.Local).AddTicks(2459) });

            migrationBuilder.UpdateData(
                table: "CategoryDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 487, DateTimeKind.Local).AddTicks(2592), "Quidem dolores porro dolores at.", "Reiciendis.", new DateTime(2024, 2, 4, 3, 30, 52, 487, DateTimeKind.Local).AddTicks(2534) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "CreatedDate", "ImagePath", "Price", "Title", "UpdateDate" },
                values: new object[] { "gold", new DateTime(2024, 2, 4, 3, 30, 52, 495, DateTimeKind.Local).AddTicks(3391), "http://lorempixel.com/640/480/people", 456.42m, "Licensed Rubber Salad", new DateTime(2024, 2, 4, 3, 30, 52, 495, DateTimeKind.Local).AddTicks(3169) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "CreatedDate", "Description", "ImagePath", "Price", "Title", "UpdateDate" },
                values: new object[] { "sky blue", new DateTime(2024, 2, 4, 3, 30, 52, 495, DateTimeKind.Local).AddTicks(3449), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "http://lorempixel.com/640/480/nature", 283.64m, "Rustic Granite Chips", new DateTime(2024, 2, 4, 3, 30, 52, 495, DateTimeKind.Local).AddTicks(3396) });
        }
    }
}
