using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class ChangedAdLngLat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Ads",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Ads",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Ads",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Ads",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "edb905b1-ec96-4e74-984d-15f6780c271a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "3ff63ccf-22ca-44e5-aa98-8f4e31086540");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "086f718e-8ec5-4edb-8d34-9c78cfed469e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bec3979-c99c-4b7d-9581-e7d1092e706b", "AQAAAAEAACcQAAAAEMku24MmS0P/DaJIZSc6YfSAFKLLYzs0hfkPQmBenMjaih3bJ79ftDXuZ1v08gQeyA==", "8888cbbf-6b05-475a-b57f-654915997186" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77c87f2c-b393-4042-a398-65667994144a", "AQAAAAEAACcQAAAAEMsPN2lNv+NEWJHvIQRqnLHuhkXcnOkWT+eimBVzy37g56nd+Kl5Z1Y/yPXSrmd7bg==", "e96f6d7c-ea76-428f-85ce-c507259cfe7f" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 11, 11, 14, 48, 545, DateTimeKind.Local).AddTicks(91));
        }
    }
}
