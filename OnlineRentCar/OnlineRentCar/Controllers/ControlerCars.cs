using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineRentCar.Data;
using OnlineRentCar.Models;
using System.Drawing;

namespace OnlineRentCar.Controllers
{
    public class ControlerCars : Controller
    {
        private readonly ApplicationDbContext _Database;
        public ControlerCars(ApplicationDbContext Database)
        {
            _Database = Database;
        }
        //Get
        public IActionResult Cars()
        {
            IEnumerable<Car> objCarList = _Database.cars;
            ViewData["FromDbObj"] = objCarList;
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cars(string LNumberTb, string BrandTb, string ModelTb, int PriceTb, string ColorTb, string TypeGearBoxTb,
            string TypeOfFuelTb, string EngineCapalityTb, string StatusTb, string GhostTypeTb, int NumberOfPassager, string MachinebodyTypeTb)
        {
            IEnumerable<Car> objCarList = _Database.cars;
            ViewData["FromDbObj"] = objCarList;


            if (ModelState.IsValid)
            {
                if (MachinebodyTypeTb == "Седан")
                {
                    Car objCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                        MachinebodyTypeTb = MachinebodyTypeTb,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,
                    };
                    _Database.cars.Add(objCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Універсал")
                {

                    Car objCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                        MachinebodyTypeTb = MachinebodyTypeTb,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,
                    };
                    _Database.cars.Add(objCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Кросовер")
                {
                    Crossover CrossoverCar = new() {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                        MachinebodyTypeTb = MachinebodyTypeTb, //для entity Framework запису до типу машини з рядка бо була помилка!
                        MachinebodyTypeCrossoverTb = MachinebodyTypeTb,
                        GhostTypeTb = GhostTypeTb, //для entity Framework запису до типу приводу з рядка бо була помилка!
                        GhostTypeCrossoverTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,
                    };
                    _Database.cars.Add(CrossoverCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Електро")
                {
                    ElectroCar electroCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        TypeOfFuelTb = TypeOfFuelTb,   //для entity Framework запису до типу топлива з рядка бо була помилка!
                        TypeFuelElectro = TypeOfFuelTb,
                        MachinebodyTypeTb = MachinebodyTypeTb, //для entity Framework запису до типу машини з рядка бо була помилка!
                        MachinebodytypeElectro = MachinebodyTypeTb,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,
                    };
                    _Database.cars.Add(electroCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Мініван" && NumberOfPassager == 7)
                {

                    Minivan minivanCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        MachinebodyTypeTb = MachinebodyTypeTb, //для entity Framework запису до типу автомобіля з рядка бо була помилка!
                        MachinebodytypeMinivan = MachinebodyTypeTb,
                        NumberOfPassagerCarsTb = NumberOfPassager, //для entity Framework запису до кількість пасажирів з рядка бо була помилка!
                        NumberofpassagercarsForMinivan = NumberOfPassager,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                    };
                    _Database.cars.Add(minivanCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Спорт")
                {

                    Sport SportCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        MachinebodyTypeTb = MachinebodyTypeTb, //для entity Framework запису до типу автомобіля з рядка бо була помилка!
                        MachinebodyTypeSportTb = MachinebodyTypeTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb, //для entity Framework запису до об'єму двигуна з рядка бо була помилка!
                        EngineCapacitySportCarTb = EngineCapalityTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                    };
                    _Database.cars.Add(SportCar);
                    _Database.SaveChanges();
                }
                ModelState.Clear(); //очистка полів
            }
            return View();
        }
        //сторінка редагування razor page 
        //Get дані з бази даних
        public IActionResult CarsEdit(string? LNumberTb)
        {
            if (LNumberTb == null || LNumberTb == "")
            {
                return NotFound();
            }
            var CarsFromDb = _Database.cars.Find(LNumberTb); //находить елемент по конкретному ліцензійному номеру
            //var CarsFromDbFirst = _Database.cars.FirstOrDefault(u => u.LNumberTb == LNumberTb); //находить 1 елемент по ліцензійному номеру!
            //var CarsFromDbSingle = _Database.cars.SingleOrDefault(u => u.LNumberTb == LNumberTb); //находить 1 елемент по ліцензійному номеру!
            if (CarsFromDb == null)
                return NotFound();

            return View(CarsFromDb);
        }

        ////Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarsEdit(string LNumberTb, string BrandTb, string ModelTb, int PriceTb, string ColorTb, string TypeGearBoxTb,
            string TypeOfFuelTb, string EngineCapalityTb, string StatusTb, string GhostTypeTb, int NumberOfPassager, string MachinebodyTypeTb)
        {
            if (ModelState.IsValid)
            {
                if (MachinebodyTypeTb == "Седан")
                {
                    Car objCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                        MachinebodyTypeTb = MachinebodyTypeTb,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,
                    };
                    _Database.cars.Update(objCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Універсал")
                {

                    Car objCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                        MachinebodyTypeTb = MachinebodyTypeTb,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,
                    };
                    _Database.cars.Update(objCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Кросовер")
                {
                    Crossover CrossoverCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                        MachinebodyTypeTb = MachinebodyTypeTb, //для entity Framework запису до типу машини з рядка бо була помилка!
                        MachinebodyTypeCrossoverTb = MachinebodyTypeTb,
                        GhostTypeTb = GhostTypeTb, //для entity Framework запису до типу приводу з рядка бо була помилка!
                        GhostTypeCrossoverTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,

                    };
                    _Database.cars.Update(CrossoverCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Електро")
                {
                    ElectroCar electroCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        TypeOfFuelTb = TypeOfFuelTb,   //для entity Framework запису до типу топлива з рядка бо була помилка!
                        TypeFuelElectro = TypeOfFuelTb,
                        MachinebodyTypeTb = MachinebodyTypeTb, //для entity Framework запису до типу машини з рядка бо була помилка!
                        MachinebodytypeElectro = MachinebodyTypeTb,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,
                    };
                    _Database.cars.Update(electroCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Мініван" && NumberOfPassager == 7)
                {

                    Minivan minivanCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        MachinebodyTypeTb = MachinebodyTypeTb, //для entity Framework запису до типу автомобіля з рядка бо була помилка!
                        MachinebodytypeMinivan = MachinebodyTypeTb,
                        NumberOfPassagerCarsTb = NumberOfPassager, //для entity Framework запису до кількість пасажирів з рядка бо була помилка!
                        NumberofpassagercarsForMinivan = NumberOfPassager,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                    };
                    _Database.cars.Update(minivanCar);
                    _Database.SaveChanges();
                }

                if (MachinebodyTypeTb == "Спорт")
                {

                    Sport SportCar = new()
                    {
                        LNumberTb = LNumberTb,
                        BrandTb = BrandTb,
                        ModelTb = ModelTb,
                        PriceTb = PriceTb,
                        ColorTb = ColorTb,
                        TypeGearBoxTb = TypeGearBoxTb,
                        StatusTb = StatusTb,
                        MachinebodyTypeTb = MachinebodyTypeTb, //для entity Framework запису до типу автомобіля з рядка бо була помилка!
                        MachinebodyTypeSportTb = MachinebodyTypeTb,
                        NumberOfPassagerCarsTb = NumberOfPassager,
                        GhostTypeTb = GhostTypeTb,
                        EngineCapalityTb = EngineCapalityTb, //для entity Framework запису до об'єму двигуна з рядка бо була помилка!
                        EngineCapacitySportCarTb = EngineCapalityTb,
                        TypeOfFuelTb = TypeOfFuelTb,
                    };
                    _Database.cars.Update(SportCar);
                    _Database.SaveChanges();
                }
            }
            return RedirectToAction("Cars");

        }

        public IActionResult CarsDelete(string? LNumberTb)
        {
            if (LNumberTb == null || LNumberTb == "")
            {
                return NotFound();
            }
            var CarsFromDb = _Database.cars.Find(LNumberTb);
            if (CarsFromDb == null)
            {
                return NotFound();
            }
            return View(CarsFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePostCars(string? LNumberTb)
        {
            var obj = _Database.cars.Find(LNumberTb);
            if (obj == null)
            {
                return NotFound();
            }
            //видалення об'єкта з бази даних!
            _Database.cars.Remove(obj);
            _Database.SaveChanges();
            return RedirectToAction("Cars");
        }
    }
}
