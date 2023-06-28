using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineRentCar.Data;
using OnlineRentCar.Models;

namespace OnlineRentCar.Controllers
{
    public class ControllerRents : Controller
    {
        private readonly ApplicationDbContext _Database;
        public ControllerRents(ApplicationDbContext Database)
        {
            _Database = Database;            
        }
        public IActionResult Rents()
        {
            IEnumerable<Rent> CarsRentList = _Database.RentCars;
            ViewData["CarsRentList"] = CarsRentList;
            return View();
        }
        //Get
        public IActionResult SubmitRentReturns (int? RentId)
        {
            if (RentId == null || RentId == 0)
                return NotFound();

            var ReturnsFromDb = _Database.RentCars.Find(RentId);

            if (ReturnsFromDb == null)
                return NotFound();

            return View(ReturnsFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRent(int RentIdTb, string LNumberTb, string IdCustomer, DateTimeOffset RentTimeCust, DateTimeOffset ReturnTimeCust, string FeesCustTb, int DelayTb, int FineTb)
        {
                if (RentIdTb != null && IdCustomer != null)
                {
                    var IfLastRentIdNull = 0;
                    var CheckIdReturn = _Database.ReturnsCars.OrderBy(x => x.RentId).LastOrDefault();
                    var GetCustomerName = _Database.Users.SingleOrDefault(u => u.Id == IdCustomer);
                    if (CheckIdReturn == null)
                    {
                        IfLastRentIdNull++;
                        Returns ReturnsCarNullId = new()
                        {
                            RentId = IfLastRentIdNull,
                            Car = LNumberTb,
                            User = IdCustomer,
                            UserName = GetCustomerName.СustomerFullNameTb,
                            Date = ReturnTimeCust,
                            Delay = DelayTb,
                            Fine = FineTb
                        };
                        _Database.ReturnsCars.Add(ReturnsCarNullId);
                        _Database.SaveChanges();
                    }
                    else
                    {
                        Returns ReturnsCar = new ()
                        {
                            RentId = CheckIdReturn.RentId + 1,
                            Car = LNumberTb,
                            User = IdCustomer,
                            UserName = GetCustomerName.СustomerFullNameTb,
                            Date = ReturnTimeCust,
                            Delay = DelayTb,
                            Fine = FineTb
                        };
                        _Database.ReturnsCars.Add(ReturnsCar);
                        _Database.SaveChanges();
                    }

                    var ChangeStatus = _Database.cars.SingleOrDefault(u => u.LNumberTb == LNumberTb);
                        if (ChangeStatus == null)
                            return NotFound();

                        ChangeStatus.StatusTb = "Доступний";
                        _Database.cars.Update(ChangeStatus);
                         _Database.SaveChanges();

                    Rent DeleteRent = new () {
                        RentId = RentIdTb,
                        Car = LNumberTb,
                        User = IdCustomer,
                        UserName = GetCustomerName.СustomerFullNameTb,
                        RentTime = RentTimeCust,
                        ReturnDate = ReturnTimeCust,
                        Fees = Convert.ToInt32(FeesCustTb)
                    };
                    _Database.RentCars.Remove(DeleteRent);
                    _Database.SaveChanges();
                    return RedirectToAction("Rents");
            }
                return RedirectToAction("Rents");

        }
    }
}
