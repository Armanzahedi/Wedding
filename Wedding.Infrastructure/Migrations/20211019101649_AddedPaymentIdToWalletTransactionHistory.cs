using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedPaymentIdToWalletTransactionHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "WalletTransactions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Amount",
                table: "Payments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "6a99ae54-7b79-4196-a248-afb0a233a0b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "2359bfd5-a6cc-4013-9f0c-aa8d0701666f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "770f315d-c3da-4b64-91c7-4296ce3017ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc7580b5-fe0f-48f6-8b56-5e113ddebff9", "AQAAAAEAACcQAAAAECNr7pTAXdYNcdRp9NSjo9uKxlorBPZkDbXRE0a0tw6R1G9aNIgnjRbMBvTLD71gPg==", "fae9b1da-3ce8-4a34-b90e-72c9449df513" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a84374e-2772-4105-95aa-e65c46afe9fa", "AQAAAAEAACcQAAAAEMFXoCWrBbt/JAj9pdGe3JIbBFNHWBdwfnU3i/NmyEhtEB09oTMoks3QVu//7lSDBw==", "ab179112-314b-45bf-89e0-90d8e7cdc242" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 19, 13, 46, 48, 494, DateTimeKind.Local).AddTicks(9765));

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_PaymentId",
                table: "WalletTransactions",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Payments_PaymentId",
                table: "WalletTransactions",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Payments_PaymentId",
                table: "WalletTransactions");

            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_PaymentId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "WalletTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Payments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
    }
}
