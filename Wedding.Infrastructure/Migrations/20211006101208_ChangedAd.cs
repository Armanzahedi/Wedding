using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class ChangedAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Customers_CustomerId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_CustomerId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Ads");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Ads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Ads",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "6e6a3874-7208-449e-bf2b-67e2a9261c32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "0241ed1c-02d7-4ad8-b2c6-d417de8387da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "05df81be-9a39-46cb-98d9-a604198bcc65");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bed4cec-ac44-4e5a-aff3-7b0638646729", "AQAAAAEAACcQAAAAEMAMFoS2DYiPlkEAUz+zko6PG9ir4MJpPCgNZzliDZm1V1lSKIxRT1gYc+nC0tLUAA==", "5d729414-b3c2-4f41-abba-023969215035" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef96dcf0-cf0c-4b31-bc41-e5176003f9c1", "AQAAAAEAACcQAAAAEHcJ6mOYP7bXBeFt3UTZXgT1YLFAEhBXuLE5nCYFy6H5VhFm6jIMSjB3CjCNmm+veg==", "7b153f96-4d41-4826-ba3d-cdd559564659" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 13, 42, 7, 604, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.CreateIndex(
                name: "IX_Ads_JobId",
                table: "Ads",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Jobs_JobId",
                table: "Ads",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Jobs_JobId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_JobId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Ads");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CustomerId",
                table: "Ads",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Customers_CustomerId",
                table: "Ads",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
