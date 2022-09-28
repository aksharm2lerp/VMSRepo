using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ERP.Controllers
{

    public class SettingsController : Controller
    {
        private static HttpContext _httpContext => new HttpContextAccessor().HttpContext;

        private static IWebHostEnvironment _webHost = new HttpContextAccessor().HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();

        public static int USERID
        {
            get
            {
                try
                {
                    var response = 0;
                    var userId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                    if (!string.IsNullOrWhiteSpace(userId))
                        response = Convert.ToInt32(userId);
                    return response;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static int COMPANYID
        {
            get
            {
                try
                {
                    var response = 0;
                    var compnayID = _httpContext.User.FindFirstValue("CompanyID");

                    if (!string.IsNullOrWhiteSpace(compnayID))
                        response = Convert.ToInt32(compnayID);
                    return response;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static string USERNAME
        {
            get
            {
                try
                {
                    var response = "User";
                    var uname = _httpContext.User.FindFirstValue(ClaimTypes.Name);
                    if (!string.IsNullOrWhiteSpace(uname))
                        response = uname;

                    return response;
                }
                catch
                {
                    return "User";
                }
            }
        }
        public static string COMPANYNAME
        {
            get
            {
                try
                {
                    var response = "ERP";
                    var cName = _httpContext.User.FindFirstValue("CompanyName");
                    if (!string.IsNullOrWhiteSpace(cName))
                        response = cName;

                    return response;
                }
                catch
                {
                    return "ERP";
                }
            }
        }
        public static string LOGOPATH
        {
            get
            {
                try
                {
                    var filePath = "#";
                    //var fullPath = Path.Combine("companylogo");
                    //var filename = _httpContext.User.FindFirstValue("LogoPath");
                    string filename = Path.Combine(_webHost.WebRootPath, "companylogo\\logo.png");
                    if (!string.IsNullOrEmpty(filename))
                    {
                        filePath = filename;
                    }
                    return filePath;
                }
                catch
                {
                    return "#";
                }
            }
        }
        public static int PAGESIZE
        {
            get { return 5; }
        }
    }
}
