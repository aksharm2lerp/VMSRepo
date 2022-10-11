using Business.Entities.SecurityOfficer;
using Business.Interface;
using Business.SQL;
using DocumentFormat.OpenXml.Office2010.Excel;
using ERP.Controllers;
using GridCore.Server;
using GridShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace ERP.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin"), Authorize]
    public class SecurityOfficerController : SettingsController
    {
        private readonly ISecurityOfficerService _securityOfficerService;
        private readonly IMasterService _masterService;
        public SecurityOfficerController(ISecurityOfficerService securityOfficerService, IMasterService masterService)
        {
            _securityOfficerService = securityOfficerService;
            _masterService = masterService;
        }
        public ActionResult Index([FromQuery(Name = "grid-page")] string gridpage = "1", [FromQuery(Name = "grid-column")] string orderby = "", [FromQuery(Name = "grid-dir")] string sortby = "0", [FromQuery(Name = "grid-filter")] string gridfilter = "", [FromQuery(Name = "grid-search")] string search = "")
        {
            int userid = USERID;
            IQueryCollection query = Request.Query;
            string value = string.Empty;
            Action<IGridColumnCollection<SecurityOfficerMaster>> columns = c =>
            {
                c.Add(o => o.SrNo, "SrNo").Titled("Sr.No.").SetWidth(20);
                c.Add(o => o.SecurityOfficerName).Titled("Security Officer Name").Sortable(true);
                c.Add(o => o.SecurityAgencyName).Titled("Security Agency Name").Sortable(true);
                c.Add(o => o.SecurityOfficerMobile).Titled("Security Officer Mobile").Sortable(false);
                c.Add(o => o.IdentityProofTypeText).Titled("Identity Proof").Sortable(true);
                c.Add(o => o.IdentityProofNumber).Titled("Identity Proof number").Sortable(false);
                c.Add(o => o.IsActive).Titled("IsActive").Sortable(true);
                //Below code hide on phones
                c.Add().Titled("Update").Encoded(false).Sanitized(false).SetWidth(60).Css("hidden-xs")
                .RenderValueAs(o => $"<a class='btn' href='SecurityOfficer/AddUpdateSecurityOfficer/{o.SecurityOfficerID}' ><i class='bx bx-edit'></i></a>");
            };
            PagedDataTable<SecurityOfficerMaster> pds = _securityOfficerService.GetAllSecurityOfficerAsync(gridpage.ToInt(), PAGESIZE, search, orderby.RemoveSpace(), sortby == "0" ? "ASC" : "DESC").Result;
            var server = new GridCoreServer<SecurityOfficerMaster>(pds, query, false, "ordersGrid",
                columns, PAGESIZE, pds.TotalItemCount)
                .Sortable().ClearFiltersButton(true).Selectable(true).WithGridItemsCount().ChangeSkip(false).EmptyText("No record found").ClearFiltersButton(false);
            return View(server.Grid);
        }

        [HttpGet]
        public ActionResult AddUpdateSecurityOfficer(int id)
        {
            if (id > 0)
            {
                SecurityOfficerMaster securityOfficerMaster = _securityOfficerService.GetSecurityOfficerAsync(id).Result;
                var idProofTypes = _masterService.GetIdentityProofTypeAsync();
                ViewData["IdentityProofType"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(idProofTypes, "IdentityProofTypeID", "IdentityProofTypeText");
                return View(securityOfficerMaster);
            }
            else
            {
                var idProofTypes = _masterService.GetIdentityProofTypeAsync();
               
                ViewData["IdentityProofType"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(idProofTypes, "IdentityProofTypeID", "IdentityProofTypeText");
                return View("AddUpdateSecurityOfficer");
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public ActionResult AddUpdateSecurityOfficer(SecurityOfficerMaster securityOfficerMaster)
        {
            securityOfficerMaster.CompanyID = COMPANYID;
            securityOfficerMaster.CreatedOrModifiedBy = USERID;
            var id = _securityOfficerService.AddUpdateSecurityOfficer(securityOfficerMaster).Result;
            return RedirectToAction("Index", "SecurityOfficer");
        }
    }
}
