using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class RemovedInformationFromUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Information",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "29c4846c-f891-4cf5-afbc-7cd52d9827c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "8af0fd1a-400c-4402-b72d-2baa3ce478db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "59f54651-0103-4b12-aa99-8e8299aa22d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db260137-14a1-4e83-b13c-833c0c8d977f", "AQAAAAEAACcQAAAAEMplllnldOsX5SAYKX/RkYfqtsY2N3NiE9wBCIAFCEZMTkpEDdZIFygIhoaOtG/iEA==", "add63e67-cace-4125-92b1-5e685e1015b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1799792e-d18d-4c93-b6c2-e385bad4222d", "AQAAAAEAACcQAAAAEMdtDbEwcqxbn7rwhi5cCWbB7vukltx62EbAGQdWjYgyKVSOel7u1+0TTIt6twU9Wg==", "8cb5de20-be0e-4d8e-a694-196af15d4ddf" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 29, 10, 40, 1, 362, DateTimeKind.Local).AddTicks(3316));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
