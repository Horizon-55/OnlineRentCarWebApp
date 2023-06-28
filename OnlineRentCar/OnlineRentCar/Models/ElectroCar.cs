using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRentCar.Models
{
    public class ElectroCar : Car
    {
        [Required]
        public string MachinebodytypeElectro { get; set; }
        public string TypeFuelElectro { get; set; } //тип топлива!
        public ElectroCar() {  }
        public ElectroCar(string _MachinebodytypeElectro, string _TypeFuelElectro) : base()
        {
            MachinebodytypeElectro = _MachinebodytypeElectro;
            TypeFuelElectro = _TypeFuelElectro;
        }
    }
}
