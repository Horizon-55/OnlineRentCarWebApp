using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineRentCar.Models
{
    public class Crossover : Car
    {
        [Required]
        public string MachinebodyTypeCrossoverTb {get; set; } //тип кузова для встановлення значення!
        public string GhostTypeCrossoverTb { get; set; } ///тип привида!
        public Crossover() {  }
        public Crossover(string _MachinebodyTypeCrossoverTb, string _GhostTypeTb) : base()
        {
            MachinebodyTypeCrossoverTb = _MachinebodyTypeCrossoverTb;
            GhostTypeTb = _GhostTypeTb;
        }
    }
}
