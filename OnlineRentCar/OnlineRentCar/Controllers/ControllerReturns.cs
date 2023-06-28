using Microsoft.AspNetCore.Mvc;
using OnlineRentCar.Data;
using OnlineRentCar.Models;

namespace OnlineRentCar.Controllers
{
    public class ControllerReturns : Controller
    {
        private readonly ApplicationDbContext _Database;
        public ControllerReturns(ApplicationDbContext Database)
        {
           _Database = Database;
        }
        public IActionResult Returns()
        {
            IEnumerable<Returns> objReturnsList = _Database.ReturnsCars;
            ViewData["ReturnedCars"] = objReturnsList;
            return View();
        }
    }
}
