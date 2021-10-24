using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdPurchaseHistory_Payments_PaymentId",
                table: "AdPurchaseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Payments_PaymentId",
                table: "WalletTransactions");

            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_PaymentId",
                table: "WalletTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_AdPurchaseHistory_PaymentId",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ProcessedDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ActivateDate",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "AdPurchaseStatus",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "OnlinePayment",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "AdPurchaseHistory");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "WalletTransactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "AdPurchaseHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Invoices",
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
                    InvoiceType = table.Column<int>(nullable: false),
                    InvoicePaymentMethod = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ProcessedDate = table.Column<DateTime>(nullable: false),
                    IsPayed = table.Column<bool>(nullable: false),
                    Amount = table.Column<long>(nullable: false),
                    WalletAmount = table.Column<long>(nullable: false),
                    PaymentAmount = table.Column<long>(nullable: false),
                    Receipt = table.Column<string>(nullable: true),
                    IsReviewed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "c8aae8a6-fb10-4a27-b0b2-255d34991089");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "da2a7a64-bcf7-40a1-b295-2c54a022203b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "8825d4e8-6fd1-427e-8309-93d9721ab225");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a371fabb-269c-4d51-816f-06b1be99d4db", "AQAAAAEAACcQAAAAEDKvEIANFZRhY8giLRWbbH6HroNSQDkGgrjE7XMDoMazYS5im5H5XFGPQ46IrCVlnA==", "e9bc0926-5997-436f-8700-0e58076e5202" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b62c4c59-58ba-4c85-a86a-beb8d5733db7", "AQAAAAEAACcQAAAAEKMZxegUcQAMtu0kCdEVVBmdqzILMq7QTpl7sppl2kB5w+6tSrzAndnB55Ds+Wz0gA==", "1a61721d-8fcf-440f-b9d2-d5dcc52af70d" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 24, 23, 4, 44, 552, DateTimeKind.Local).AddTicks(3789));

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_InvoiceId",
                table: "WalletTransactions",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AdPurchaseHistory_InvoiceId",
                table: "AdPurchaseHistory",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdPurchaseHistory_Invoices_InvoiceId",
                table: "AdPurchaseHistory",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Invoices_InvoiceId",
                table: "WalletTransactions",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdPurchaseHistory_Invoices_InvoiceId",
                table: "AdPurchaseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Invoices_InvoiceId",
                table: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_InvoiceId",
                table: "WalletTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_AdPurchaseHistory_InvoiceId",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "AdPurchaseHistory");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "WalletTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessedDate",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivateDate",
                table: "AdPurchaseHistory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdPurchaseStatus",
                table: "AdPurchaseHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "AdPurchaseHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OnlinePayment",
                table: "AdPurchaseHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "AdPurchaseHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Receipt",
                table: "AdPurchaseHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "51ba4afe-4337-471a-9c98-7fc4b218e53b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "479bdb4b-150c-433c-9842-f5fbc3102234");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "73114756-930c-4d40-a397-f5cf2063abfd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a3140f9-4951-41ab-a031-33423b7baf8c", "AQAAAAEAACcQAAAAEDTvPtGv84c8KlIbHfkjv4j9BlpzWSv+qlBx54mQ/9K/nMuZuEAitqzl4YCs4JwzTw==", "3fde8a15-29a1-4614-8686-618466607faa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d731124-7e3a-4b55-b6f4-fd56bd3eb43d", "AQAAAAEAACcQAAAAEPP9fDL9le3AKjiJDZAC8jvTgL4Ak4XFLnOdmYYqV2P2nahgXHJh0zCxMRoYPVGGCw==", "96c7b9af-311c-4551-b08b-e7edf1366854" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 24, 19, 52, 21, 421, DateTimeKind.Local).AddTicks(5671));

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_PaymentId",
                table: "WalletTransactions",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AdPurchaseHistory_PaymentId",
                table: "AdPurchaseHistory",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdPurchaseHistory_Payments_PaymentId",
                table: "AdPurchaseHistory",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Payments_PaymentId",
                table: "WalletTransactions",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
