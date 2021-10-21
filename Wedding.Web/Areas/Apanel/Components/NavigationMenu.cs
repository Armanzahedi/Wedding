using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wedding.Infrastructure.Repositories;
using Wedding.Web.Helpers;

namespace Wedding.Web.Areas.Apanel.Components
{
	public class NavigationMenuViewComponent : ViewComponent
	{
		private readonly IRolePermissionService _rolePermissionService;
        private readonly IWithdrawalRequestRepository _withdrawalRequestRepo;

		public NavigationMenuViewComponent(IRolePermissionService rolePermissionService, IWithdrawalRequestRepository withdrawalRequestRepo)
        {
            _rolePermissionService = rolePermissionService;
            _withdrawalRequestRepo = withdrawalRequestRepo;
        }

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await _rolePermissionService.GetMenuItemsAsync(HttpContext.User);
            var requestItem = items.FirstOrDefault(i => i.ElementIdentifier == "requests");
            var withdrawalRequestItem = items.FirstOrDefault(i => i.ElementIdentifier == "withdrawal_requests");
            if (requestItem != null)
            {
                if (withdrawalRequestItem != null)
                {
                    var withdrawalRequestCount = await _withdrawalRequestRepo.GetRequestCount();
                    if (withdrawalRequestCount > 0)
                    {
                        requestItem.HasBadge = true;
                        withdrawalRequestItem.HasBadge = true;
                        withdrawalRequestItem.BadgeNumber = withdrawalRequestCount;
                    }
                }
            }


			return View(items);
		}
	}
}
