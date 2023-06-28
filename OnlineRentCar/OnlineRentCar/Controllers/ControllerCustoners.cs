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
        public IActionResult Customers(User NewUser)
        {
            IEnumerable<User> objUsersList = _Database.Users;
            ViewData["FromObjCustomers"] = objUsersList;

            if (ModelState.IsValid)
            {
                _Database.Add(NewUser);
                _Database.SaveChanges();
            }
            else
                return RedirectToAction("Customers");

            return View();
        }

        //Редагування сторінки 
        //Get
         public IActionResult CustomersEdit(string? id)
         {
            if (id == null || id == "")
                return NotFound();

            var UserFromDb = _Database.Users.Find(id);

            if (UserFromDb == null)
                return NotFound();
            
            return View(UserFromDb);
         }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomersEditPost(User EditUser)
        {

            if (ModelState.IsValid)
            {
                _Database.Users.Update(EditUser);
                _Database.SaveChanges();
                return RedirectToAction("Customers");
            }
            return View(EditUser);
        }

        //Видалення сторінки 
        //get
        public IActionResult CustomersDelete(string? id)
        {
            if (id == null || id == "")
                return NotFound();

            var UserFromDb = _Database.Users.Find(id);

            if (UserFromDb == null)
                return NotFound();

            return View(UserFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomersDeletePost(string? id)
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
