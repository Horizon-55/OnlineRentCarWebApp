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
        [ForeignKey("Car")]
        public string Car { get; set; }
        [ForeignKey("User")]
        public string User { get; set; }
        public DateTimeOffset Date {get; set; } 
        public int Delay { get; set; }
        public int Fine { get; set; } //Комісія яка була
        public Car Cars { get; set; }
        public User Users { get; set; }
    }
}
