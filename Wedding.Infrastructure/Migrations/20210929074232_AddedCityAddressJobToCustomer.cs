using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedCityAddressJobToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeoDivisionId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobTypeId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Customers",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GeoDivisionId",
                table: "Customers",
                column: "GeoDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_JobTypeId",
                table: "Customers",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_GeoDivisions_GeoDivisionId",
                table: "Customers",
                column: "GeoDivisionId",
                principalTable: "GeoDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_JobTypes_JobTypeId",
                table: "Customers",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_GeoDivisions_GeoDivisionId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_JobTypes_JobTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_GeoDivisionId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_JobTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GeoDivisionId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "29c4846c-f891-4cf5-afbc-7cd52d9827c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "8af0fd1a-400c-4402-b72d-2baa3ce478db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "59f54651-0103-4b12-aa99-8e8299aa22d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db260137-14a1-4e83-b13c-833c0c8d977f", "AQAAAAEAACcQAAAAEMplllnldOsX5SAYKX/RkYfqtsY2N3NiE9wBCIAFCEZMTkpEDdZIFygIhoaOtG/iEA==", "add63e67-cace-4125-92b1-5e685e1015b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1799792e-d18d-4c93-b6c2-e385bad4222d", "AQAAAAEAACcQAAAAEMdtDbEwcqxbn7rwhi5cCWbB7vukltx62EbAGQdWjYgyKVSOel7u1+0TTIt6twU9Wg==", "8cb5de20-be0e-4d8e-a694-196af15d4ddf" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 29, 10, 40, 1, 362, DateTimeKind.Local).AddTicks(3316));
        }
    }
}
