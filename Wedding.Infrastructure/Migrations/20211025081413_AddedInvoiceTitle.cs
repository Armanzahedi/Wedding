using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedInvoiceTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Invoices",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "3208d81d-6c0e-4960-90f3-be4ca7afe74b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "91912769-2ac6-46bf-932c-694e8c026c12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "1518cc0c-a21f-4e4e-a359-5a65ea6d3b35");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb9f1003-7a86-482f-a02b-01dc667b0181", "AQAAAAEAACcQAAAAEOUrSMLBuD/wUYokWMCbAKe1Yp66Iy4VvV+3edBUrkn2p3bIORk0V/7kPts6Y7Z4cQ==", "7a1208b0-dc20-42ba-8da1-095ea8dabc0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "463e6773-768b-4f81-b368-acbcb025e587", "AQAAAAEAACcQAAAAEF5p11rNdQuQ+1L5AdtmZnf+b+ttsUZRMKYNIsodZLfgc9cv5L/e02tXKizAKRFtCA==", "64db82fa-01f2-446d-aba3-9eb162bb9348" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 25, 11, 44, 13, 43, DateTimeKind.Local).AddTicks(2186));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Invoices");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "912642fd-3621-4836-a5d3-e34a2dcb5dff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "37cfc697-f576-4b01-a81f-5f68e5c6df8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "c73ba76f-00e6-4c8b-a5ac-2847a50426c0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10f9f180-f793-4ee7-b6f7-139a7b379ea9", "AQAAAAEAACcQAAAAEFinn0sW+I8Z+vedQmFlX7fi3EcHQzF2T4Hvjma+ACB/G9d4mkySCmj96b04CfjrYg==", "fb275892-5dcc-4da4-936d-abc462f3d6ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c65e017-bc05-484f-92c1-3ff723707b6f", "AQAAAAEAACcQAAAAEPGxEDKNL8k8FxPpNRMHRH+lhczYHpbNk2G0H8r1N/addU8VkUKrvr7bt62HnRINtw==", "b9c7c16d-dd77-43ea-8c41-f39116c0da52" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 24, 23, 35, 15, 889, DateTimeKind.Local).AddTicks(417));
        }
    }
}
