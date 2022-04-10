using Microsoft.AspNetCore.Mvc;

namespace SlitherlinkWeb.Controllers
{
    public class SlitherLinkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
