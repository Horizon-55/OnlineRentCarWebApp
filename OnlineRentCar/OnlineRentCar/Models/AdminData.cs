using System.ComponentModel.DataAnnotations;

namespace OnlineRentCar.Models
{
    public class AdminData
    {
        [Key]
        public string LoginAdmin { get; set; }
        public string PasswordAdmin { get; set; }
        public AdminData()
        {
            
        }
        public AdminData(string _LoginAdmin, string _PasswordAdmin)
        {
            LoginAdmin = _LoginAdmin;
            PasswordAdmin = _PasswordAdmin;
        }
    }
}
