using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedPhoneToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "ad75e14e-b962-43a3-a8ad-4d9916dd5148");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "0f95c9cb-d7a7-443f-a5ab-a76dcf46776b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "539c4e25-7a9c-461d-a8da-fd5f4a00aace");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dde86a30-dac4-492f-8db6-ecc8e99e800f", "AQAAAAEAACcQAAAAEICRmpw0EqilNdHhkMczGczxRh5EACp69Qp6c7kqsy2S6/zdyNKjkmmeGQAWthqItw==", "e1f3be97-9f67-4f5c-971d-ac62192255c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0f020bc-3ec2-4c92-bb83-db965b3031d9", "AQAAAAEAACcQAAAAEDAT+749bBnyGVO9+ZetGyRcv1wxm9hAYZTjJ1lbg2uZLc2jPVMEtGjHADnlbiyGWA==", "a32db3c7-5e8b-480b-b94c-e4e420e65b4d" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 10, 51, 36, 742, DateTimeKind.Local).AddTicks(5605));
        }
    }
}
