using Microsoft.AspNetCore.Mvc;

namespace ArrabalCompanies.Controllers
{
    public class CompaniesController : Controller
    {
        DB db = new DB();

        public IActionResult Index()
        {
            var a = db.GetCompaniesNames();
            return View(a);
        }

        public IActionResult Details(int id = 1)
        {
            return View(db.GetCompanyDetails(id));
        }
    }
}
