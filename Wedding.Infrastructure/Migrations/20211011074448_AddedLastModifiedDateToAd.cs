using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedLastModifiedDateToAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Ads",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Ads");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "e17655fd-192e-4c1e-b208-db55979927e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "746ae42e-06bf-4ec8-b859-111846028183");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "b62fdf9f-364f-4590-80e8-251d946a17fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07abb425-28c2-4446-93b7-9ad43a1ba93c", "AQAAAAEAACcQAAAAEDS/8NIvOjEMUZa/URf+f0htcTih7o2jHZA7niG3qG/GggAGjaoniEQghwqlyFHzYg==", "2abb16e9-f1b3-4b4f-96b3-dbdc8cb4ed02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e2e87c7-2cb3-4920-9eef-03db221eaf34", "AQAAAAEAACcQAAAAECnNdMUR8b3h7mZnpawQA/NyrRoNL6LEyxfTnSl+cI4VmJRL3pSln+YjjeQ9Af6mqA==", "3d249e80-9de7-48a4-a696-4fe3687fa7b3" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 15, 13, 36, 803, DateTimeKind.Local).AddTicks(7826));
        }
    }
}
