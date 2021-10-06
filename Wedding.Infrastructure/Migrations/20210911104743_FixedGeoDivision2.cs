using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class FixedGeoDivision2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsArchived",
                table: "GeoDivisions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsLeaf",
                table: "GeoDivisions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "4cde706f-5fc4-415d-acff-ea62a1f21dac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "488a46ba-210c-4563-81d5-3f1ac8011672");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "7d8eee0c-3af9-429e-b6c4-0e41b71dd60e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3507959-fe86-4f23-bd79-c5ddecf8e1dd", "AQAAAAEAACcQAAAAENsI5jzgLzwmOGrHTZbnKItcU+006eqQk4gVLowm+zl7BwJCmXIPKPHCbVE90hcKbQ==", "15947b1d-3e9b-4d65-8ca9-d0329f6ece84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c6c4c75-9f93-46aa-bf27-e959f4a33881", "AQAAAAEAACcQAAAAELgs7+7KduV0DYkTjuKlOwbLe/oXPq4S7vu8SP8S+4Wkm3V+PQ4jPIGQEg5xrMP14g==", "e61d74d5-69aa-44c1-bce3-33f8fd3305be" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 15, 17, 42, 357, DateTimeKind.Local).AddTicks(6156));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeoDivisions");

            migrationBuilder.DropColumn(
                name: "IsLeaf",
                table: "GeoDivisions");

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
        }
    }
}
