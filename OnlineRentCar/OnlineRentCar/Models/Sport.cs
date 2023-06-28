using System.ComponentModel.DataAnnotations;
namespace OnlineRentCar.Models
{
    public class Sport : Car
    {
        [Required]
        public string MachinebodyTypeSportTb {get; set; } //тип кузова 
        public string EngineCapacitySportCarTb { get; set; } //об'єм двигуна!
        public Sport()
        {
            
        }
        public Sport(string _MachinebodyTypeSportTb, string _EngineCapacitySportCarTb) : base()
        {
            MachinebodyTypeSportTb = _MachinebodyTypeSportTb;
            EngineCapacitySportCarTb = _EngineCapacitySportCarTb;
        }
    }
}
