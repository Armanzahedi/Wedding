using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedPayments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessedDate",
                table: "Payments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "9e4140c3-cf5c-4d42-9648-07f485dc9e8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "0d11489d-cd97-4fb1-9dbf-fe948a439754");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "f390ed0f-533d-465f-8478-3a7bb0dbb6da");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3414f512-ac45-4f05-8004-11060859c19f", "AQAAAAEAACcQAAAAEIizLyAnmmntaGtYOrATiBGvI8pH6BB7oZgv8lEKEQZgyeE2slJaUvzsUKuojGD2+Q==", "6e0b0b72-6c4e-42c3-9153-db18ee94c6d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33c4dfdb-a168-45e8-8b8a-8cf510574601", "AQAAAAEAACcQAAAAEPSJAmDF097/hAjtbdvms/nC0EqHova9fgM46j2vwg2gys2BBVMNj+y4mRhVoxLeLQ==", "89afc6bf-37e2-4cc3-b80b-595efebd464a" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 18, 13, 0, 29, 552, DateTimeKind.Local).AddTicks(9735));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessedDate",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "6e1f953e-ab33-4b58-a5d9-9cd259b3b1ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "16f31061-5c9e-4b9c-8243-41a1404645e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "b923e25c-d67a-4631-93de-b4edc1dfedc3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb83b6a4-576a-4592-83b4-20428b39e353", "AQAAAAEAACcQAAAAEA8/pJDZnQi/jUCngiOtXuP3/3go4KwXCdUyzhMAFkSsx/SjzYndeDzqxbl3A9LHxg==", "d751256e-8c92-47b8-a96d-c546a048e6fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "566a6245-2413-4f59-8433-f1e124c6370e", "AQAAAAEAACcQAAAAED6ApJBLTecF1PWdDqykGdHWULiiGxAI+xjUv1AFGeVGY0lThlf8gVRinDDZRtbotQ==", "b9cc46f2-19e1-435c-96b4-f2f81381a6cc" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 18, 12, 54, 39, 818, DateTimeKind.Local).AddTicks(7460));
        }
    }
}
