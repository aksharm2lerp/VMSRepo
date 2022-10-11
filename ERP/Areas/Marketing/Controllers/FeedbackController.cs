using Business.Entities;
using Business.Interface;
using ERP.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System;
using Microsoft.AspNetCore.Authorization;
using Business.SQL;
using Business.Entities.Marketing.Feedback;
using GridShared;
using GridCore.Server;
using Business.Interface.Marketing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP.Areas.Marketing.Controllers
{
    [Area("Marketing"), Authorize]
    [DisplayName("Feedback")]
    public class FeedbackController : SettingsController
    {
        private readonly UserManager<UserMasterMetadata> _userManager;
        private readonly SignInManager<UserMasterMetadata> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMasterService _masterService;
        private readonly IMarketingFeedbackService _marketingFeedbackService;
        
        public FeedbackController(UserManager<UserMasterMetadata> userManager, SignInManager<UserMasterMetadata> signInManager, 
            IMasterService masterService, IWebHostEnvironment hostEnvironment, IMarketingFeedbackService marketingFeedbackService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._masterService = masterService;
            _webHostEnvironment = hostEnvironment;
            _marketingFeedbackService = marketingFeedbackService;
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        /*Feedback List Start*/
        public ActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;

            Action<IGridColumnCollection<MarketingFeedback>> columns = c =>
            {

                c.Add(o => o.MarketingFeedbackID, "SrNo")
                    .Titled("SrNo")
                    .Sortable(true)
                    .SetWidth(10);
                /*c.Add(o => o.PartyName)
                    .Titled("Party Name")
                    .Sortable(true)
                    .SetWidth(20);*/

                c.Add(o => o.FeedbackDate)
                    .Titled("Feedback Date")
                    .Sortable(true)
                    .SetWidth(20);

                c.Add(o => o.PartyTypeID)
                    .Titled("Party Type")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.Email)
                    .Titled("Email")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.MobileNo)
                    .Titled("Mobile")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.IsReceivedDocument)
                    .Titled("Document Status")
                    .Sortable(true)
                    .SetWidth(50);

                c.Add(o => o.Note)
                    .Titled("Note")
                    .Sortable(true)
                    .SetWidth(50);


                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn' href='Feedback/Edit/{o.MarketingFeedbackID}' ><i class='bx bx-edit'></i></a>");


            };
            PagedDataTable<MarketingFeedback> pds = _marketingFeedbackService.GetAllMarketingFeedbackAsync(gridpage.ToInt(),
                PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<MarketingFeedback>(pds, query, false, "ordersGrid",
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
        /*Feedback List End*/


        /*Feedback Create Page Start*/

        public IActionResult Create()
        {
            var model = new MarketingFeedback();
            model.CreatedOrModifiedBy = USERID;

            var PartyTypeList = _masterService.GetPartyTypeMasterAsync();
            ViewData["PartyTypeText"] = new SelectList(PartyTypeList, "PartyTypeID", "PartyTypeText");


            return View("Create", model);
        }

        /*Feedback Create Page End*/


        public async Task<IActionResult> CreateMarketingFeedback(MarketingFeedback model)
        {
            var _marketingFeedbackid= await _marketingFeedbackService.MarketingFeedbackCreateAsync(model);

            if (_marketingFeedbackid > 0)
            {
                model.MarketingFeedbackID = _marketingFeedbackid;
                return RedirectToAction("Index");
            }
            else
            {
                if (_marketingFeedbackid == 0)
                {

                    ModelState.AddModelError("message", "Error while saving!");

                }
                return View(model);
            }
            // If we got this far, something failed, redisplay form
        }

        

        public IActionResult Edit(int id)
        {
            MarketingFeedback model = _marketingFeedbackService.GetMarketingFeedbackAsync(id.ToString()).Result;
            model.CreatedOrModifiedBy = USERID;
            
            var PartyTypeList = _masterService.GetPartyTypeMasterAsync();
            ViewData["PartyTypeText"] = new SelectList(PartyTypeList, "PartyTypeID", "PartyTypeText");

            return View("Create", model);
        }
    }
}
