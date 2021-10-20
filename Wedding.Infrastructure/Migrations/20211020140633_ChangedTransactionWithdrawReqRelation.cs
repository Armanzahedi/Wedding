using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class ChangedTransactionWithdrawReqRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_WithdrawalRequests_WithdrawalRequestId",
                table: "WalletTransactions");

            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_WithdrawalRequestId",
                table: "WalletTransactions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "fca485b4-e9d8-4c51-8ce2-5fdce4eb4ba8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "5bc630a7-67ca-4ac4-a304-8b335894d5be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "65dcd378-03c2-4844-be58-349b2cc1815c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9003d251-87fe-4510-806f-b7067416a13a", "AQAAAAEAACcQAAAAEHkfcy+aecD+G+JZ/HVXMoqCM0/9XjbHb+I8cwClEoQXUKK+f4/e+UqL4dT27C8ORw==", "12ec94ce-953f-46ac-89f9-847c1b6c9bc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8a25d41-6a03-4fba-9b1d-09f2bce90109", "AQAAAAEAACcQAAAAEJhL+ZJXYyZrgDm3dwg7gjTlKq/5c2/P34J0cL3IiGW+SwP2HQSCcxh4KtyXoX9IXQ==", "8dd5b95b-8998-4d8e-8186-60fbc650b7e0" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 20, 17, 36, 33, 314, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalRequests_WalletTransactionId",
                table: "WithdrawalRequests",
                column: "WalletTransactionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WithdrawalRequests_WalletTransactions_WalletTransactionId",
                table: "WithdrawalRequests",
                column: "WalletTransactionId",
                principalTable: "WalletTransactions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WithdrawalRequests_WalletTransactions_WalletTransactionId",
                table: "WithdrawalRequests");

            migrationBuilder.DropIndex(
                name: "IX_WithdrawalRequests_WalletTransactionId",
                table: "WithdrawalRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "a2195773-176a-4074-812e-c651328944e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "4ada51f9-c2ce-41d6-94af-4191be7bdcfe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "bde536c0-e89b-4d0e-86f4-97fb21852cd5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0b20338-79ea-4f1d-b018-5f1bad40446c", "AQAAAAEAACcQAAAAEOl3j358GQr2LJGgAn9BD5EjbzJQ3bm/JydYRpQQeC4qj+vHlvEiCrJPGS/iRuPNmg==", "f7bf64f7-6910-4579-9159-40e521192dcf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10538010-f175-4b40-aaa6-3c1ddf14cbbf", "AQAAAAEAACcQAAAAEHPWBY/5qer7gSdPCtrB/dswrET1nOn/2aPFZv4a4lq9aRy7PjEkgL03R1C63Ep+7Q==", "596abe17-4d80-4727-841a-7a5b5857f4c9" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 20, 13, 32, 33, 30, DateTimeKind.Local).AddTicks(8802));

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_WithdrawalRequestId",
                table: "WalletTransactions",
                column: "WithdrawalRequestId",
                unique: true,
                filter: "[WithdrawalRequestId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_WithdrawalRequests_WithdrawalRequestId",
                table: "WalletTransactions",
                column: "WithdrawalRequestId",
                principalTable: "WithdrawalRequests",
                principalColumn: "Id");
        }
    }
}
