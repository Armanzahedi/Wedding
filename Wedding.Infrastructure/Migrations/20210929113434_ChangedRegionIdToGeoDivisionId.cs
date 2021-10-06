using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class ChangedRegionIdToGeoDivisionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_GeoDivisions_GeoDivisionId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Ads");

            migrationBuilder.AlterColumn<int>(
                name: "GeoDivisionId",
                table: "Ads",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "c378cd24-9cc0-43bd-8bb8-171cd93397e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "b007485a-2483-45eb-b58c-09dac249cdf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "f4fff515-9cc8-40a3-b04d-43da783d09e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ca298e5-6ba0-472a-8ddd-e88547d19d9b", "AQAAAAEAACcQAAAAEDJ3KfPNuOXKGiT9MRooraKwr5WuoNeIlFeQhSsia6sreMTmQ5nv2VrSjmCYSZH5pw==", "e941bccd-20c7-474e-b31e-9bc7faeb9ea4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ab39d37-17df-4cf3-b4e9-a6018eb084b2", "AQAAAAEAACcQAAAAEH9fteUOHGljEiUbCcLzBWQubakhlLeFpG5lPJs2Kvy5kHjMd8+3m3nvIDaEAoPCEQ==", "c1fc74f8-1f0c-47d0-9ac4-0101deb0d2fb" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 29, 15, 4, 33, 407, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_GeoDivisions_GeoDivisionId",
                table: "Ads",
                column: "GeoDivisionId",
                principalTable: "GeoDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_GeoDivisions_GeoDivisionId",
                table: "Ads");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GeoDivisionId",
                table: "Ads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "3fc2b97c-4875-4ea9-b7a2-cd6f8e72f0ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "01c6bf3f-79f1-4604-91cb-c5f487d73107");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "7817d9f7-e4a9-4009-b691-cd2ac16470b0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f115f6e6-438b-4528-9ce9-23500121dc59", "AQAAAAEAACcQAAAAEAr9Yr2u1Ep/s/152sWyYwyudMBqOBV00qDuu45jNn1Ifi2OxrniQt2JINVL/SdMKQ==", "55ac438d-63ce-4a16-b96f-d9eacfd33129" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2de9b973-b39e-4e90-809c-574235bec1f6", "AQAAAAEAACcQAAAAEK0YrqWq18lsM1Sble5QJi7qp2ZEX4naoEDbrqTs4LtULeUoT8TAZoY8URAHY+mhUw==", "ad1190ce-7a51-4ae8-b2a1-ecb8f8eff7f2" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 29, 11, 12, 31, 188, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_GeoDivisions_GeoDivisionId",
                table: "Ads",
                column: "GeoDivisionId",
                principalTable: "GeoDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
