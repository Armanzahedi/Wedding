using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class FixedGeoDivision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GeoDivisions",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LatinTitle",
                table: "GeoDivisions",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "GeoDivisions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "a0b95bce-5339-4f3d-8fb3-f102166b05a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "3e6ce7e9-e045-4b80-b4d8-eddb6b64386a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "3d1e90ac-eb35-4fd4-b398-4413e18d16b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6acfdf7-6ae9-4693-9153-a42b555d1add", "AQAAAAEAACcQAAAAEDSMTEMkWycDiwz/B576/cKG6VK9sl0g1tsjBrLKu4PtuRxiRpwvammJyVOxdLH0bg==", "3ee107bc-3170-4946-bf75-e5e244c36be8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0999369f-cce6-4c74-a264-43963c005e10", "AQAAAAEAACcQAAAAEBnq53N3BOmD07izgQ/5/ZGWu/TPSfaaMJd88cjLMrwaoKybksNIaShS224GYHXqEg==", "c74f77fa-a597-4aec-8b4c-8ac7975426f5" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 15, 10, 59, 831, DateTimeKind.Local).AddTicks(4764));

            migrationBuilder.CreateIndex(
                name: "IX_GeoDivisions_ParentId",
                table: "GeoDivisions",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeoDivisions_GeoDivisions_ParentId",
                table: "GeoDivisions",
                column: "ParentId",
                principalTable: "GeoDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeoDivisions_GeoDivisions_ParentId",
                table: "GeoDivisions");

            migrationBuilder.DropIndex(
                name: "IX_GeoDivisions_ParentId",
                table: "GeoDivisions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "GeoDivisions");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GeoDivisions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LatinTitle",
                table: "GeoDivisions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "76ec465b-6f77-4e9a-930a-7b1b9741c34d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "6a2a3c61-1700-4347-8405-3e51b4722c01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "6cc0671c-6eaf-4cfc-af98-76ae6a8e6765");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85868796-64ef-4548-ac7f-9817e2324adc", "AQAAAAEAACcQAAAAEL2qa2E7i6u6aASFYNOHFjvYdx+fOs5ZoNmE1y0DNHB64TugfVoVjFORdFV3H7e97Q==", "eef4a042-a83d-4d26-90d2-6b4d6fe95392" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "146930e6-f818-4b37-85c4-386e9a758e32", "AQAAAAEAACcQAAAAEGTrOT+pcD82WCNmzgkaxHRDVzGI+WestY7kO9+l9oGhyChtckD/23HUYWcpaS0pVQ==", "01978d44-0fd2-47da-954a-42c2ad6b0e67" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 14, 55, 19, 131, DateTimeKind.Local).AddTicks(4904));
        }
    }
}
