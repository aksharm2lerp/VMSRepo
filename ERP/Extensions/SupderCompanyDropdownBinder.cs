using Business.Interface;
using ERP.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Extensions
{
    public static class SupderCompanyDropdownBinder
    {
        private  static HttpContext Current =>new HttpContextAccessor().HttpContext;
       private static ISiteRoleRepository roleService => (ISiteRoleRepository)Current.RequestServices.GetService(typeof(ISiteRoleRepository));
                
        public static SelectList Roles()
        {
            var role = roleService.GetAllRolesAsync(SettingsController.COMPANYID).Result;
            return new SelectList(role, "RoleID", "RoleName");
        }
    }
}
