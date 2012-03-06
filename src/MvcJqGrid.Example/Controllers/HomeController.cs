using System.Linq;
using System.Web.Mvc;
using MvcJqGrid.Example.Models;

namespace MvcJqGrid.Example.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly Repository _repo;

        public HomeController()
        {
            _repo = new Repository();
        }

        public ActionResult Basic()
        {
            return View();
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
                        id = c.CustomerID,
                        cell = new[] 
                    { 
                        c.CustomerID.ToString(), 
                        string.Format("{0} {1}", c.FirstName, c.LastName),
                        c.CompanyName,
                        c.EmailAddress,
                        c.ModifiedDate.ToShortDateString(),
                        c.Phone
                    }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
