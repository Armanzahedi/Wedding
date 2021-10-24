using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class MadeInvoiceProcessDateNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessedDate",
                table: "Invoices",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "912642fd-3621-4836-a5d3-e34a2dcb5dff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "37cfc697-f576-4b01-a81f-5f68e5c6df8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "c73ba76f-00e6-4c8b-a5ac-2847a50426c0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10f9f180-f793-4ee7-b6f7-139a7b379ea9", "AQAAAAEAACcQAAAAEFinn0sW+I8Z+vedQmFlX7fi3EcHQzF2T4Hvjma+ACB/G9d4mkySCmj96b04CfjrYg==", "fb275892-5dcc-4da4-936d-abc462f3d6ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c65e017-bc05-484f-92c1-3ff723707b6f", "AQAAAAEAACcQAAAAEPGxEDKNL8k8FxPpNRMHRH+lhczYHpbNk2G0H8r1N/addU8VkUKrvr7bt62HnRINtw==", "b9c7c16d-dd77-43ea-8c41-f39116c0da52" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 24, 23, 35, 15, 889, DateTimeKind.Local).AddTicks(417));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessedDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

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
    }
}
