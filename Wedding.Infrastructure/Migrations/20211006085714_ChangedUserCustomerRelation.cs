using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class ChangedUserCustomerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "19ffb98b-fea6-487b-9ec2-ccc06b5389a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "e58f87f0-39d7-4402-9a15-c047fb570dae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "6743c3a9-4d9f-4d07-90d1-93c5823a127b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "783680e4-ba76-40aa-b406-75ee4fb94295", "AQAAAAEAACcQAAAAEFdH0buIHoN9mT+Fyshw5fKpU28N7ODkrbjF6o94axt8MUNOCn7tBjQsDm0TJVqeCw==", "dc855501-aba9-4a1d-af12-8172802a90cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be86795f-9db8-45ea-8f16-3fd1a6e0110a", "AQAAAAEAACcQAAAAEM1GDqUoR3DWy8uwP9yyukKr5OwC/j4MmQtnyKmvlJgkHDoLTnTZ4io9YPUkLgxWZg==", "5121f0dc-3139-4a3f-8d57-9e0e7423f522" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 12, 13, 12, 354, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
