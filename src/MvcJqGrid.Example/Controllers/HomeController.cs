using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcJqGrid.Example.Models;

namespace MvcJqGrid.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository _repo;

        public HomeController()
        {
            _repo = new Repository();
        }

        public ActionResult Index()
        {
            return View("Basic");
        }

        public ActionResult Basic()
        {
            return View("Basic");
        }

        public ActionResult Search()
        {
            ViewData["CompanyNames"] = _repo.GetCompanyNames();
            return View();
        }

        public ActionResult DefaultSearchValue()
        {
            ViewData["CompanyNames"] = _repo.GetCompanyNames();
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

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult VirtualScrolling()
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
            var customers = _repo.GetCustomers(gridSettings);
            var totalCustomers = _repo.CountCustomers(gridSettings);

            var jsonData = new
            {
                total = totalCustomers / gridSettings.PageSize + 1,
                page = gridSettings.PageIndex,
                records = totalCustomers,
                rows = (
                    from c in customers
                    select new
                    {
                        id = c.CustomerId, // Remove ravendb prefix from identifier
                        cell = new[]
                    {
                        c.CustomerId,
                        c.Fullname,
                        c.Company,
                        c.EmailAddress,
                        c.LastModified.ToShortDateString(),
                        c.Telephone
                    }
                    }).ToArray()
            };

            return Json(jsonData);
        }

        public ActionResult TreeGrid()
        {
            return View();
        }


        public ActionResult TreeGridData()
        {
            Response.ContentType = "text/xml";
            return View();
        }
    }
}
