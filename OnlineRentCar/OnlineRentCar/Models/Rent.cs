using OnlineRentCar.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OnlineRentCar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OnlineRentCar.Models
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RentId { get; set; }
        [Required]
        [ForeignKey("LNumberCar")]
        public string Car { get; set; } //зовнішній ключ до car а саме lmNumber
        [ForeignKey("UserId")]
        public string User { get; set; } //зовнішній ключ до User а саме до первнинного ключа
        public string UserName { get; set; } // для відображенння таблиці клієнта
        [Required(ErrorMessage = "Оберіть дату початку оренди!")]
        public DateTimeOffset RentTime { get; set; }
        [Required(ErrorMessage = "Оберіть дату завершення оренди!")]
        public DateTimeOffset ReturnDate { get; set; }
        public int Fees { get; set; } //Плата
        public Car Cars { get; set; }
        public User Users { get; set; }
        public Rent()
        {

        }
        public Rent (string _Car, string _User, DateTimeOffset _RentTime, DateTimeOffset _ReturnDate, int _fees, string _UserName)
        {
            Car = _Car;
            User = _User;
            RentTime = _RentTime;
            ReturnDate = _ReturnDate;
            Fees = _fees;
            UserName = _UserName;
        }
    }
}
