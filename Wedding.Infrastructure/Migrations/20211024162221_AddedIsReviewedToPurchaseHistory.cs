using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedIsReviewedToPurchaseHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "AdPurchaseHistory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "51ba4afe-4337-471a-9c98-7fc4b218e53b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "479bdb4b-150c-433c-9842-f5fbc3102234");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "73114756-930c-4d40-a397-f5cf2063abfd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a3140f9-4951-41ab-a031-33423b7baf8c", "AQAAAAEAACcQAAAAEDTvPtGv84c8KlIbHfkjv4j9BlpzWSv+qlBx54mQ/9K/nMuZuEAitqzl4YCs4JwzTw==", "3fde8a15-29a1-4614-8686-618466607faa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d731124-7e3a-4b55-b6f4-fd56bd3eb43d", "AQAAAAEAACcQAAAAEPP9fDL9le3AKjiJDZAC8jvTgL4Ak4XFLnOdmYYqV2P2nahgXHJh0zCxMRoYPVGGCw==", "96c7b9af-311c-4551-b08b-e7edf1366854" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 24, 19, 52, 21, 421, DateTimeKind.Local).AddTicks(5671));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "AdPurchaseHistory");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "0db7bdef-2817-478d-a85c-90a784de13fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "560e0f81-f541-497c-b8e9-37d8793fc71c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "c460f4e3-3e33-423f-b171-2b5211ca6150");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "995a02b6-c03d-4418-8c42-7ceeafb6ee40", "AQAAAAEAACcQAAAAELH/ZxauNsuer2bwXAlWEhiNpOttA9j6g75l6J8OD/CYM7g+mBbpOKkkTHRvBq75KA==", "8793d295-cc02-49a4-bbc0-6db3b0538fb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c6cee9e-a1c3-480f-a550-59c0a1cc82c3", "AQAAAAEAACcQAAAAEK6pdO5TwG2ahxAwSUWHCxyBPe0/sk6Y9zBjvb+jVaXZ6OYChJ9eVs6uv4S2CaDzYA==", "b35d446a-2dbb-43bf-bad6-2c431c96fc93" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 24, 13, 51, 51, 950, DateTimeKind.Local).AddTicks(6488));
        }
    }
}
