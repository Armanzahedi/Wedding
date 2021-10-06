using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Core.Models;
using Wedding.Core.Utility;

namespace Wedding.Infrastructure.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            #region Seed Users

            var admin = new User()
            {
                Id = DefaultValues.ADMIN_ID,
                Avatar = "user-avatar.png",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin",
                EmailConfirmed = true,
                NormalizedUserName = "Admin".ToUpper(),
                Email = "Admin@Admin.com",
                NormalizedEmail = "Admin@Admin.com".ToUpper()
            };
            admin.PasswordHash = GetHashedPassword(admin, "Admin");

            var superuser = new User()
            {
                Id = DefaultValues.SUPER_USER_ID,
                Avatar = "user-avatar.png",
                FirstName = "Superuser",
                LastName = "Superuser",
                UserName = "Superuser",
                EmailConfirmed = true,
                NormalizedUserName = "Superuser".ToUpper(),
                Email = "Superuser@Superuser.com",
                NormalizedEmail = "Superuser@Superuser.com".ToUpper()
            };
            superuser.PasswordHash = GetHashedPassword(superuser, "Superuser");

            modelBuilder.Entity<User>().HasData(
                admin,
                superuser
            );
            #endregion
            #region Seed Roles



            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = DefaultValues.ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Id = DefaultValues.USER_ROLE_ID, Name = "User", NormalizedName = "User".ToUpper() },
                new IdentityRole { Id = DefaultValues.SUPER_USER_ROLE_ID, Name = "Superuser", NormalizedName = "Superuser".ToUpper() }
            );
            #endregion

            #region Seed User Roles

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = DefaultValues.ADMIN_ID, RoleId = DefaultValues.ADMIN_ROLE_ID },
                new IdentityUserRole<string> { UserId = DefaultValues.SUPER_USER_ID, RoleId = DefaultValues.SUPER_USER_ROLE_ID }
            );

            #endregion

            #region Seed SystemParameter

            modelBuilder.Entity<SystemParameter>().HasData(
                new SystemParameter { Id = DefaultValues.UserDefaultPassword_sys_id, InsertUser = "SuperUser", InsertDate = DateTime.Now, Key = "DefaultPassword", Value = "User@123456" }
            );

            #endregion


            #region Seed Navigation menu
            modelBuilder.Entity<NavigationMenu>().HasData(

            #region Auth_Control

            new NavigationMenu()
            {
                Id = 1,
                Name = "مجوز دسترسی",
                ElementIdentifier = "auth_control",
                Icon = "Icon",
                DisplayOrder = 100,
                Visible = true,
            },

            #region Users

            new NavigationMenu()
            {
                Id = 2,
                ParentMenuId = 1,
                Name = "کاربران",
                ControllerName = "Users",
                ActionName = "Index",
                ElementIdentifier = "users",
                Visible = true,
            },
            new NavigationMenu()
            {
                Id = 3,
                ParentMenuId = 2,
                Name = "افزودن کابر",
                ControllerName = "Users",
                ActionName = "Create",
                ElementIdentifier = "users",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 4,
                ParentMenuId = 2,
                Name = "ویرایش کابر",
                ControllerName = "Users",
                ActionName = "Edit",
                ElementIdentifier = "users",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 5,
                ParentMenuId = 2,
                Name = "حذف کابر",
                ControllerName = "Users",
                ActionName = "Delete",
                ElementIdentifier = "users",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 6,
                ParentMenuId = 2,
                Name = "ویرایش نقش های کابر",
                ControllerName = "Users",
                ActionName = "EditRoles",
                ElementIdentifier = "users",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 7,
                ParentMenuId = 2,
                Name = "ویرایش پروفایل من",
                ControllerName = "Users",
                ActionName = "EditMyProfile",
                ElementIdentifier = "users",
                Visible = false,
            },
            #endregion
            #region Roles
            new NavigationMenu()
            {
                Id = 8,
                ParentMenuId = 1,
                Name = "نقش ها",
                ControllerName = "Roles",
                ActionName = "Index",
                ElementIdentifier = "roles",
                Visible = true,
            },
            new NavigationMenu()
            {
                Id = 9,
                ParentMenuId = 8,
                Name = "افزودن نقش",
                ControllerName = "Roles",
                ActionName = "Create",
                ElementIdentifier = "roles",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 10,
                ParentMenuId = 8,
                Name = "ویرایش نقش",
                ControllerName = "Roles",
                ActionName = "Edit",
                ElementIdentifier = "roles",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 11,
                ParentMenuId = 8,
                Name = "حذف نقش",
                ControllerName = "Roles",
                ActionName = "Delete",
                ElementIdentifier = "roles",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 12,
                ParentMenuId = 8,
                Name = "ویرایش دسترسی های نقش",
                ControllerName = "Roles",
                ActionName = "EditRolePermission",
                ElementIdentifier = "roles",
                Visible = false,
            },
            #endregion

            #endregion

            #region Article Control
            new NavigationMenu()
            {
                Id = 13,
                Name = "مدیریت مطالب",
                ElementIdentifier = "article_control",
                Icon = "Icon",
                DisplayOrder = 1,
                Visible = true,
            },
            #region Article Category
            new NavigationMenu()
            {
                Id = 14,
                ParentMenuId = 13,
                Name = "دسته بندی مطالب",
                ControllerName = "ArticleCategories",
                ActionName = "Index",
                ElementIdentifier = "article_categories",
                Visible = true,
            },
            new NavigationMenu()
            {
                Id = 15,
                ParentMenuId = 14,
                Name = "افزودن دسته بندی",
                ControllerName = "ArticleCategories",
                ActionName = "Create",
                ElementIdentifier = "article_categories",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 16,
                ParentMenuId = 14,
                Name = "ویرایش دسته بندی",
                ControllerName = "ArticleCategories",
                ActionName = "Edit",
                ElementIdentifier = "article_categories",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 17,
                ParentMenuId = 14,
                Name = "حذف دسته بندی",
                ControllerName = "ArticleCategories",
                ActionName = "Delete",
                ElementIdentifier = "article_categories",
                Visible = false,
            },
            #endregion
            #region Articles
            new NavigationMenu()
            {
                Id = 18,
                ParentMenuId = 13,
                Name = "مطالب",
                ControllerName = "Articles",
                ActionName = "Index",
                ElementIdentifier = "articles",
                Visible = true,
            },
            new NavigationMenu()
            {
                Id = 19,
                ParentMenuId = 18,
                Name = "افزودن مطلب",
                ControllerName = "Articles",
                ActionName = "Create",
                ElementIdentifier = "articles",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 20,
                ParentMenuId = 18,
                Name = "ویرایش مطلب",
                ControllerName = "Articles",
                ActionName = "Edit",
                ElementIdentifier = "articles",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 21,
                ParentMenuId = 18,
                Name = "حذف مطلب",
                ControllerName = "Articles",
                ActionName = "Delete",
                ElementIdentifier = "articles",
                Visible = false,
            },
            #endregion
            #region Article Comments
            new NavigationMenu()
            {
                Id = 22,
                ParentMenuId = 18,
                Name = "کامنت ها",
                ControllerName = "ArticleComments",
                ActionName = "Index",
                ElementIdentifier = "articles",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 23,
                ParentMenuId = 22,
                Name = "افزودن کامنت",
                ControllerName = "ArticleComments",
                ActionName = "Create",
                ElementIdentifier = "articles",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 24,
                ParentMenuId = 22,
                Name = "ویرایش کامنت",
                ControllerName = "ArticleComments",
                ActionName = "Edit",
                ElementIdentifier = "articles",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 25,
                ParentMenuId = 22,
                Name = "حذف کامنت",
                ControllerName = "ArticleComments",
                ActionName = "Delete",
                ElementIdentifier = "articles",
                Visible = false,
            },
            new NavigationMenu()
            {
                Id = 26,
                ParentMenuId = 22,
                Name = "پاسخ دادن به کامنت",
                ControllerName = "ArticleComments",
                ActionName = "AnswerComment",
                ElementIdentifier = "articles",
                Visible = false,
            },
            #endregion
            #endregion
            #region Contact Us Form
            new NavigationMenu()
            {
                Id = 27,
                Name = "فرم تماس با ما",
                ElementIdentifier = "contact_us_form",
                ControllerName = "ContactUsForm",
                ActionName = "Index",
                DisplayOrder = 6,
                Visible = true,
            },
            new NavigationMenu()
            {
                Id = 28,
                Name = "مشاهده فرم تماس با ما",
                ElementIdentifier = "contact_us_form",
                ControllerName = "ContactUsForm",
                ActionName = "Details",
                Visible = false,
            },
            #endregion
            #region Static Content
            new NavigationMenu()
            {
                Id = 29,
                ParentMenuId = 28,
                Name = "محتوا ثابت",
                ElementIdentifier = "static_content",
                ControllerName = "StaticContent",
                ActionName = "Index",
                Visible = true,
                DisplayOrder = 99
            }
            #endregion
            );

            #region Superuser Permissions
                modelBuilder.Entity<RoleMenuPermission>().HasData(
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 1
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 2
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 3
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 4
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 5
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 6
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 7
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 8
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 9
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 10
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 11
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 12
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 13
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 14
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 15
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 16
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 17
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 18
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 19
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 20
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 21
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 22
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 23
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 24
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 25
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 26
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 27
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 28
                },
                new RoleMenuPermission()
                {
                    RoleId = DefaultValues.SUPER_USER_ROLE_ID,
                    NavigationMenuId = 29
                }
                );
            #endregion

            #endregion
        }
        public static string GetHashedPassword(User user, string password)
        {
            var pass = new PasswordHasher<User>();
            var hashed = pass.HashPassword(user, password);
            return hashed;
        }
    }
}
