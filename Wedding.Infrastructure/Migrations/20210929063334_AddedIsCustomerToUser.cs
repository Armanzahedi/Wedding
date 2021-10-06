using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedIsCustomerToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Customer",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "8e87ae4c-e497-425a-9e73-f74864b53208");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "2e5789dc-03f0-4465-bca1-c2fc41c77fa7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "ef201f65-c2b1-49bd-acf1-f80fc899966e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f2d3785-7926-4056-9952-ee99a5d14c5d", "AQAAAAEAACcQAAAAEMK/GjSGOrh0fzFCyQpbVk6xD5YeLHuohhjNgf6Ll5gimlpqlmfshVlEmBkSCpNBVA==", "78a25bfd-00a1-44a3-90ea-3dc9b600f987" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e668d6e-5c30-4163-8b17-782b70ee7eae", "AQAAAAEAACcQAAAAEI5iup5qdWlXaxfNP9rcAjP56AaLhVL9K9Y1k924ghGMYWo7+z85TnECZBaSGJhFBA==", "e27ab4ac-e31e-44d0-8a56-27616efa0c7a" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 29, 10, 3, 32, 859, DateTimeKind.Local).AddTicks(4438));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "AspNetUsers");

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
    }
}
