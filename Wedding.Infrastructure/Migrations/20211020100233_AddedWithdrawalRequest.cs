using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedWithdrawalRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WithdrawalRequestId",
                table: "WalletTransactions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WithdrawalRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WalletTransactionId = table.Column<int>(nullable: false),
                    PaymentAccountId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    ProcessDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithdrawalRequests_PaymentAccounts_PaymentAccountId",
                        column: x => x.PaymentAccountId,
                        principalTable: "PaymentAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalRequests_PaymentAccountId",
                table: "WithdrawalRequests",
                column: "PaymentAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_WithdrawalRequests_WithdrawalRequestId",
                table: "WalletTransactions",
                column: "WithdrawalRequestId",
                principalTable: "WithdrawalRequests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_WithdrawalRequests_WithdrawalRequestId",
                table: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "WithdrawalRequests");

            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_WithdrawalRequestId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "WithdrawalRequestId",
                table: "WalletTransactions");

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
        }
    }
}
