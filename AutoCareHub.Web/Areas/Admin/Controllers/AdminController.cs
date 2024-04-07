using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Represents admin controller.
    /// </summary>
    public class AdminController : BaseController
    {
        /// <summary>
        /// Loads admin home page.
        /// </summary>
        /// <returns>the admin home page</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
