using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetNavigationMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ParentMenuId = table.Column<int>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    ElementIdentifier = table.Column<string>(nullable: true),
                    ControllerName = table.Column<string>(nullable: true),
                    ActionName = table.Column<string>(nullable: true),
                    Visible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetNavigationMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetNavigationMenu_AspNetNavigationMenu_ParentMenuId",
                        column: x => x.ParentMenuId,
                        principalTable: "AspNetNavigationMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 300, nullable: true),
                    LastName = table.Column<string>(maxLength: 300, nullable: true),
                    Information = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUsForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    IsSeen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 200, nullable: true),
                    TableName = table.Column<string>(maxLength: 100, nullable: true),
                    EntityId = table.Column<int>(nullable: false),
                    Action = table.Column<string>(maxLength: 100, nullable: true),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleMenuPermission",
                columns: table => new
                {
                    RoleId = table.Column<string>(nullable: false),
                    NavigationMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleMenuPermission", x => new { x.RoleId, x.NavigationMenuId });
                    table.ForeignKey(
                        name: "FK_AspNetRoleMenuPermission_AspNetNavigationMenu_NavigationMenuId",
                        column: x => x.NavigationMenuId,
                        principalTable: "AspNetNavigationMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 600, nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    AddedDate = table.Column<DateTime>(nullable: true),
                    ArticleCategoryId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: false),
                    Email = table.Column<string>(maxLength: 400, nullable: false),
                    Message = table.Column<string>(maxLength: 800, nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    ArticleId = table.Column<int>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleComments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleComments_ArticleComments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ArticleComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ArticleTags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetNavigationMenu",
                columns: new[] { "Id", "ActionName", "ControllerName", "DisplayOrder", "ElementIdentifier", "Icon", "Name", "ParentMenuId", "Visible" },
                values: new object[,]
                {
                    { 1, null, null, 100, "auth_control", "Icon", "مجوز دسترسی", null, true },
                    { 13, null, null, 1, "article_control", "Icon", "مدیریت مطالب", null, true },
                    { 27, "Index", "ContactUsForm", 6, "contact_us_form", null, "فرم تماس با ما", null, true },
                    { 28, "Details", "ContactUsForm", null, "contact_us_form", null, "مشاهده فرم تماس با ما", null, false }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29bd76db-5835-406d-ad1d-7a0901447c18", "32e4389f-6d57-4e66-8ef6-5814c968de5c", "Admin", "ADMIN" },
                    { "d7be43da-622c-4cfe-98a9-5a5161120d24", "c3c1e44c-3586-4808-bdf7-cf145f5aa58a", "User", "USER" },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", "7af4d3a1-4801-4d7c-a199-7c1ae1c18b54", "Superuser", "SUPERUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Information", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "75625814-138e-4831-a1ea-bf58e211adff", 0, "user-avatar.png", "65fc53eb-11e9-4d46-ad57-700db31b52ff", "Admin@Admin.com", true, "Admin", null, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEARAZkvwgXqNDgiUeVB3gfKMkAgzLBYWajyVRM4pW1pzw7PSxXZ1uZUvfS/g67Ox8w==", null, false, "4abfba11-11bb-4340-b79c-25f512eede68", false, "Admin" },
                    { "75625814-138e-4831-a1ea-bf58e211acmf", 0, "user-avatar.png", "3b74bf5f-e5f8-4052-9c86-cc4a5b8b6edf", "Superuser@Superuser.com", true, "Superuser", null, "Superuser", false, null, "SUPERUSER@SUPERUSER.COM", "SUPERUSER", "AQAAAAEAACcQAAAAEFbR2pF3O2qbAFMcbbpU0Ers6PL96u1JB/78wAivUznzrzwJ3iqj5XlodozFYlNU+A==", null, false, "a74f93c9-5fd8-4136-bdab-91e392a04764", false, "Superuser" }
                });

            migrationBuilder.InsertData(
                table: "SystemParameters",
                columns: new[] { "Id", "Description", "InsertDate", "InsertUser", "IsDeleted", "Key", "UpdateDate", "UpdateUser", "Value" },
                values: new object[] { 1, null, new DateTime(2021, 9, 7, 13, 23, 8, 726, DateTimeKind.Local).AddTicks(7898), "SuperUser", false, "DefaultPassword", null, null, "User@123456" });

            migrationBuilder.InsertData(
                table: "AspNetNavigationMenu",
                columns: new[] { "Id", "ActionName", "ControllerName", "DisplayOrder", "ElementIdentifier", "Icon", "Name", "ParentMenuId", "Visible" },
                values: new object[,]
                {
                    { 2, "Index", "Users", null, "users", null, "کاربران", 1, true },
                    { 8, "Index", "Roles", null, "roles", null, "نقش ها", 1, true },
                    { 14, "Index", "ArticleCategory", null, "article_categories", null, "دسته بندی مطالب", 13, true },
                    { 18, "Index", "Articles", null, "articles", null, "مطالب", 13, true },
                    { 29, "Index", "StaticContent", 99, "static_content", null, "محتوا ثابت", 28, true }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleMenuPermission",
                columns: new[] { "RoleId", "NavigationMenuId" },
                values: new object[,]
                {
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 1 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 13 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 27 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 28 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "75625814-138e-4831-a1ea-bf58e211adff", "29bd76db-5835-406d-ad1d-7a0901447c18" },
                    { "75625814-138e-4831-a1ea-bf58e211acmf", "29bd76db-5835-406d-ad1d-7a0901448abd" }
                });

            migrationBuilder.InsertData(
                table: "AspNetNavigationMenu",
                columns: new[] { "Id", "ActionName", "ControllerName", "DisplayOrder", "ElementIdentifier", "Icon", "Name", "ParentMenuId", "Visible" },
                values: new object[,]
                {
                    { 3, "Create", "Users", null, "users", null, "افزودن کابر", 2, false },
                    { 4, "Edit", "Users", null, "users", null, "ویرایش کابر", 2, false },
                    { 5, "Delete", "Users", null, "users", null, "حذف کابر", 2, false },
                    { 6, "EditRoles", "Users", null, "users", null, "ویرایش نقش های کابر", 2, false },
                    { 7, "EditMyProfile", "Users", null, "users", null, "ویرایش پروفایل من", 2, false },
                    { 22, "Index", "ArticleComments", null, "articles", null, "کامنت ها", 18, false },
                    { 9, "Create", "Roles", null, "roles", null, "افزودن نقش", 8, false },
                    { 10, "Edit", "Roles", null, "roles", null, "ویرایش نقش", 8, false },
                    { 11, "Delete", "Roles", null, "roles", null, "حذف نقش", 8, false },
                    { 12, "EditRolePermission", "Roles", null, "roles", null, "ویرایش دسترسی های نقش", 8, false },
                    { 21, "Delete", "Articles", null, "articles", null, "حذف مطلب", 18, false },
                    { 15, "Create", "ArticleCategory", null, "article_categories", null, "افزودن دسته بندی", 14, false },
                    { 16, "Edit", "ArticleCategory", null, "article_categories", null, "ویرایش دسته بندی", 14, false },
                    { 17, "Delete", "ArticleCategory", null, "article_categories", null, "حذف دسته بندی", 14, false },
                    { 20, "Edit", "Articles", null, "articles", null, "ویرایش مطلب", 18, false },
                    { 19, "Create", "Articles", null, "articles", null, "افزودن مطلب", 18, false }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleMenuPermission",
                columns: new[] { "RoleId", "NavigationMenuId" },
                values: new object[,]
                {
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 8 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 18 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 2 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 14 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 29 }
                });

            migrationBuilder.InsertData(
                table: "AspNetNavigationMenu",
                columns: new[] { "Id", "ActionName", "ControllerName", "DisplayOrder", "ElementIdentifier", "Icon", "Name", "ParentMenuId", "Visible" },
                values: new object[,]
                {
                    { 25, "Delete", "ArticleComments", null, "articles", null, "حذف کامنت", 22, false },
                    { 24, "Edit", "ArticleComments", null, "articles", null, "ویرایش کامنت", 22, false },
                    { 23, "Create", "ArticleComments", null, "articles", null, "افزودن کامنت", 22, false },
                    { 26, "AnswerComment", "ArticleComments", null, "articles", null, "پاسخ دادن به کامنت", 22, false }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleMenuPermission",
                columns: new[] { "RoleId", "NavigationMenuId" },
                values: new object[,]
                {
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 3 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 21 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 20 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 19 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 17 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 16 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 15 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 11 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 10 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 9 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 7 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 6 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 5 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 4 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 12 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 22 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleMenuPermission",
                columns: new[] { "RoleId", "NavigationMenuId" },
                values: new object[,]
                {
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 23 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 24 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 25 },
                    { "29bd76db-5835-406d-ad1d-7a0901448abd", 26 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ParentId",
                table: "ArticleComments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetNavigationMenu_ParentMenuId",
                table: "AspNetNavigationMenu",
                column: "ParentMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleMenuPermission_NavigationMenuId",
                table: "AspNetRoleMenuPermission",
                column: "NavigationMenuId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleComments");

            migrationBuilder.DropTable(
                name: "ArticleTags");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetRoleMenuPermission");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContactUsForms");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "SystemParameters");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "AspNetNavigationMenu");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
