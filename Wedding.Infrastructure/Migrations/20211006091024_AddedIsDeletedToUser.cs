using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedIsDeletedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "fc1571de-ff4e-4c70-8fb3-f2b21db03a0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "1e1c7ffa-d972-48c6-a4fc-f7ffcef3c1e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "34a55110-2afd-4395-afab-ded67463dfda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4845667a-73b1-4910-aeea-497c608be98c", "AQAAAAEAACcQAAAAEGrROdBeYvEmaKkHL6PIN2A5ZVLeZk4DVW2ixgOTI9/V3fi44XIVJ86yv085C9cpXw==", "537d5a0e-a1cc-4f49-a823-11441ad8c880" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f51e835e-891f-46d4-8bef-361eba7fa57a", "AQAAAAEAACcQAAAAEK6GV79PHm+YE2FNh/3vCYzfK/BfVu7TbJVLJZKGH1CZqjXK4fQWuVaP6FJITvA2aw==", "b6e49aa0-9fb3-4bcc-ad17-1ae5e1f3b5a2" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 12, 40, 24, 14, DateTimeKind.Local).AddTicks(7799));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "8ca99926-0903-4f46-9745-7fd76a9fa971");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "103270a4-7431-4fc8-874a-150c269c3e77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "96513dfe-721e-40a9-be84-b72a51c1ae99");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a093c77-f014-457b-a9ef-97a9023fa6a4", "AQAAAAEAACcQAAAAECG/AJzJXWplzghuptTMEISKSKe1q2ZsMj1eC/aVkUhvjQMX3mQVrahZO37j8+8gxw==", "65651e65-df02-47ea-92da-92f5558d36ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0538148b-f49b-4c64-99c0-abeabff7911c", "AQAAAAEAACcQAAAAEHB1B11jrLokklAY+1hkBTE2y2pTuSDy2J3ZSpBxmM2LYzwIRAubdbVtwAT6kc8V4A==", "df8207a8-13de-4fd0-9377-a1a23e49f4d4" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 12, 27, 13, 733, DateTimeKind.Local).AddTicks(7401));
        }
    }
}
