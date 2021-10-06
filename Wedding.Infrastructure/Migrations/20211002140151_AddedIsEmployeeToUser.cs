using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedIsEmployeeToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmployee",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "057af061-b04c-4492-88a1-c1c3376386ff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "d5e1a5fa-14c0-4f6f-98af-b28a9a43f56d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "90364d58-f581-44b6-918f-95d64e89f9ef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67e1a20d-24e7-484d-9a93-e2d171d036a2", "AQAAAAEAACcQAAAAENaauaipr05YlDAZZA8C5cp77oGdxA5LdBD+3iNAciM1mB+KJnQHyD7NVwD0gU5AlA==", "fdb6ce96-1851-4cb5-907f-b15f1f3e8ac4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1502b3a-9359-47d7-98dd-f38993db88a3", "AQAAAAEAACcQAAAAENjm++K8FsnEL0IeJCRq54SZPHCzh0JKfXHqF4sLs121N/ak6Pv/zM/kIgxYAAyubA==", "d0952871-b3f8-492a-9c90-4d209061df19" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 2, 17, 31, 50, 940, DateTimeKind.Local).AddTicks(1795));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmployee",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Customer",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }
    }
}
