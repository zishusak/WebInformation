using Microsoft.AspNetCore.Mvc;

namespace WebInformation.Controllers
{
    [Produces("application/json")]
    public class ApiStockDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
