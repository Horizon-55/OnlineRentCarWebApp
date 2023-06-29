using Microsoft.AspNetCore.Mvc;
using OnlineRentCar.Data;
using OnlineRentCar.Models;

namespace OnlineRentCar.Controllers
{
    public class ControllerCustoners : Controller
    {
        private readonly ApplicationDbContext _Database;
        public ControllerCustoners(ApplicationDbContext Database)
        {
            _Database = Database;
        }
        //Get
        public IActionResult Customers()
        {
            IEnumerable<User> objUsersList = _Database.Users;
            ViewData["FromObjCustomers"] = objUsersList;
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Customers(string FullName, string AddressCust, string CreateLoginCust, string CreatePass, string PhoneNumber)
        {
            IEnumerable<User> objUsersList = _Database.Users;
            ViewData["FromObjCustomers"] = objUsersList;

            if (ModelState.IsValid)
            {
                User NewUser = new() {
                    СustomerFullNameTb = FullName,
                    _AddreessTb = AddressCust,
                    PhoneCustomerTb = PhoneNumber,
                    CreateLoginTb = CreateLoginCust,
                    CreatePasswordTb = CreatePass
                };
                _Database.Add(NewUser);
                _Database.SaveChanges();
            }
            else
                return RedirectToAction("Customers");

            return View();
        }

        //Редагування сторінки 
        //Get
         public IActionResult CustomersEdit(int? id)
         {
            if (id == null || id == 0)
                return NotFound();

            var UserFromDb = _Database.Users.Where(x => x.Id == id).SingleOrDefault();

            if (UserFromDb == null)
                return NotFound();
            
            return View(UserFromDb);
         }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomersEditPost(User IdUser)
        {

            if (ModelState.IsValid)
            {
                _Database.Users.Update(IdUser);
                _Database.SaveChanges();
                return RedirectToAction("Customers");
            }
            return View(IdUser);
        }

        //Видалення сторінки 
        //get
        public IActionResult CustomersDelete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var UserFromDb = _Database.Users.Find(id);

            if (UserFromDb == null)
                return NotFound();

            return View(UserFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomersDeletePost(int? id)
        {
            var SelectedUser = _Database.Users.Find(id);

            if (SelectedUser == null)
                return NotFound();

            _Database.Users.Remove(SelectedUser);
            _Database.SaveChanges();
            return RedirectToAction("Customers");
        }
    }
}
