using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class FixedGeoDivision3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeoDivisions");

            migrationBuilder.DropColumn(
                name: "IsLeaf",
                table: "GeoDivisions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "2ff9835c-0680-42e5-af3b-c4a3e534930d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "c38c2307-e775-45a5-9283-6251564fa945");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "53540317-d521-4644-af92-ad9498c3399d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20362610-1c33-4814-8262-a930c5b63bc2", "AQAAAAEAACcQAAAAEHZsDg10MYsQwFm30lL/vKvImtPQgTPGaUu1AMu8KzYNS5qnnnWUYyU+0/3NH+WMiw==", "5523eaaa-dc15-43a4-95c1-4698ad1c8211" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f426f185-79c1-413c-8e7c-e0455c98ff93", "AQAAAAEAACcQAAAAEOX7hMAwXvm54YEEUoaai44ZVW13CKm9kzPhWZEPCWzvRgr8z2xPQOPh3B85L76BzQ==", "0e8ebc28-1cb0-492c-b1de-dffd80f6c8e9" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 15, 18, 41, 295, DateTimeKind.Local).AddTicks(1167));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsArchived",
                table: "GeoDivisions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsLeaf",
                table: "GeoDivisions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "4cde706f-5fc4-415d-acff-ea62a1f21dac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "488a46ba-210c-4563-81d5-3f1ac8011672");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "7d8eee0c-3af9-429e-b6c4-0e41b71dd60e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3507959-fe86-4f23-bd79-c5ddecf8e1dd", "AQAAAAEAACcQAAAAENsI5jzgLzwmOGrHTZbnKItcU+006eqQk4gVLowm+zl7BwJCmXIPKPHCbVE90hcKbQ==", "15947b1d-3e9b-4d65-8ca9-d0329f6ece84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c6c4c75-9f93-46aa-bf27-e959f4a33881", "AQAAAAEAACcQAAAAELgs7+7KduV0DYkTjuKlOwbLe/oXPq4S7vu8SP8S+4Wkm3V+PQ4jPIGQEg5xrMP14g==", "e61d74d5-69aa-44c1-bce3-33f8fd3305be" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 15, 17, 42, 357, DateTimeKind.Local).AddTicks(6156));
        }
    }
}
