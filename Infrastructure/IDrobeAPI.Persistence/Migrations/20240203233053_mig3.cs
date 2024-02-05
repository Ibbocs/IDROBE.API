using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDrobeAPI.Persistence.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArmType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClothesType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CreatedDate", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(3543), "Kids & Movies", new DateTime(2024, 2, 4, 3, 30, 52, 482, DateTimeKind.Local).AddTicks(3516) });

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
                columns: new[] { "ArmType", "ClothesType", "Color", "CreatedDate", "Description", "ImagePath", "IsNew", "Length", "Price", "Size", "Title", "UpdateDate" },
                values: new object[] { "Nem2", "Nem", "gold", new DateTime(2024, 2, 4, 3, 30, 52, 495, DateTimeKind.Local).AddTicks(3391), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "http://lorempixel.com/640/480/people", true, 15.3m, 456.42m, "M", "Licensed Rubber Salad", new DateTime(2024, 2, 4, 3, 30, 52, 495, DateTimeKind.Local).AddTicks(3169) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArmType", "ClothesType", "Color", "CreatedDate", "Description", "ImagePath", "IsNew", "Length", "Price", "Size", "Title", "UpdateDate" },
                values: new object[] { "Nem2", "Nem", "sky blue", new DateTime(2024, 2, 4, 3, 30, 52, 495, DateTimeKind.Local).AddTicks(3449), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "http://lorempixel.com/640/480/nature", true, 15.3m, 283.64m, "M", "Rustic Granite Chips", new DateTime(2024, 2, 4, 3, 30, 52, 495, DateTimeKind.Local).AddTicks(3396) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ClothesType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

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
                columns: new[] { "CreatedDate", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(3352), "Computers", new DateTime(2024, 1, 30, 22, 43, 48, 403, DateTimeKind.Local).AddTicks(3341) });

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
                columns: new[] { "CreatedDate", "Description", "ImagePath", "Price", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 411, DateTimeKind.Local).AddTicks(3418), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "http://lorempixel.com/640/480/fashion", 321.15m, "Rustic Frozen Bacon", new DateTime(2024, 1, 30, 22, 43, 48, 411, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "ImagePath", "Price", "Title", "UpdateDate" },
                values: new object[] { new DateTime(2024, 1, 30, 22, 43, 48, 411, DateTimeKind.Local).AddTicks(3457), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "http://lorempixel.com/640/480/sports", 507.91m, "Rustic Frozen Soap", new DateTime(2024, 1, 30, 22, 43, 48, 411, DateTimeKind.Local).AddTicks(3420) });
        }
    }
}
