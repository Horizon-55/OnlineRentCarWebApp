using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineRentCar.Data;
using OnlineRentCar.Models;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace OnlineRentCar.Controllers
{
    public class ControllerCustomersCarsPage : Controller
    {

        private readonly ApplicationDbContext _Database;
        public ControllerCustomersCarsPage(ApplicationDbContext Database)
        {
            _Database = Database;
        }
            public IActionResult CustomersCarsPage(string data)
        {
            IEnumerable<Car> objCarList = _Database.cars;
            ViewData["FromDbObj"] = objCarList;
            ViewData["NameClient"] = data;
            return View();
        }
        public IActionResult SelectedBookCars(string? LNumberTb, string? Name)
        {
            if (LNumberTb == null || LNumberTb == "")
                return NotFound();

            var SelectCarsDb = _Database.cars.Find(LNumberTb);
            if (SelectCarsDb == null)
                return NotFound();
            ViewData["NameClient"] = Name;
            return View(SelectCarsDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectedBookCars(string LNumberTb, string? data, DateTimeOffset? DateRentBook, DateTimeOffset? DateReturnBook, string PriceTb)
        {
            var NameClient = new { data = data };
            var SelectUserDb = _Database.Users.SingleOrDefault(u => u.CreateLoginTb == data);
            if (SelectUserDb == null)
                return NotFound();

            var ChangeToIdNameClient = SelectUserDb.Id;
            if (ChangeToIdNameClient == null)
                return NotFound();

            int Days;
            var Fees = 0;
            if (DateRentBook != null && DateReturnBook != null)
            {
                TimeSpan DDays = DateReturnBook.Value - DateRentBook.Value;
                Days = DDays.Days;
                Fees = Convert.ToInt32(PriceTb) * Days;
            }
            else
            {
                ViewBag.ErrorMessage = "Оберіть дату початку оренди та завершення оренди!";
            }

            if (DateRentBook != null && DateReturnBook != null)
            {
                var IfLastRentIdNull = 0;
                var LastRentId = _Database.RentCars.OrderBy(x => x.RentId).LastOrDefault();
                if (LastRentId == null)
                {
                    IfLastRentIdNull++;
                    Rent RentCar = new Rent()
                    {
                        RentId = IfLastRentIdNull,
                        Car = LNumberTb,
                        User = ChangeToIdNameClient, //тут id
                        UserName = SelectUserDb.СustomerFullNameTb,
                        RentTime = (DateTimeOffset)DateRentBook,
                        ReturnDate = (DateTimeOffset)DateReturnBook,
                        Fees = Fees,
                    };

                    _Database.Set<Rent>().Add(RentCar);
                    _Database.SaveChanges();
                }
                else
                {
                    Rent RentCar = new Rent()
                    {
                        RentId = LastRentId.RentId + 1,
                        Car = LNumberTb,
                        User = ChangeToIdNameClient,
                        UserName = SelectUserDb.СustomerFullNameTb,
                        RentTime = (DateTimeOffset)DateRentBook,
                        ReturnDate = (DateTimeOffset)DateReturnBook,
                        Fees = Fees,
                    };
                    _Database.Set<Rent>().Add(RentCar);
                    _Database.SaveChanges();
                }

                var SelectCarChangeBook = _Database.cars.SingleOrDefault(v => v.LNumberTb == LNumberTb);
                if (SelectCarChangeBook != null)
                {
                    SelectCarChangeBook.StatusTb = "Заброньований";
                    _Database.cars.Update(SelectCarChangeBook);
                    _Database.SaveChanges();
                }

                return RedirectToAction("CustomersCarsPage", "ControllerCustomersCarsPage", NameClient);

            }
            return View();
        }

        public IActionResult CustomersPendingRentals(string Name)
        {
            var selectUserToMain = _Database.Users.SingleOrDefault(u => u.CreateLoginTb == Name); // порівняння id 
            var CurrectSelectedCars = _Database.RentCars.Where(u => _Database.RentCars.Any(z => z.User == selectUserToMain.Id)).ToList();
            ViewData["ClientName"] = Name;
            return View(CurrectSelectedCars);
        }
    }
}
