using Business.Entities;
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
    [DisplayName("Company")]
    public class CompanyController : SettingsController
    {
        private readonly UserManager<UserMasterMetadata> _userManager;
        private readonly SignInManager<UserMasterMetadata> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISiteCompanyRepository _companyManager;
        private readonly IMasterService _masterService;

        public CompanyController(ISiteCompanyRepository companyManager,IMasterService masterService, UserManager<UserMasterMetadata> userManager, SignInManager<UserMasterMetadata> signInManager, IWebHostEnvironment hostEnvironment)
        {

            this._userManager = userManager;
            this._signInManager = signInManager;
            _webHostEnvironment = hostEnvironment;
            this._masterService = masterService;
            _companyManager = companyManager;
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        public ActionResult Index([FromQuery(Name ="grid-page")]string gridpage="1", [FromQuery(Name = "grid-column")] string orderby="", [FromQuery(Name = "grid-dir")] string sortby= "0" , [FromQuery(Name = "grid-filter")] string gridfilter = "",[FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            
            Action<IGridColumnCollection<CompanyMasterMetadata>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                c.Add(o => o.CompanyCode)
                    .Titled("Company Code")
                    .SetWidth(70);

                c.Add(o => o.CompanyName)
                    .Titled("Company Name")
                    //.ThenSortByDescending(o => o.CompanyID)
                    .SetWidth(160);
                

                c.Add(o => o.CompanyGroupName)
                  .Titled("GroupName");


                c.Add(o => o.UnitName)
                  .Titled("Unit No/Name");

                c.Add(o => o.CompanyWebsiteText)
                    .Titled("Website");

                c.Add()
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn' href='Company/Edit/{o.CompanyID}' ><i class='bx bx-edit'></i></a>");


            };
            PagedDataTable<CompanyMasterMetadata> pds = _companyManager.GetAllCompanyAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(),sortby=="0"?"ASC":"DESC").Result;
            var server = new GridCoreServer<CompanyMasterMetadata>(pds, query, false, "ordersGrid",
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
                .ClearFiltersButton(false)
                ;
            return View(server.Grid);
        }
        
        public IActionResult Register()
        {
            var model = new Business.Entities.CompanyMasterMetadata();
            model.CreatedBy = USERID;
            
            var IndustryTypeList = _masterService.GetIndustryTypeMasterAsync();
            ViewData["IndustryTypeText"] = new SelectList(IndustryTypeList, "IndustryTypeID", "IndustryTypeText");

            var BusinessTypeList = _masterService.GetBusinessTypeMasterAsync();
            ViewData["BusinessTypeText"] = new SelectList(BusinessTypeList, "BusinessTypeID", "BusinessTypeText");

            return View("Register",model);
        }
        public IActionResult Edit(int id)
        {
            CompanyMasterMetadata model = _companyManager.GetCompnayAsync(id.ToString()).Result;
            var IndustryTypeList = _masterService.GetIndustryTypeMasterAsync();
            ViewData["IndustryTypeText"] = new SelectList(IndustryTypeList, "IndustryTypeID", "IndustryTypeText");

            var BusinessTypeList = _masterService.GetBusinessTypeMasterAsync();
            ViewData["BusinessTypeText"] = new SelectList(BusinessTypeList, "BusinessTypeID", "BusinessTypeText");

            return View("Edit", model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(CompanyMasterMetadata model)
        {

            if (model.ImageFile != null)
            {
                string uniqueFileName = UploadedFile(model);
                model.CompanyLogoImagePath = uniqueFileName;
                model.CompanyLogoName = uniqueFileName;
            }

            int compnayID = _companyManager.CreateOrUpdateCompanyAsync(model).Result;
            if (compnayID > 0 && model.CompanyID == 0)
            {
                model.CompanyID = compnayID;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        private string UploadedFile(CompanyMasterMetadata model)
        {
            string filePath, fileName = null;
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "companylogo");
            if (!string.IsNullOrEmpty(model.CompanyLogoName))
            {
                filePath = Path.Combine(uploadsFolder, model.CompanyLogoName);
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }
            if (model.ImageFile != null)
            {

                fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.ImageFile.FileName);
                filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}