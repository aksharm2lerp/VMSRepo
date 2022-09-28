using Business.Entities;
using Business.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service
{
    public static class DependencyContainer
    {
        /// <summary>
        /// Connects our interfaces and their implementations from multiple projects 
        /// into single point of reference. That is the purpose of IoC layer.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            // Register Repo
            services.AddScoped<ISiteUserService, SiteUserRepository>();
            services.AddScoped<ISiteRoleRepository, SiteRoleRepository>();
            services.AddScoped<IMasterService, MasterService>();



            services.AddTransient<IUserStore<UserMasterMetadata>, UserStore>();
            services.AddTransient<IRoleStore<RoleMasterMetadata>, RoleStore>();
            services.AddTransient<ISiteCompanyRepository, CompanyService>();
            services.AddTransient<ISuperAdminService, SuperAdminService>();
            services.AddTransient<IVisitorService, VisitorService>();

            // Add application services.
            //services.AddTransient<IEmailService, EmailService>();

        }
    }
}
