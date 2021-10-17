using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedWalletRelatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentAccountNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CardNumber = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAccountNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentAccountNumbers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Balance = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WalletId = table.Column<int>(nullable: false),
                    Amount = table.Column<long>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    TransactionStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "3da52a30-a7b5-402d-bb93-22c291fed912");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "2df8025e-d1ff-48be-8ecc-34d701818f50");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "95ffc365-625d-4a2f-87f9-da290ec0531b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "213deb7d-20fa-4e84-b0ee-186e243b5c0e", "AQAAAAEAACcQAAAAECrWM9w3Cx5x5n75A0DO91Zbtilc3Z78P+Rbxy/KlzWY5UGAJqzJJp+Z+nw+AwmV0g==", "0dc067cd-abd9-4a6c-b941-42ebc9f1bf7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4472b41c-6c3e-4561-a9e0-a148f07ce078", "AQAAAAEAACcQAAAAEJMHiLVgpKhvimmV2wK0z86fmSStV0pVd4KXTZK7kQs41yUFNb+8bjjYLlkFZops6Q==", "d118f28b-2244-46c3-af98-0e79798f5764" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 16, 11, 59, 26, 490, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAccountNumbers_CustomerId",
                table: "PaymentAccountNumbers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_CustomerId",
                table: "Wallets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_WalletId",
                table: "WalletTransactions",
                column: "WalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentAccountNumbers");

            migrationBuilder.DropTable(
                name: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "9dda1427-312f-46ee-91c2-f689a9374e9b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "9334f1d5-9891-479b-b4ec-7591537504a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "21b14b3d-70b0-4dd5-aac7-0a5c7377197e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4acb5b22-2f29-4e57-ba04-97be1d1bbfe5", "AQAAAAEAACcQAAAAEBnvrA96KfZopzzzRkn/CxIugNr7OSJdjZ6shYSVjkq4CPAV7PtBO28C7aboMML2fQ==", "05295c1d-b042-479f-8d58-c0bb0b2e148e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c9ffbb9-a95c-419f-9b32-e37acbcf3e18", "AQAAAAEAACcQAAAAEITl/o8h90KCK4eJylGHS8ybuE+WF1GR+A4Hs8s7s7kfoGoesv9bwnrGto8aPKQCtw==", "cf42b351-7270-4f07-a8ef-b51856c2738c" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 12, 16, 4, 10, 109, DateTimeKind.Local).AddTicks(4063));
        }
    }
}
