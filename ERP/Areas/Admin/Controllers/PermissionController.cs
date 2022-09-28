using ERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ERP.Enums;
using ERP.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;
using Business.Interface;
using System;
using ERP.Controllers;
using System.ComponentModel;
using Kinfo.JsonStore;

namespace ERP.Areas.Admin.Controllers
{

    //[Authorize(Roles = "SuperAdmin")]

    [Area("Admin"), Authorize]
    [DisplayName("Permisison")]
    public class PermissionController : SettingsController
    {
        private readonly RoleManager<RoleMasterMetadata> _roleManager;
        private readonly ISiteUserService _userManager;
        private ISiteRoleRepository _roles;
        private readonly IMvcControllerDiscovery _mvcControllerDiscovery;
        private readonly IRoleAccessStore _roleAccessStore;
        public PermissionController(IRoleAccessStore roleAccessStore, ISiteUserService usermanager, RoleManager<RoleMasterMetadata> roleManager, ISiteRoleRepository roles, IMvcControllerDiscovery mvcControllerDiscovery)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _roles = roles;
            _mvcControllerDiscovery = mvcControllerDiscovery;
            _roleAccessStore = roleAccessStore;
        }
        [DisplayName("Manage Role Permission")]
        public async Task<ActionResult> Index(string id)
        {
            try
            {
                IList<MvcControllerInfo> actionsList = _mvcControllerDiscovery.GetControllers()
                    .Where(s => !s.Name.Contains("Account"))
                   .ToList()
                       .OrderBy(s => s.AreaName).ThenBy(s => s.Name).ToList();
                RoleMasterMetadata model = new RoleMasterMetadata();
                if (!_userManager.IsUserInRoleAsync(USERID, 1).Result)
                {
                    actionsList = actionsList.Where(s => !s.AreaName.toStringWithDash().Contains("SuperAdmin") && !s.Name.Contains("Account"))
                   .ToList()
                       .OrderBy(s => s.AreaName).ThenBy(s => s.Name).ToList();
                }
                model = await _roleManager.FindByIdAsync(id);
                if (model != null)
                {
                    model.SelectedControllers = actionsList;
                    var claims = await _roles.GetAllClaims(id.ToInt(), COMPANYID);
                    if (claims != null)
                    {
                        foreach (var controllers in model.SelectedControllers)
                        {
                            foreach (var actions in controllers.Actions)
                            {
                                if (claims.Any(a => a.ClaimValue.Contains(actions.Id.toStringWithEmpty())))
                                {
                                    actions.Selected = true;
                                }
                                else
                                {
                                    actions.Selected = false;
                                }
                            }
                        }
                    }

                }
                return View(model);
            }
            catch
            {
                throw;
            }
        }
        [DisplayName("Update Permisison")]
        public async Task<IActionResult> Update(RoleMasterMetadata model)
        {
            try
            {
                var selectedClaims = model.SelectedControllers.SelectMany(s => s.Actions).ToList();
                foreach (var claim in selectedClaims)
                {
                    RoleClaimsMetadata claims = new RoleClaimsMetadata();
                    claims.RoleID = model.RoleID.ToInt();
                    claims.CompanyID = COMPANYID;
                    claims.ClaimValue = string.Format("{0}-{1}", claim.ControllerId, claim.Name);
                    claims.ClaimType = "Permission";
                    claims.Selected = claim.Selected;
                    await _roles.AddPermissionClaim(claims);
                }

                return RedirectToAction("Index", new { id = model.RoleID });
            }
            catch
            {
                throw;
            }
        }
    }
}


