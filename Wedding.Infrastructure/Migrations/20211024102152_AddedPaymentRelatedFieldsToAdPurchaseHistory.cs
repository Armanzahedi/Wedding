using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedPaymentRelatedFieldsToAdPurchaseHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActivateDate",
                table: "AdPurchaseHistory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdPurchaseStatus",
                table: "AdPurchaseHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Contract",
                table: "AdPurchaseHistory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OnlinePayment",
                table: "AdPurchaseHistory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "AdPurchaseHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Receipt",
                table: "AdPurchaseHistory",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "0db7bdef-2817-478d-a85c-90a784de13fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "560e0f81-f541-497c-b8e9-37d8793fc71c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "c460f4e3-3e33-423f-b171-2b5211ca6150");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "995a02b6-c03d-4418-8c42-7ceeafb6ee40", "AQAAAAEAACcQAAAAELH/ZxauNsuer2bwXAlWEhiNpOttA9j6g75l6J8OD/CYM7g+mBbpOKkkTHRvBq75KA==", "8793d295-cc02-49a4-bbc0-6db3b0538fb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c6cee9e-a1c3-480f-a550-59c0a1cc82c3", "AQAAAAEAACcQAAAAEK6pdO5TwG2ahxAwSUWHCxyBPe0/sk6Y9zBjvb+jVaXZ6OYChJ9eVs6uv4S2CaDzYA==", "b35d446a-2dbb-43bf-bad6-2c431c96fc93" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 24, 13, 51, 51, 950, DateTimeKind.Local).AddTicks(6488));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdPurchaseHistory_Payments_PaymentId",
                table: "AdPurchaseHistory");

            migrationBuilder.DropIndex(
                name: "IX_AdPurchaseHistory_PaymentId",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "ActivateDate",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "AdPurchaseStatus",
                table: "AdPurchaseHistory");

            migrationBuilder.DropColumn(
                name: "Contract",
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "cd3117c1-103a-4b6d-80b0-3828f2e14f07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "ede6686e-8882-40ed-94cb-47afac1781b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "0a219011-dc5f-4f81-95dd-e7b43c04b6f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72ae279e-4559-4c46-8852-6f8050f8f619", "AQAAAAEAACcQAAAAEBdYuNTMXCGM21eKjLpfdt8jr0A0q8V5PkwKVTx+iQREKE3J3hYz518iee7PVkHADQ==", "0d649fbc-b3f1-4e58-af27-987e887ea52b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f042154-4a8a-4a82-b584-8bcd8add8699", "AQAAAAEAACcQAAAAEO68zUj0o2mCxwHWnUYjrb6gEbqLeJKN2urvSnehoh5emDOtt7R+YjlAvSpmqm6lhw==", "e555e1bf-1998-4c86-896f-3d9758882fb4" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 21, 2, 13, 10, 134, DateTimeKind.Local).AddTicks(8660));
        }
    }
}
