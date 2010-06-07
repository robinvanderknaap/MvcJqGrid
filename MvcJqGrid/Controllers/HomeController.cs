using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcJqGrid.Models;
using System.Collections;
using MvcJqGrid.HtmlHelpers;

namespace MvcJqGrid.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private Repository repo;

        public HomeController()
        {
            repo = new Repository();
        }

        // Basic Example
        public ActionResult Basic()
        {
            return View();
        }

        public ActionResult Search()
        {
            ViewData["CompanyNames"] = this.repo.getCompanyNames();
            return View();
        }

        public ActionResult Search2()
        {
            return View();
        }

        public ActionResult Toolbar()
        {
            return View();
        }

        public ActionResult Multiselect()
        {
            return View();
        }

        public ActionResult Formatters()
        {
            return View();
        }

        public ActionResult Formatters2()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// AJAX request, retrieves data for basic grid
        /// </summary>
        /// <param name="gridSettings">Settings received from jqGrid request</param>
        /// <returns>JSON view containing data for basic grid</returns>
        public ActionResult GridDataBasic(GridSettings gridSettings)
        {
            var customers = this.repo.getCustomers(gridSettings);
            int totalCustomers = this.repo.countCustomers(gridSettings);
            
            var jsonData = new
            {
                total = totalCustomers / gridSettings.PageSize + 1,
                page = gridSettings.PageIndex,
                records = totalCustomers,
                rows = (
                    from c in customers
                    select new { id = c.CustomerID, cell = new string[] { 
                                                                            c.CustomerID.ToString(), 
                                                                            string.Format("{0} {1}", c.FirstName, c.LastName),
                                                                            c.CompanyName,
                                                                            c.EmailAddress,
                                                                            c.ModifiedDate.ToShortDateString(),
                                                                            c.Phone
                                                                        }}).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
