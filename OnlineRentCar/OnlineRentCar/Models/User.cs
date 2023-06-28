using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineRentCar.Models
{
    public class User
    {
        [Key]
        public string Id {get; set;}
        [Required(ErrorMessage = "ПІБ обов'язковий для введення!")]
        public string СustomerFullNameTb { get; set; }
        [Required(ErrorMessage = "Адреса клієнта обов'язкове для введення!")]
        public string _AddreessTb { get; set; }
        [Required(ErrorMessage = "Номер телефону обов'язкове для введення!")]
        public string PhoneCustomerTb { get; set; }
        [Required(ErrorMessage = "Створення паролю обов'язкове для введення!")]
        public string CreatePasswordTb { get; set; }
        [Required(ErrorMessage = "Створення логіну обов'язкове для введення!")]
        public string CreateLoginTb { get; set; }
        public ICollection <Rent> Rent;
        public ICollection<Returns> Returns;
        public User()
        {
            
        }
        public User(string _id, string _CustomerFullName, string AddreessTb, string _PhoneCustomerTb, string _CreatePasswordTb, string _CreateLoginTb)
        {
            Id = _id;
            СustomerFullNameTb = _CustomerFullName;
            _AddreessTb = AddreessTb;
            PhoneCustomerTb = _PhoneCustomerTb;
            CreatePasswordTb = _CreatePasswordTb;
            CreateLoginTb = _CreateLoginTb;
        }
    }
}
