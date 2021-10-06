using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedJobTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    PluralTitle = table.Column<string>(nullable: false),
                    LatinTitle = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "432716ac-f544-4672-bf34-b75f51d60efc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "7c6ae907-f9d0-4b8f-b878-a32834b26d11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "08d8d308-e0b5-45d7-8de5-bb31ff3a832a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b268dee-35a7-4b11-9b22-0abf021fff88", "AQAAAAEAACcQAAAAEEdWivyP0BR8EO27jG5r6u7x6CdLbF9xCzUN469KMhIZuLaVZ8R+K1Pfpd04sVxD7A==", "3f48a765-16e3-45ea-bc04-2f1d0aec348e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f29904e-a20e-483a-9a17-fa13f5513455", "AQAAAAEAACcQAAAAEDIv2RnIpLSGZjcUjHEwGHT44fQbz9FKQO08FfbdB0577LELfc6+t5td3Pbreqj4MA==", "df021d98-f2d3-4c74-9505-91a97a8a8a2a" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 17, 53, 49, 27, DateTimeKind.Local).AddTicks(378));
        }
    }
}
