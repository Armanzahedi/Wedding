using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class ChangedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "a09e29c1-c512-47ef-b690-33c9a16c9183");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "e1b5c064-35da-4ea7-b588-e97cdc40159f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "d2c0083e-9f56-40c0-bb65-df8f1cc8ccf0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59859994-2767-421a-9da0-15e0ce98402d", "AQAAAAEAACcQAAAAEEzpxIQ4jszuwmo8/ovPm6vGQKk8BqrMBDT0ZWBtNaTHCOE+DDHRuzwrb7931C1hJg==", "8a0763ea-9e46-43af-acbb-00727b342bb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4915ed1-7213-4f9b-b8c2-43b332c9489c", "AQAAAAEAACcQAAAAEIzGxJBlhJihV4jNZ6B2bPiFREC6vb6LZk7u9dnCaDzxCH1CSecerxILvGcV9icBMg==", "f6b1cfc2-1a93-4654-8c08-ce347398015f" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 28, 17, 28, 31, 509, DateTimeKind.Local).AddTicks(1032));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "81d980dd-c149-44dc-9f9e-5d14a87d30eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "847d5bec-f207-4d8e-8987-e2944020d7bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "e5caf3b0-c729-4fce-9b51-874ef321fc45");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e798986-240d-4328-ae93-faa74ba44798", "AQAAAAEAACcQAAAAEAa5Kr7nYVul1X/z1QF/3HChFiEyFOIas2EaEgA+eZ+z54C9z4xXIjXWVL3bumXgfw==", "e6ca0ec4-375e-4417-b9ca-786876dab682" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f22b83b-eee9-486e-858a-2d2987cf624c", "AQAAAAEAACcQAAAAEPXOztv9L0Ot3CJLCS1RCle2bv+bvQJRxyBHsquKabJ7+tft0Mbw9Dygtxj8Y2CoXg==", "44f8ec4f-d305-4442-8d7a-cb2e25d671e6" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 28, 15, 17, 46, 266, DateTimeKind.Local).AddTicks(6459));
        }
    }
}
