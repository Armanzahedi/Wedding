using Wedding.Core.Models;
using Wedding.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wedding.Web.TagHelpers
{
    [HtmlTargetElement("validate-permission")]
    public class ValidatePermissionTagHelper : TagHelper
    {
        private readonly MyDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public ValidatePermissionTagHelper(MyDbContext dbContext, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        [HtmlAttributeName("asp-area")]
        public string Area { get; set; } = "apanel";

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var user = _httpContextAccessor.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                output.SuppressOutput();
                return;
            }
            var usr = await _userManager.GetUserAsync(user);
            var userRoles = _dbContext.UserRoles.Where(ur=>ur.UserId == usr.Id).Select(ur=>ur.RoleId).ToList();
            var userHasPermission = _dbContext.RoleMenuPermission
                .Any(rp => userRoles.Any(ur => ur == rp.RoleId)
                && rp.NavigationMenu.ControllerName.Trim().ToLower().Equals(Controller)
                && rp.NavigationMenu.ActionName.Trim().ToLower().Equals(Action));


            if (userHasPermission == true)
                return;

            output.SuppressOutput();
        }
    }
}
