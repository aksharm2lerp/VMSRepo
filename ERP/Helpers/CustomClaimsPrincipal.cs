using Business.Entities;
using Business.Interface;
using Kinfo.JsonStore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ERP.Helpers
{
    public class CustomClaimsPrincipal : UserClaimsPrincipalFactory<UserMasterMetadata>
    {
        private readonly UserManager<UserMasterMetadata> _userManger;
        private readonly IRoleAccessStore _roleAccessStore;
        private readonly ISiteUserService _usermanage;
        //private readonly UserManager<UserMasterMetadata> _userManger;
        public CustomClaimsPrincipal(ISiteUserService usermanage,IRoleAccessStore roleAccessStore, UserManager<UserMasterMetadata> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            _userManger = userManager;
            _roleAccessStore = roleAccessStore;
            _usermanage = usermanage;
        }

        public override async Task<ClaimsPrincipal> CreateAsync(UserMasterMetadata user)
        {
            try
            {
                UserMasterMetadata _user = new UserMasterMetadata();
                if (user != null)
                {

                    if (user.Email.IsNotStringNullOrEmpty())
                    {

                        var principal = await base.CreateAsync(user);
                        if (user.CompanyName.IsNotStringNullOrEmpty())
                        {
                            _user = UserManager.FindByIdAsync(user.UserID.ToString()).Result;
                        }
                        IList<string> roles = UserManager.GetRolesAsync(user).Result;
                        ((ClaimsIdentity)principal.Identity).AddClaims(new[]
                        {
                    new Claim("Id", user.UserID.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("CompanyID", user.CompanyID.ToString()),
                    //new Claim("DisplayName", user.DisplayName ?? user.Email),
                    //new Claim("LogoPath", user.CompanyLogoName??_user.CompanyLogoName),
                    //new Claim("CompanyName",user.CompanyName?? _user.CompanyName),
                });

                        var roleAccess = new RoleAccess
                        {
                            UserClaims = _usermanage.GetAllUserClaimAuth(user.CompanyID, user.UserID),
                            UserID = user.UserID.ToString(),
                            CompnayID = user.CompanyID.ToString()
                        };
                        await _roleAccessStore.AddRoleAccessAsync(roleAccess);

                        return principal;
                    }
                    return null;
                }
                return null;
            }
            catch 
            {
                throw ;
            }
        }
    }
}
