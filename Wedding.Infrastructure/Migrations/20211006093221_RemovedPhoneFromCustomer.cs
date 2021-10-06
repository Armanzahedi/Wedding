using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class RemovedPhoneFromCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "8d4ff9ef-64b5-4da9-ab8d-5123fc956ce2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "01f4d959-c303-4441-918f-29b3a24cd045");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "3713c897-f209-4dd6-9815-68836042b593");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67bfa5fe-a4e7-43f2-a12f-9420fa743be7", "AQAAAAEAACcQAAAAEGhKLRDcV25Ei8Y+0Ov1QlyeuNULlwLFZxF1CmOqaC8iHylW5WIFykKS9bVy0LYnlA==", "43702c3d-314f-4fac-9004-f3e83b1d64da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c98f82f1-d477-46f8-8cca-2c326d8bc68c", "AQAAAAEAACcQAAAAEIL66Bc8nBmYd3XXnPpAm+SiM7uVLM9WvI//vuJAX4oUZ39osKVhgb52/JDr7wVrtA==", "54a8fd8a-c562-41e5-8f04-c4cd166cf78a" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 13, 2, 21, 123, DateTimeKind.Local).AddTicks(4668));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "fc1571de-ff4e-4c70-8fb3-f2b21db03a0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "1e1c7ffa-d972-48c6-a4fc-f7ffcef3c1e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "34a55110-2afd-4395-afab-ded67463dfda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4845667a-73b1-4910-aeea-497c608be98c", "AQAAAAEAACcQAAAAEGrROdBeYvEmaKkHL6PIN2A5ZVLeZk4DVW2ixgOTI9/V3fi44XIVJ86yv085C9cpXw==", "537d5a0e-a1cc-4f49-a823-11441ad8c880" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f51e835e-891f-46d4-8bef-361eba7fa57a", "AQAAAAEAACcQAAAAEK6GV79PHm+YE2FNh/3vCYzfK/BfVu7TbJVLJZKGH1CZqjXK4fQWuVaP6FJITvA2aw==", "b6e49aa0-9fb3-4bcc-ad17-1ae5e1f3b5a2" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 12, 40, 24, 14, DateTimeKind.Local).AddTicks(7799));
        }
    }
}
