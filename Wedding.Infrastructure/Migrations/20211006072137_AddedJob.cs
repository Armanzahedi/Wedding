using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_GeoDivisions_GeoDivisionId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_JobTypes_JobTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_GeoDivisionId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_JobTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GeoDivisionId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    JobTypeId = table.Column<int>(nullable: true),
                    GeoDivisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_GeoDivisions_GeoDivisionId",
                        column: x => x.GeoDivisionId,
                        principalTable: "GeoDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CustomerId",
                table: "Jobs",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_GeoDivisionId",
                table: "Jobs",
                column: "GeoDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobTypeId",
                table: "Jobs",
                column: "JobTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeoDivisionId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobTypeId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "68fe9e05-9c76-410d-b753-722ce9096e92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "a3ba9fea-8d06-4daf-8714-ec1e94eb1c68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "a7195647-773f-427b-a09e-1ada0b8b2d17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b500da1a-4fa6-4ca1-86bb-8cf6c02bbe53", "AQAAAAEAACcQAAAAEGD+bmokllbai6KHIf7CjQBLUcTiwSKtkd5ehdZnVhzQVjfBMpWuSi04iT9N0zo5Bg==", "a0badb47-1917-4ad6-b4bf-3ab2dab81390" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f9bbc8d-9edc-4540-9e0b-ee912b8dd148", "AQAAAAEAACcQAAAAEC7oFPSKE4SVllXVvKJ6PGk2KNwKl/kV+shEi7z4qMx9uQ4FQHZNVZcs+tC0q4sfUA==", "4e51ff02-8722-4604-9e38-77d7723d7efe" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 2, 17, 51, 22, 808, DateTimeKind.Local).AddTicks(5487));

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GeoDivisionId",
                table: "Customers",
                column: "GeoDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_JobTypeId",
                table: "Customers",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_GeoDivisions_GeoDivisionId",
                table: "Customers",
                column: "GeoDivisionId",
                principalTable: "GeoDivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_JobTypes_JobTypeId",
                table: "Customers",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
