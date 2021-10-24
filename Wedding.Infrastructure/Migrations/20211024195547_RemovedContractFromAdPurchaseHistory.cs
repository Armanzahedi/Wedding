using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class RemovedContractFromAdPurchaseHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contract",
                table: "AdPurchaseHistory");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "59a4b92e-7b5f-429d-8714-908758e06966");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "48b51e16-19c4-496a-ad96-dd458ddb589a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "96ec1e2b-a8c0-4e42-9428-683f3915db76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b77d06d2-2348-4ee3-9b17-e26ffa057a63", "AQAAAAEAACcQAAAAELdnnv1oq5HHqHusb1eAIqRHRt6MiN08M68synyn0YM3p9TMyFSLHgeLBW6/tZYjWw==", "19de482b-ac8c-4852-96b6-dc6416a12134" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b814f98-67a6-41a1-8601-8b844b862d2e", "AQAAAAEAACcQAAAAELP2v29rP5+5Cn7Z3/0qwwuuvAPEYL2eOlX44zHWNatc/f0PzuUAiorS46RPnMndHg==", "bee91c58-be21-4424-875a-c7ce635128b9" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 24, 23, 25, 46, 832, DateTimeKind.Local).AddTicks(8896));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contract",
                table: "AdPurchaseHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "c8aae8a6-fb10-4a27-b0b2-255d34991089");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "da2a7a64-bcf7-40a1-b295-2c54a022203b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "8825d4e8-6fd1-427e-8309-93d9721ab225");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a371fabb-269c-4d51-816f-06b1be99d4db", "AQAAAAEAACcQAAAAEDKvEIANFZRhY8giLRWbbH6HroNSQDkGgrjE7XMDoMazYS5im5H5XFGPQ46IrCVlnA==", "e9bc0926-5997-436f-8700-0e58076e5202" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b62c4c59-58ba-4c85-a86a-beb8d5733db7", "AQAAAAEAACcQAAAAEKMZxegUcQAMtu0kCdEVVBmdqzILMq7QTpl7sppl2kB5w+6tSrzAndnB55Ds+Wz0gA==", "1a61721d-8fcf-440f-b9d2-d5dcc52af70d" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 24, 23, 4, 44, 552, DateTimeKind.Local).AddTicks(3789));
        }
    }
}
