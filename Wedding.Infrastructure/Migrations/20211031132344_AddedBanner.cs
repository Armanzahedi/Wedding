using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedBanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "cd0bde9c-23bc-430c-bb68-dcb3026d8208");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "a8eaacb5-211c-4147-b0b1-7229f7cea997");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "247b0985-50bb-4357-95b6-d448e3be591e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9879dd45-a4bd-46ea-9960-d0f79d5a9dcc", "AQAAAAEAACcQAAAAEHenYxg66fok1YclwhtiU5eQ/Lg7UzbxbOrh3wv7SYdd48Lz91cj1lYritNrDUTBpw==", "713c5800-9e69-4389-9112-931f798c0bba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52499e65-f44f-443b-a36d-c2f2a94a92ed", "AQAAAAEAACcQAAAAEEz7VyQJZOW/QWiNFlQ23/kdIOy+pY/gXeRut2I2eyWPrkEVUiaIEj0sNHciieZkMg==", "94ff19d5-0ae0-473b-ba80-519aa2737b49" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 31, 16, 53, 43, 942, DateTimeKind.Local).AddTicks(867));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
