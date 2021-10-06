using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class RemovedJobEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeoDivisionId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobTypeId",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "e17655fd-192e-4c1e-b208-db55979927e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "746ae42e-06bf-4ec8-b859-111846028183");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "b62fdf9f-364f-4590-80e8-251d946a17fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07abb425-28c2-4446-93b7-9ad43a1ba93c", "AQAAAAEAACcQAAAAEDS/8NIvOjEMUZa/URf+f0htcTih7o2jHZA7niG3qG/GggAGjaoniEQghwqlyFHzYg==", "2abb16e9-f1b3-4b4f-96b3-dbdc8cb4ed02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e2e87c7-2cb3-4920-9eef-03db221eaf34", "AQAAAAEAACcQAAAAECnNdMUR8b3h7mZnpawQA/NyrRoNL6LEyxfTnSl+cI4VmJRL3pSln+YjjeQ9Af6mqA==", "3d249e80-9de7-48a4-a696-4fe3687fa7b3" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 15, 13, 36, 803, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GeoDivisionId",
                table: "Customers",
                column: "GeoDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_JobTypeId",
                table: "Customers",
                column: "JobTypeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    GeoDivisionId = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTypeId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                value: "d84b49a3-5bed-4688-acce-0960012872f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "6ffa3ed5-7335-4d10-a578-0100f9f18785");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "e24eebbc-3fd5-4f81-8143-c8faa9338cf6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "708d4210-a5a1-4bc2-9544-453349465fcd", "AQAAAAEAACcQAAAAEEek1wrRoYfj1my3ZvG+FJpKXBT3ptFk+0Smj5sMt4vyxvMyGaJ8kDlYgVsb+q+VTA==", "8cdcb810-bb5c-42f1-a42c-fdc9531e2878" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c27723-245c-47b5-bcef-75c94e90ee78", "AQAAAAEAACcQAAAAEARJHUUB+5srAnEkcQ7gcZ18h6SC93JSZuVf5YVPo0DanbRs+NImZ9C2/ePXDIx74g==", "d5dfe8a9-45e6-45e1-85b7-c5d81fd1d864" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 6, 15, 6, 53, 959, DateTimeKind.Local).AddTicks(5928));

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
    }
}
