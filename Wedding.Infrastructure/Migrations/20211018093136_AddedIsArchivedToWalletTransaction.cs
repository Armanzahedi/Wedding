using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedIsArchivedToWalletTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "WalletTransactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "a51db41f-624d-44dd-bdcb-0945f49c131b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "543a7deb-895d-4616-90f3-6149831381fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "c5f0dafa-d7c1-460a-9bb5-314f796b1a74");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "703649b4-74c7-48f9-a90d-d88bf0e2cefc", "AQAAAAEAACcQAAAAEMaJwLzngjoNDxCrzdlBVLzPbE9NwQfHNL6vR6E0dnMXP1kVBq2drwQMZfsnZYhq6g==", "900594f1-2bdc-4824-908c-0bab8c829709" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6f4a55c-9d7a-4e05-af87-f7aebfecffb5", "AQAAAAEAACcQAAAAECsYfJ4+cS8B5ay2UA7b1Uh/arjg2D6GGFahSmbiVnhl4BQqnS85wfHVludQ/KfXRw==", "5a91b919-3228-4629-9966-2e7ead595c1b" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 18, 13, 1, 36, 74, DateTimeKind.Local).AddTicks(6509));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "WalletTransactions");

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
    }
}
