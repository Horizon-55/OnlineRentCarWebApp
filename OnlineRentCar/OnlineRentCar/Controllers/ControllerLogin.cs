using Microsoft.AspNetCore.Mvc;
using OnlineRentCar.Data;

namespace OnlineRentCar.Controllers
{
    public class ControllerLogin : Controller
    {
        private readonly ApplicationDbContext _Database;
        public ControllerLogin(ApplicationDbContext Database)
        {
            _Database = Database;
        }
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(string SelectedRadio, string LoginUserAdmin, string PasswordUserAdmin)
        {
            if (SelectedRadio == "ClientRadioBtn")
            {
                //перевірка чи є в базі даних логін користувача та пароль одинаковий
                var user = _Database.Users.SingleOrDefault(u => u.CreateLoginTb == LoginUserAdmin);
                if (user != null && user.CreatePasswordTb == PasswordUserAdmin)
                {
                    var SelectUser = new { data = user.CreateLoginTb };
                    return RedirectToAction("CustomersCarsPage", "ControllerCustomersCarsPage", SelectUser);
                }
                else
                {
                    ViewBag.ErrorMessage = "Неправильний логін або пароль.";
                    return View();
                }
                

            }
            if (SelectedRadio == "AdminRadioBtn")
            {
                //перевірка чи є в базі даних логін пароль адміна. 
                var AdminSelect = _Database.admindata.SingleOrDefault(a => a.LoginAdmin == LoginUserAdmin);
                if (AdminSelect != null && AdminSelect.PasswordAdmin == PasswordUserAdmin)
                {
                    return RedirectToAction("MainAdminPanel", "ControllerMainAdminPanel");
                }
                else
                {
                    ViewBag.ErrorMessage = "Неправильний логін або пароль.";
                    return View();
                }
                    
            }
            else
                return View();
        }
    }
}
