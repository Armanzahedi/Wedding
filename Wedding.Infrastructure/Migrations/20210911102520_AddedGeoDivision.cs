using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedGeoDivision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoDivisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    LatinTitle = table.Column<string>(nullable: true),
                    GeoDivisionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoDivisions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenu",
                keyColumn: "Id",
                keyValue: 14,
                column: "ControllerName",
                value: "ArticleCategories");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenu",
                keyColumn: "Id",
                keyValue: 15,
                column: "ControllerName",
                value: "ArticleCategories");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenu",
                keyColumn: "Id",
                keyValue: 16,
                column: "ControllerName",
                value: "ArticleCategories");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenu",
                keyColumn: "Id",
                keyValue: 17,
                column: "ControllerName",
                value: "ArticleCategories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "76ec465b-6f77-4e9a-930a-7b1b9741c34d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "6a2a3c61-1700-4347-8405-3e51b4722c01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "6cc0671c-6eaf-4cfc-af98-76ae6a8e6765");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85868796-64ef-4548-ac7f-9817e2324adc", "AQAAAAEAACcQAAAAEL2qa2E7i6u6aASFYNOHFjvYdx+fOs5ZoNmE1y0DNHB64TugfVoVjFORdFV3H7e97Q==", "eef4a042-a83d-4d26-90d2-6b4d6fe95392" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "146930e6-f818-4b37-85c4-386e9a758e32", "AQAAAAEAACcQAAAAEGTrOT+pcD82WCNmzgkaxHRDVzGI+WestY7kO9+l9oGhyChtckD/23HUYWcpaS0pVQ==", "01978d44-0fd2-47da-954a-42c2ad6b0e67" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 14, 55, 19, 131, DateTimeKind.Local).AddTicks(4904));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeoDivisions");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenu",
                keyColumn: "Id",
                keyValue: 14,
                column: "ControllerName",
                value: "ArticleCategory");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenu",
                keyColumn: "Id",
                keyValue: 15,
                column: "ControllerName",
                value: "ArticleCategory");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenu",
                keyColumn: "Id",
                keyValue: 16,
                column: "ControllerName",
                value: "ArticleCategory");

            migrationBuilder.UpdateData(
                table: "AspNetNavigationMenu",
                keyColumn: "Id",
                keyValue: 17,
                column: "ControllerName",
                value: "ArticleCategory");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "32e4389f-6d57-4e66-8ef6-5814c968de5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "7af4d3a1-4801-4d7c-a199-7c1ae1c18b54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "c3c1e44c-3586-4808-bdf7-cf145f5aa58a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b74bf5f-e5f8-4052-9c86-cc4a5b8b6edf", "AQAAAAEAACcQAAAAEFbR2pF3O2qbAFMcbbpU0Ers6PL96u1JB/78wAivUznzrzwJ3iqj5XlodozFYlNU+A==", "a74f93c9-5fd8-4136-bdab-91e392a04764" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65fc53eb-11e9-4d46-ad57-700db31b52ff", "AQAAAAEAACcQAAAAEARAZkvwgXqNDgiUeVB3gfKMkAgzLBYWajyVRM4pW1pzw7PSxXZ1uZUvfS/g67Ox8w==", "4abfba11-11bb-4340-b79c-25f512eede68" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 7, 13, 23, 8, 726, DateTimeKind.Local).AddTicks(7898));
        }
    }
}
