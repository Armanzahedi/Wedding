using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class UpdatedJobTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "JobTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowInHomePage",
                table: "JobTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "879ec421-5efd-41f9-868e-8d04ae56af16");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "d1c0550c-e7fa-4a40-8a1a-308db1d2dbfb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "91321fce-5168-4f44-8a33-f95c133597a8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4047fdfb-e448-4e40-8c7d-1e09b630e84d", "AQAAAAEAACcQAAAAEBzzbAWLdemEJl7IMM3/Xymf2EN9/8ZExb1Im3QGYOW8GjDKV/6AILirOB1TV7+5GA==", "9a01a0fe-9e16-4bef-85dc-819145a7c593" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db17849b-ad1e-4868-a1ce-f8e1f2e97c25", "AQAAAAEAACcQAAAAEM7bwOKQoL9FU41pgU0jh1DXQt1jslyafV0GPRYLV0LVI3zcPrDN7KaWSuWwFOfexg==", "91249064-3bbd-4be3-bd47-25645c150f2a" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 26, 12, 56, 25, 170, DateTimeKind.Local).AddTicks(6138));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "JobTypes");

            migrationBuilder.DropColumn(
                name: "ShowInHomePage",
                table: "JobTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "55d6e58c-0069-491e-9281-846a19a75cac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "ad6beba8-2772-4620-99e6-14ae051ece42");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "9f1ff8e9-3854-450c-89e0-fb3763d75d20");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09bbbe57-8a91-40cf-9eed-92e20bf48dfe", "AQAAAAEAACcQAAAAEJYeTitrYagj2VJzENFuuFa6lJyDwT09aLeBcvxyqW4EFsbh0Fs/LEPVUr45ouRnPg==", "e9589aae-f784-4ba3-85ae-41841a791ddf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7e6d22f-61f5-45a6-934e-8efbac312c13", "AQAAAAEAACcQAAAAELysNFWMdeOw5R2k61Fdx2/qIwlx0lu5GEkKVXwR2S0UIyVp/PdR7NQ2lOa9KoDfKA==", "3cf0d9b3-5306-4eae-a077-73f349169189" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 17, 56, 12, 553, DateTimeKind.Local).AddTicks(7602));
        }
    }
}
