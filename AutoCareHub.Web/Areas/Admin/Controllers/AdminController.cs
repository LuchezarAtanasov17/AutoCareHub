using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
