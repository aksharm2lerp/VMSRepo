using Business.Entities;
using Business.Entities.Department;
using Business.Interface;
using Business.SQL;
using ERP.Controllers;
using GridCore.Server;
using GridMvc.Server;
using GridShared;
using GridShared.Sorting;
using GridShared.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel;
 



namespace ERP.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin"), Authorize]
    [DisplayName("Department")]

    public class DepartmentController : SettingsController
    {
        private readonly UserManager<UserMasterMetadata> _userManager;
        private readonly SignInManager<UserMasterMetadata> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDepartmentService _departmentService;
        private readonly IMasterService _masterService;


        public DepartmentController(IDepartmentService idepartmentservice, UserManager<UserMasterMetadata> userManager,
            SignInManager<UserMasterMetadata> signInManager, IWebHostEnvironment hostEnvironment, IMasterService masterService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _webHostEnvironment = hostEnvironment;
            _departmentService = idepartmentservice;
            this._masterService = masterService;
        }
        

        
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        /*Department List*/
        public ActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;

            Action<IGridColumnCollection<Department>> columns = c =>
            {

                c.Add(o => o.DepartmentID, "SrNo")
                    .Titled("SrNo")
                    .SetWidth(20);
                c.Add(o => o.DepartmentName)
                    .Titled("Department Name")
                    .Sortable(true);
                c.Add(o => o.DepartmentGroupText)
                    .Titled("Department Group")
                    .Sortable(true);
                c.Add(o => o.IsActive)
                    .Titled("Active")
                    .Sortable(true);
            };
            PagedDataTable<Department> pds =  _departmentService.GetAllDepartmentAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<Department>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable()
                //.Filterable()
                //.WithMultipleFilters()
                //.Searchable(true, false)
                //.Groupable(true)
                .ClearFiltersButton(true)
                .Selectable(true)
                //.SetStriped(true)
                //.ChangePageSize(true)
                .WithGridItemsCount()
                //.WithPaging(PAGESIZE, pds.TotalItemCount)
                .ChangeSkip(false)
                .EmptyText("No record found")
                .ClearFiltersButton(false);
            return View(server.Grid);
        }
        /*Department List*/

        /*Department Create*/
        public IActionResult Create()
        {
            var model = new Business.Entities.Department.Department();
            model.CreatedBy = USERID;

            var DepartmentGroupIDList = _masterService.GetDepartmentGroupsMasterAsync();
            ViewData["DepartmentGroupText"] = new SelectList(DepartmentGroupIDList, "DepartmentGroupID", "DepartmentGroupText");


            return View("Create", model);
        }
        /*Department Create*/

        /*Add Department Group*/
        public IActionResult AddDepartmentGroup()
        {
            var model = new Business.Entities.Department.Department();
            model.CreatedBy = USERID;

            /*var DepartmentGroupIDList = _masterService.GetDepartmentGroupsMasterAsync();
            ViewData["DepartmentGroupText"] = new SelectList(DepartmentGroupIDList, "DepartmentGroupID", "DepartmentGroupText");
*/

            return View("AddDepartmentGroup", model);
        }
        /*Add Department Group*/
    }
}
