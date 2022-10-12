using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Business.Entities;
using Business.Interface;
using Business.Service;
using Business.Interface.Marketing;
using Business.Interface.IPartyType;
using Business.Service.Marketing;
using Business.Service.PartyTypeService;
using ERP.Helpers;
using ERP.Permission;
using GridMvc;
using Kinfo.JsonStore.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ERP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }
        private IMasterService masterService { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Repos etc
            DependencyContainer.RegisterServices(services);
            services.AddGridMvc();

            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentGroupService, DepartmentGroupService>();
            services.AddScoped<IDesignationService, DesignationService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ISecurityOfficerService, SecurityOfficerService>();
            services.AddScoped<IMarketingFeedbackService, MarketingFeedbackService>();
            services.AddScoped<IPartyTypeService, PartyTypeService>();
            services.AddIdentity<UserMasterMetadata, RoleMasterMetadata>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
            services.AddScoped<IUserClaimsPrincipalFactory<UserMasterMetadata>, CustomClaimsPrincipal>();

            //services.AddSingleton<IMvcControllerDiscovery, MvcControllerDiscovery>();
            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(90);
            //    options.LoginPath = "/";
            //    options.AccessDeniedPath = "/404";
            //    options.SlidingExpiration = true;
            //    // options.Events = new MyCookieAuthenticationEvents();

            //});

            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddJsonStore();

            services.AddDynamicAuthorization(options => options.DefaultAdminUser = "mo.esmp@gmail.com")
                .AddJsonStore();

            services.AddMemoryCache();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IVisitorService, VisitorService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();


            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapAreaControllerRoute(
                //name: "SuperAdmin",
                //areaName: "SuperAdmin",
                //pattern: "SuperAdmin/{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapAreaControllerRoute(
                //name: "Admin",
                //areaName: "Admin",
                //pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default-area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            app.UseNotyf();
        }
    }
}
