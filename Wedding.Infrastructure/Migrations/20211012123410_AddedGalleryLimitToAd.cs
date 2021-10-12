using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedGalleryLimitToAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GalleryLimit",
                table: "Ads",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GalleryLimit",
                table: "Ads");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "c328d7bf-c5f5-41a4-bb58-2c3af4547f7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "4ce948fb-2ae5-43fa-96b5-94ea393c01d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "0e2de98a-63d8-42a9-9164-1aa1b3f112ca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3329a5b9-5cd1-49a8-8adc-aaf098cde42b", "AQAAAAEAACcQAAAAEP04w19zjveW3loIRtiZ1m7DlDjiuq4gK+vuMd5hl2AJUk6FOTKJ1P4CMQC1t34+Cw==", "9028bf38-37f5-4fff-a40f-b2bdf99dabb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e2f25aa-1518-4458-a019-9610d027043d", "AQAAAAEAACcQAAAAEPz0HNBRjQtjKY1bdkogNkzDE8/6qfeYAIs5yJdMQKvfwcQ7EzWA4Ye6L1AX/8DtEA==", "a7d92bf9-cb3a-413d-a8cd-7117964855ef" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 12, 14, 31, 42, 844, DateTimeKind.Local).AddTicks(8909));
        }
    }
}
