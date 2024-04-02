using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AutoCareHub.Web.Areas.Admin.Constants;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
    }
}
