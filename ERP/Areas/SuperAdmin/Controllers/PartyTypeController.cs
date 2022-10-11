using Business.Entities;
using Business.Entities.PartyType;
using Business.Interface.IPartyType;
using Business.SQL;
using ERP.Controllers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ERP.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin"), Authorize]
    [DisplayName("Marketing")]
    public class PartyTypeController : SettingsController
    {
        private readonly IPartyTypeService iPartyType;
        public PartyTypeController(IPartyTypeService iPartyType)
        {
            this.iPartyType = iPartyType;
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        /* Party Type Listing Page Start */
        public ActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;

            Action<IGridColumnCollection<PartyType>> columns = c =>
            {
                c.Add(o => o.SrNo)
                    .Titled("SrNo")
                    .SetWidth(10);

                c.Add(o => o.PartyTypeText)
                    .Titled("Party Type Name")
                    .SetWidth(70);

                c.Add(o => o.Remark)
                    .Titled("Remark")
                    .SetWidth(160);

                c.Add()
                    .Titled("Edit")
                    .Encoded(false)
                    .Sanitized(false)
                    .SetWidth(60)
                    .Css("hidden-xs") //hide on phones
                    .RenderValueAs(o => $"<a class='btn' href='PartyType/Create/{o.PartyTypeID}' ><i class='bx bx-edit'></i></a>");


            };
            PagedDataTable<PartyType> pds = iPartyType.GetAllPartyTypeAsync(gridpage.ToInt(),
                PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<PartyType>(pds, query, false, "ordersGrid",
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
        /* Party Type Listing Page End */

        /* Party Type Create Page Start */
        public IActionResult Create(int id)
        {
            PartyType model = new Business.Entities.PartyType.PartyType();
            model.CreatedOrModifiedBy = USERID;
            if (id > 0)
            {
                model = iPartyType.GetPartyTypeAsync(id).Result;
                return View(model);
            }
            else 
            {
                return View("Create", model);
            }
            
        }
        /* Party Type Create Page End */

        /* PratyTypeRegister Action Start */
        [HttpPost]
        public async Task<IActionResult> PratyTypeRegister(PartyType model)
        {
            model.CreatedOrModifiedBy = USERID;
            var PartyTypeID = await iPartyType.CreateOrUpdatePratyTypeAsync(model);
            if (PartyTypeID > 0 && model.PartyTypeID == 0)
            {
                model.PartyTypeID = PartyTypeID;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        /* PratyTypeRegister Action End */
    }
}
