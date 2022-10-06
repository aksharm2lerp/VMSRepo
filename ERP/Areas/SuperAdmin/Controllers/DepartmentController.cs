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
using System.Threading.Tasks;

namespace ERP.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin"), Authorize]
    [DisplayName("Department")]

    public class DepartmentController : SettingsController
    {
        private readonly IDepartmentService _department;
        private readonly UserManager<UserMasterMetadata> _userManager;
        private readonly SignInManager<UserMasterMetadata> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDepartmentService _departmentService;
        private readonly IMasterService _masterService;
        private readonly IDepartmentGroupService _departmentGroupService;


        public DepartmentController(IDepartmentService department, UserManager<UserMasterMetadata> userManager,
             SignInManager<UserMasterMetadata> signInManager, IMasterService masterService, IWebHostEnvironment hostEnvironment,
             IDepartmentService idepartmentservice, IDepartmentGroupService idepartmentgroupservices)
        {   
            this._department= department;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._masterService = masterService;
            _webHostEnvironment = hostEnvironment;
            _departmentService = idepartmentservice;
            _departmentGroupService = idepartmentgroupservices;
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
                    .Sortable(true)
                    .SetWidth(20);
                c.Add(o => o.DepartmentGroupText)
                    .Titled("Department Group")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.IsActive)
                    .Titled("Active")
                    .Sortable(true);

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn' href='Department/Edit/{o.DepartmentID}' ><i class='bx bx-edit'></i></a>");


            };
            PagedDataTable<Department> pds =  _departmentService.GetAllDepartmentAsync(gridpage.ToInt(), 
                PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<Department>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable()
                //.Filterable()
                //.WithMultipleFilters()
                .Searchable(true, false)
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

        /*Department Create Page*/
        public IActionResult Create()
        {
            var model = new Business.Entities.Department.Department();
            model.CreatedOrModifiedBy = USERID;

            var DepartmentGroupIDList = _masterService.GetDepartmentGroupsMasterAsync();
            ViewData["DepartmentGroupText"] = new SelectList(DepartmentGroupIDList, "DepartmentGroupID", "DepartmentGroupText");

            return View("Create", model);
        }
        /*Department Create Page*/

        /*Department Register*/
        public async Task<IActionResult> DepartmentRegister(Department model)
        {
            int _deptartmentID = await _department.CreateAsync(model);
            if (_deptartmentID > 0)
            {
                model.DepartmentID = _deptartmentID;
                return RedirectToAction("Index");
            }
            else
            {
                if (_deptartmentID == 0)
                {
                     
                        ModelState.AddModelError("message", "Error while saving!"  );
                    
                }
                return View(model);
            }
            // If we got this far, something failed, redisplay form
        }
        /*Department Register*/

        /*Add Department Group*/
        public IActionResult AddDepartmentGroup()
        {
            var model = new Business.Entities.Department.DepartmentGroup();
            model.CreatedOrModifiedBy = USERID;

            /*var DepartmentGroupIDList = _masterService.GetDepartmentGroupsMasterAsync();
            ViewData["DepartmentGroupText"] = new SelectList(DepartmentGroupIDList, "DepartmentGroupID", "DepartmentGroupText");
*/

            return View("AddDepartmentGroup", model);
        }
        /*Add Department Group*/

        /*Add Department Group Name*/
        [HttpPost]
        public async Task<IActionResult> DepartmentGroupTextRegister(DepartmentGroup model)
        {
            var result = await _departmentGroupService.CreateDepartmentGroupAsync(new DepartmentGroup() { DepartmentGroupText = model.DepartmentGroupText, Remark = model.Remark });
            /*if (result.Succeeded)*/
            if (result > 0)
                {
                return RedirectToAction("Create");
                }
            else
            {
                /* if (result.Errors.Count() > 0)
                 {
                     foreach (var error in result.Errors)
                     {
                         ModelState.AddModelError("message", error.Description);
                     }
                 }
                 return View(model);*/
                return RedirectToAction("AddDepartmentGroup");

            }
            // If we got this far, something failed, redisplay form
        }
        /*Add Department Group Name*/

        /*Edit Department*/
        public IActionResult Edit(int id)
        {
            Department model = _department.GetDepartmentAsync(id.ToString()).Result;
            model.CreatedOrModifiedBy = USERID;

            var DepartmentGroupIDList = _masterService.GetDepartmentGroupsMasterAsync();
            ViewData["DepartmentGroupText"] = new SelectList(DepartmentGroupIDList, "DepartmentGroupID", "DepartmentGroupText");

            return View("Edit", model);
        }
        /*Edit Department*/

        /*Update Department*/
        [HttpPost]
        public async Task<IActionResult> DepartmentEdit(Department departmet)
        {
            departmet.CreatedOrModifiedBy = USERID;  
            
            int DepartmentID = _department.CreateOrUpdateDepartmentAsync(departmet).Result;
            if (DepartmentID > 0)
            {
                departmet.DepartmentID = DepartmentID;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        /*Update Department*/
    }
}
