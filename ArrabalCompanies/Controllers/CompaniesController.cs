using ArrabalCompanies.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArrabalCompanies.Controllers
{
    public class CompaniesController : Controller
    {
        DB db = new DB();

        public IActionResult Index(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                var r = new RedirectResult("/Identity/Account/Login");
                return r;
            }
            ViewData["pagenum"] = id;
            ViewData["maxpage"] = db.CountCompanies()/50;
            var a = db.GetCompanies(id);
            return View(a);
        }

        public IActionResult Details(int id = 1)
        {
            if(!User.Identity.IsAuthenticated)
            {
                var r = new RedirectResult("/Identity/Account/Login");
                return r;
            }
            return View(db.GetCompanyDetails(id));
        }
    }
}
