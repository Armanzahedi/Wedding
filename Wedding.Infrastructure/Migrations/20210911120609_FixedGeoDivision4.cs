using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class FixedGeoDivision4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GeoDivisions",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LatinTitle",
                table: "GeoDivisions",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "a43a5292-27cc-4b07-9f04-038744a72940");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "ce96b0cb-4986-44ba-a5b6-5a8a707b2acd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "fc362855-1714-460d-84a2-542a52041d10");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8691aaea-419a-445b-81eb-f0cc3ffe7a0e", "AQAAAAEAACcQAAAAEF33Ev2cctxQxxsB9yY5s6PyEjo+CWABfmkbrxUCtsVdoiOXZ4ry6thjNIzdiIHZCA==", "479ec373-24d0-4b7f-a918-dee893247743" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21160f7e-3c18-415a-9065-c0265426faa8", "AQAAAAEAACcQAAAAEIFA5F7za5rE03DzdXOCfFK1//2V+zKqeoWlu9V1k27NNSn7XylJY9QhYOfTPBDaeg==", "ec5fd715-ae69-4695-8496-1746c5a32798" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 16, 36, 8, 296, DateTimeKind.Local).AddTicks(8594));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GeoDivisions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LatinTitle",
                table: "GeoDivisions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

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
    }
}
