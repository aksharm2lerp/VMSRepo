using Business.Entities.Employee;
using Business.Interface;
using Business.SQL;
using ERP.Controllers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace ERP.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin"), Authorize]
    public class EmployeeController : SettingsController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMasterService _masterService;
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string link;
        public EmployeeController(IEmployeeService employeeService, IMasterService masterService, IConfiguration configuration, IHostEnvironment hostEnvironment, IWebHostEnvironment webHostEnvironment)
        {
            _employeeService = employeeService;
            _masterService = masterService;
            _configuration = configuration;
            link = _configuration.GetSection("EmployeeImagePath")["EmployeeImages"];
            _hostEnvironment = hostEnvironment;
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<EmployeeMaster>> columns = c =>
            {
                c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
                c.Add(o => o.EmployeeCode).Titled("Employee Code").Sortable(true);
                c.Add(o => o.EmployeeName).Titled("Name").Sortable(true);
                c.Add(o => o.GenderText).Titled("Gender").Sortable(false);
                c.Add(o => o.IsActive).Titled("IsActive").Sortable(true);
                //Below code hide on phones
                c.Add().Titled("Update").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                .RenderValueAs(o => $"<a class='btn' href='Employee/EditEmployee/{o.EmployeeID}' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<EmployeeMaster> pds = _employeeService.GetAllEmployeesAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<EmployeeMaster>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable().ClearFiltersButton(true).Selectable(true).WithGridItemsCount().ChangeSkip(false).EmptyText("No record found").ClearFiltersButton(false);
            return View(server.Grid);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult AddNewEmployee()
        {
            var listDepartment = _masterService.GetAllDepartments();
            ViewData["DepartmentIdName"] = new SelectList(listDepartment, "DepartmentID", "DepartmentName");


            var listDesignation = _masterService.GetAllDesignations();
            ViewData["DesignationIdText"] = new SelectList(listDesignation, "DesignationID", "DesignationText");


            var listEmployees = _masterService.GetAllEmployees();
            ViewData["EmployeeIdName"] = new SelectList(listEmployees, "EmployeeID", "EmployeeName");

            var genders = _masterService.GetAllGenders();
            ViewData["GenderIdText"] = new SelectList(genders, "GenderID", "GenderText");

            var emailGroupMaster = _masterService.GetAllEmailGroupMaster();
            ViewData["EmailGroupName"] = new SelectList(emailGroupMaster, "EmailGroupID", "EmailGroupName");

            return View("AddNewEmployee");
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult AddUpdateEmployee(AddUpdateEmployee addUpdateEmployee)
        {
            var path1 = "";

            addUpdateEmployee.CompanyID = COMPANYID;
            addUpdateEmployee.CreatedOrModifiedBy = USERID;
            var id = _employeeService.AddUpdateEmployee(addUpdateEmployee).Result;

            if (id > 0 && addUpdateEmployee.ProfilePhoto != null)
            {
                string fileExtension = Path.GetExtension(addUpdateEmployee.ProfilePhoto.FileName);
                // Add logic for save file in image folder. 29-09-2022.
                EmployeeProfileImage employeeProfileImage = new EmployeeProfileImage();

                path1 = _webHostEnvironment.WebRootPath + link;  //full path Excluding file name ----  0
                string filepath = path1;  //full path including file name  -----  1
                string filename  = id + "_" + DateTime.Now.ToString().Replace(" ","").Replace("-","").Replace(":","")+ "_" + addUpdateEmployee.ProfilePhoto.FileName;
                string dbfilepath = link + filename;
                filepath = filepath + filename;

                employeeProfileImage.EmployeeID = id;
                employeeProfileImage.ImageName = filename;
                employeeProfileImage.ImagePath = dbfilepath;
                employeeProfileImage.CreatedOrModifiedBy = USERID;
                employeeProfileImage.IsActive = true;


                
                if (Directory.Exists(path1))
                {
                    using (var fileStream = new FileStream(filepath, FileMode.Create,FileAccess.ReadWrite))
                    {
                        addUpdateEmployee.ProfilePhoto.CopyTo(fileStream);
                    }

                    var profilePhotoId = _employeeService.UpdateEmployeeProfilePhoto(employeeProfileImage).Result;
                    if (profilePhotoId <= 0)
                        return View(ViewData["Message"] = "Profile photo not uploaded.");
                    else
                        return RedirectToAction("Index", "Employee");
                }
                return View(ViewData["Message"] = "Root directory not found.");
            }
            else
                return RedirectToAction("Index", "Employee");
        }

        public ActionResult EditEmployee(int id)
        {
            AddUpdateEmployee updateEmployee = _employeeService.GetEmployeeAsync(id).Result;

            var listDepartment = _masterService.GetAllDepartments();
            ViewData["DepartmentIdName"] = new SelectList(listDepartment, "DepartmentID", "DepartmentName");

            var listDesignation = _masterService.GetAllDesignations();
            ViewData["DesignationIdText"] = new SelectList(listDesignation, "DesignationID", "DesignationText");


            var listEmployees = _masterService.GetAllEmployees();
            ViewData["EmployeeIdName"] = new SelectList(listEmployees, "EmployeeID", "EmployeeName");

            var genders = _masterService.GetAllGenders();
            ViewData["GenderIdText"] = new SelectList(genders, "GenderID", "GenderText");

            var emailGroupMaster = _masterService.GetAllEmailGroupMaster();
            ViewData["EmailGroupName"] = new SelectList(emailGroupMaster, "EmailGroupID", "EmailGroupName");

            string path = updateEmployee.ImagePath;
            ViewData["Image"] = path;


            return View(updateEmployee);
        }

    }
}
