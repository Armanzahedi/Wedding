using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedTransactionCreateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "WalletTransactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "4ac627e9-6099-401a-932b-36f8f760d981");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "4f4e8633-87f3-4c2a-a8e0-6539bc33a485");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "9d0de202-077a-41a2-a03f-c82c3ab3c613");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66caaf61-55cb-44ed-8662-e716407a6aba", "AQAAAAEAACcQAAAAECHzY7MrmvRMIXZ4D8GtmE/KCRx7JwjNxMprlvk3+YWNn8nMQaCIkaUELoxruBIH8w==", "d5255081-6806-4bb1-857d-c60b77873ee9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f686593-1b70-4071-8a0a-62456a271779", "AQAAAAEAACcQAAAAEAQNFiEHgRyeSfJe8Gt/ztSkGfOEFbfVx6Qo6Owye9HWZRoMAWB7ALfQyMXPZ50XkA==", "8946ee28-5d48-4cae-847c-1105ee5f0b39" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 16, 15, 15, 3, 404, DateTimeKind.Local).AddTicks(2050));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "WalletTransactions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "3da52a30-a7b5-402d-bb93-22c291fed912");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "2df8025e-d1ff-48be-8ecc-34d701818f50");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "95ffc365-625d-4a2f-87f9-da290ec0531b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "213deb7d-20fa-4e84-b0ee-186e243b5c0e", "AQAAAAEAACcQAAAAECrWM9w3Cx5x5n75A0DO91Zbtilc3Z78P+Rbxy/KlzWY5UGAJqzJJp+Z+nw+AwmV0g==", "0dc067cd-abd9-4a6c-b941-42ebc9f1bf7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4472b41c-6c3e-4561-a9e0-a148f07ce078", "AQAAAAEAACcQAAAAEJMHiLVgpKhvimmV2wK0z86fmSStV0pVd4KXTZK7kQs41yUFNb+8bjjYLlkFZops6Q==", "d118f28b-2244-46c3-af98-0e79798f5764" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 16, 11, 59, 26, 490, DateTimeKind.Local).AddTicks(7240));
        }
    }
}
