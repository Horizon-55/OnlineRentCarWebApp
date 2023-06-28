using Microsoft.AspNetCore.Mvc;

namespace OnlineRentCar.Controllers
{
    public class ControllerMainAdminPanel : Controller
    {
        public IActionResult MainAdminPanel()
        {
            return View();
        }
    }
}
