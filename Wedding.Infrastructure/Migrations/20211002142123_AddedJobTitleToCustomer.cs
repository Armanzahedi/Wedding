using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedJobTitleToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "68fe9e05-9c76-410d-b753-722ce9096e92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "a3ba9fea-8d06-4daf-8714-ec1e94eb1c68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "a7195647-773f-427b-a09e-1ada0b8b2d17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b500da1a-4fa6-4ca1-86bb-8cf6c02bbe53", "AQAAAAEAACcQAAAAEGD+bmokllbai6KHIf7CjQBLUcTiwSKtkd5ehdZnVhzQVjfBMpWuSi04iT9N0zo5Bg==", "a0badb47-1917-4ad6-b4bf-3ab2dab81390" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f9bbc8d-9edc-4540-9e0b-ee912b8dd148", "AQAAAAEAACcQAAAAEC7oFPSKE4SVllXVvKJ6PGk2KNwKl/kV+shEi7z4qMx9uQ4FQHZNVZcs+tC0q4sfUA==", "4e51ff02-8722-4604-9e38-77d7723d7efe" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 2, 17, 51, 22, 808, DateTimeKind.Local).AddTicks(5487));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "057af061-b04c-4492-88a1-c1c3376386ff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "d5e1a5fa-14c0-4f6f-98af-b28a9a43f56d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "90364d58-f581-44b6-918f-95d64e89f9ef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67e1a20d-24e7-484d-9a93-e2d171d036a2", "AQAAAAEAACcQAAAAENaauaipr05YlDAZZA8C5cp77oGdxA5LdBD+3iNAciM1mB+KJnQHyD7NVwD0gU5AlA==", "fdb6ce96-1851-4cb5-907f-b15f1f3e8ac4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1502b3a-9359-47d7-98dd-f38993db88a3", "AQAAAAEAACcQAAAAENjm++K8FsnEL0IeJCRq54SZPHCzh0JKfXHqF4sLs121N/ak6Pv/zM/kIgxYAAyubA==", "d0952871-b3f8-492a-9c90-4d209061df19" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 2, 17, 31, 50, 940, DateTimeKind.Local).AddTicks(1795));
        }
    }
}
