using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRentCar.Models
{
    public class Returns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RentId { get; set; }
        [Required]
        [ForeignKey("LNumberCar")]
        public string Car { get; set; }
        [ForeignKey("UserId")]
        public string User { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset Date {get; set; } 
        public int Delay { get; set; }
        public int Fine { get; set; } //Комісія яка була
        public Car Cars { get; set; }
        public User Users { get; set; }
        public Returns()
        {
            
        }
        public Returns(string _Car, string _User, string _UserName, DateTimeOffset _Date, int _Delay, int _Fine)
        {
            Car = _Car;
            User = _User;
            UserName = _UserName;
            Date = _Date;
            Delay = _Delay;
            Fine = _Fine;
        }
    }
}
