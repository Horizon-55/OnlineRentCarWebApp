using System.ComponentModel.DataAnnotations;

namespace OnlineRentCar.Models
{
    public class Car
    {
        [Key]
        [Required(ErrorMessage = "Ліцензійний номер обов'язковий для введення!")]
        public string LNumberTb { get; set; }
         [Required(ErrorMessage = "Бренд поле обов'язкове для введення!")]
        public string BrandTb { get; set; }
        [Required(ErrorMessage = "Модель поле обов'язкове для введення!")]
        public string ModelTb { get; set; }
        [Required(ErrorMessage = "Колір поле обов'язкове для введення!")]
        public string ColorTb { get; set; }
        [Required(ErrorMessage = "Тип коробки передач поле обов'язкове для введення!")]
        public string TypeGearBoxTb { get; set; }
        [Required(ErrorMessage = "Тип топлива поле обов'язкове для вибірки!")]
        public string TypeOfFuelTb { get; set; }
        [Required(ErrorMessage = "Ціна поле обов'язкове для введення!")]
        public int PriceTb { get; set; }
        [Required(ErrorMessage = "Об'єм двигуна обов'язкове для введення")]
        public string EngineCapalityTb { get; set;}
        [Required(ErrorMessage = "Тип машини обов'язкове для вибірки!")]
        public string MachinebodyTypeTb { get; set; }
        [Required(ErrorMessage = "Тип привида обов'язкове для вибірки")]
        public string GhostTypeTb { get; set; }
        [Required(ErrorMessage = "Кількість пасажирів обов'язкове для введення!")]
        public int NumberOfPassagerCarsTb { get; set; }
        [Required(ErrorMessage = "Статус обов'язкове для вибірки")]
        public string StatusTb { get; set; }
        public Rent Rent;
        public Returns Returns;

        public Car()
        {
            
        }
        public Car(string _LNumberTb, string _BrandTb, string _ModelTb, string _ColorTb, string _TypeGearBoxTb, string _TypeOffFuelTb, int _PriceTb, string _StatusTb, string _GhostType, string _Machinebodytype)
        {
            LNumberTb = _LNumberTb;
            BrandTb = _BrandTb;
            ModelTb = _ModelTb;
            ColorTb = _ColorTb;
            TypeGearBoxTb = _TypeGearBoxTb;
            PriceTb = _PriceTb;
            TypeOfFuelTb = _TypeOffFuelTb;
            MachinebodyTypeTb = _Machinebodytype;
            GhostTypeTb = _GhostType;
            StatusTb = _StatusTb;
        }
    }
}
