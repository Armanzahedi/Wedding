using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedAdRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
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
                    JobTypeId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    GeoDivisionId = table.Column<int>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WhatsApp = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Telegram = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Discount = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsPermenantPremium = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ads_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ads_GeoDivisions_GeoDivisionId",
                        column: x => x.GeoDivisionId,
                        principalTable: "GeoDivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ads_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AdId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdContacts_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdFaqs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AdId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdFaqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdFaqs_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AdId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdGalleries_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdPurchaseHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AdId = table.Column<int>(nullable: false),
                    PurchaseType = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    PurchasedFrom = table.Column<DateTime>(nullable: false),
                    PurchasedTo = table.Column<DateTime>(nullable: false),
                    Price = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdPurchaseHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdPurchaseHistory_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AdId = table.Column<int>(nullable: false),
                    Score = table.Column<decimal>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    ActionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdRatings_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AdId = table.Column<int>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    Reviewer = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdReviews_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdTags",
                columns: table => new
                {
                    AdId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdTags", x => new { x.AdId, x.TagId });
                    table.ForeignKey(
                        name: "FK_AdTags_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "81d980dd-c149-44dc-9f9e-5d14a87d30eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "847d5bec-f207-4d8e-8987-e2944020d7bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "e5caf3b0-c729-4fce-9b51-874ef321fc45");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e798986-240d-4328-ae93-faa74ba44798", "AQAAAAEAACcQAAAAEAa5Kr7nYVul1X/z1QF/3HChFiEyFOIas2EaEgA+eZ+z54C9z4xXIjXWVL3bumXgfw==", "e6ca0ec4-375e-4417-b9ca-786876dab682" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f22b83b-eee9-486e-858a-2d2987cf624c", "AQAAAAEAACcQAAAAEPXOztv9L0Ot3CJLCS1RCle2bv+bvQJRxyBHsquKabJ7+tft0Mbw9Dygtxj8Y2CoXg==", "44f8ec4f-d305-4442-8d7a-cb2e25d671e6" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 28, 15, 17, 46, 266, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.CreateIndex(
                name: "IX_AdContacts_AdId",
                table: "AdContacts",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdFaqs_AdId",
                table: "AdFaqs",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdGalleries_AdId",
                table: "AdGalleries",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdPurchaseHistory_AdId",
                table: "AdPurchaseHistory",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdRatings_AdId",
                table: "AdRatings",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdReviews_AdId",
                table: "AdReviews",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CustomerId",
                table: "Ads",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_GeoDivisionId",
                table: "Ads",
                column: "GeoDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_JobTypeId",
                table: "Ads",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdTags_TagId",
                table: "AdTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdContacts");

            migrationBuilder.DropTable(
                name: "AdFaqs");

            migrationBuilder.DropTable(
                name: "AdGalleries");

            migrationBuilder.DropTable(
                name: "AdPurchaseHistory");

            migrationBuilder.DropTable(
                name: "AdRatings");

            migrationBuilder.DropTable(
                name: "AdReviews");

            migrationBuilder.DropTable(
                name: "AdTags");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "b12cde98-1935-4526-806f-d404886f60da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "e5521dfb-eef5-4670-80ff-3e447374dca2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "d42a0e98-77e5-4cae-81e5-9bad90db8c6f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e568bb9b-2e9c-45d3-a754-4f7989eea94b", "AQAAAAEAACcQAAAAELl1gn+ACbvWScQJ/07fe+gSNIPGL7EuivTr0ttD7T4BwnXkUO7PcbibagQMB50udg==", "3b944fec-4517-43b9-9d44-b107bb910fc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d8d4508-f5d7-4db3-b124-05e0c735cfb4", "AQAAAAEAACcQAAAAEKYRONQYMTwlvkbLvFKJtsKA3WR5KKuxn37t2o+nFLUUS1v9j52Jv7A3aDbTvxvE9Q==", "412b2681-50ce-4636-866e-8875bc457828" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 28, 15, 1, 39, 731, DateTimeKind.Local).AddTicks(863));
        }
    }
}
