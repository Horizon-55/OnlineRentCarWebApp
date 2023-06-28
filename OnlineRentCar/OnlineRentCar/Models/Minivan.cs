using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRentCar.Models
{
    public class Minivan : Car
    {
        [Required]
        public string MachinebodytypeMinivan { get; set; } //тип кузова мініван має бути встановлення значення!
        public int NumberofpassagercarsForMinivan{ get; set; } //кількість пасажирів
        public Minivan()
        {
            
        }
        public Minivan(string _MachinebodytypeMinivan, int _NumberofpassagercarsForMinivan) : base()
        {
            MachinebodytypeMinivan = _MachinebodytypeMinivan;
            NumberofpassagercarsForMinivan = _NumberofpassagercarsForMinivan;
        }
    }
}
