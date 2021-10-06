using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class ChangedAdCustomerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PurchaseType",
                table: "AdPurchaseHistory");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Ads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "d84b49a3-5bed-4688-acce-0960012872f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "6ffa3ed5-7335-4d10-a578-0100f9f18785");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "e24eebbc-3fd5-4f81-8143-c8faa9338cf6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "708d4210-a5a1-4bc2-9544-453349465fcd", "AQAAAAEAACcQAAAAEEek1wrRoYfj1my3ZvG+FJpKXBT3ptFk+0Smj5sMt4vyxvMyGaJ8kDlYgVsb+q+VTA==", "8cdcb810-bb5c-42f1-a42c-fdc9531e2878" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c27723-245c-47b5-bcef-75c94e90ee78", "AQAAAAEAACcQAAAAEARJHUUB+5srAnEkcQ7gcZ18h6SC93JSZuVf5YVPo0DanbRs+NImZ9C2/ePXDIx74g==", "d5dfe8a9-45e6-45e1-85b7-c5d81fd1d864" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 15, 6, 53, 959, DateTimeKind.Local).AddTicks(5928));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseType",
                table: "AdPurchaseHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
