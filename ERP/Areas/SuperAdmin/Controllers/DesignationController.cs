using Business.Entities;
using Business.Entities.Designation;
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin"), Authorize]
    [DisplayName("Designation")]
    public class DesignationController : SettingsController
    {
        private readonly UserManager<UserMasterMetadata> _userManager;
        private readonly SignInManager<UserMasterMetadata> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMasterService _masterService;
        private readonly IDesignationService _iDesignationService;

        public DesignationController(IDesignationService iDesignationService, IMasterService masterService, UserManager<UserMasterMetadata> userManager, SignInManager<UserMasterMetadata> signInManager, IWebHostEnvironment hostEnvironment)
        {

            this._userManager = userManager;
            this._signInManager = signInManager;
            _webHostEnvironment = hostEnvironment;
            this._masterService = masterService;
            _iDesignationService = iDesignationService;
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        /*Designation List*/
        public ActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            
            Action<IGridColumnCollection<DesignationMaster>> columns = c =>
            {
                c.Add(o => o.SrNo).Titled("SrNo").SetWidth(20);

                c.Add(o => o.DesignationText).Titled("Designation").SetWidth(80);

                c.Add(o => o.Description).Titled("Designation Description").SetWidth(90);
                //.ThenSortByDescending(o => o.CompanyID)

                c.Add(o => o.DesignationLevel).Titled("Level").SetWidth(100);

                c.Add().Titled("Edit").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs") //hide on phones
                 .RenderValueAs(o => $"<a class='btn' href='Designation/Edit/{o.DesignationID}' ><i class='bx bx-edit'></i></a>");


            };
            PagedDataTable<DesignationMaster> pds = _iDesignationService.GetAllDesignationAsync(gridpage.ToInt(), 
                PAGESIZE, search, orderby.RemoveSpace(),sortby=="0"?"ASC":"DESC").Result;
            var server = new GridCoreServer<DesignationMaster>(pds, query, false, "ordersGrid",
                columns, PAGESIZE,pds.TotalItemCount)
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
        /*Designation List*/


        /*Designation Create Page*/
        public IActionResult Create()
        {
            var model = new Business.Entities.Designation.DesignationMaster();
            model.CreatedOrModifiedBy = USERID;

            var DesignationGroupIDList = _masterService.GetDesignationGroupMasterAsync();
            ViewData["DesignationGroupText"] = new SelectList(DesignationGroupIDList, "DesignationGroupID", "DesignationGroupText");

            return View("Create", model);
        }
        /*Designation Create Page*/

        /*Add Designation Level Page*/
        public IActionResult AddDesignationGroup()
        {
            var model = new Business.Entities.Designation.DesignationGroup();
            model.CreatedOrModifiedBy = USERID;

            return View("AddDesignationGroup", model);
        }
        /*Add Designation Level Page*/

        /*Add Designation Level Name*/
        [HttpPost]
        public async Task<IActionResult> AddDesignationGroup(DesignationGroup model)
        {
            model.CreatedOrModifiedBy = USERID;
            var result = await _iDesignationService.CreateDesignationGroupAsync(model);
            
            if (result > 0)
            {
                return RedirectToAction("Create");
            }
            else
            {
                return RedirectToAction("AddDesignationGroup");
            }
        }
        /*Add Designation Level Name*/


        /*Designation Register*/
        public async Task<IActionResult> DesignationRegister(DesignationMaster model)
        {
            model.CreatedOrModifiedBy = USERID;
            int _designationID = await _iDesignationService.DesignationRegisterAsync(model);
            if (_designationID > 0)
            {
                model.DesignationID = _designationID;
                return RedirectToAction("Index");
            }
            else
            {
                if (_designationID == 0)
                {
                 //return RedirectToAction("Error");
                    ModelState.AddModelError("message", "Error while saving!");

                }
                return View(model);
            }
        }
        /*Designation Register*/

        /*Designation Edit*/
        public IActionResult Edit(int id)
        {
            DesignationMaster model = _iDesignationService.GetDesignationAsync(id.ToString()).Result;
            model.CreatedOrModifiedBy = USERID;

            var DesignationGroupIDList = _masterService.GetDesignationGroupMasterAsync();
            ViewData["DesignationGroupText"] = new SelectList(DesignationGroupIDList, "DesignationGroupID", "DesignationGroupText");

            return View("Edit", model);
        }
        /*Designation Edit */


    }
}
