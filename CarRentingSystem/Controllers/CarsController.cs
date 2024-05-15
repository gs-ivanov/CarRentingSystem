namespace CarRentingSystem.Controllers
{
    using CarRentingSystem.Data;
    using CarRentingSystem.Models.Cars;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly CarRentingDbContext data;

        public CarsController(CarRentingDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            var v = new AddCarFormModel { Categories = AddCategories() };

           return View(v);
        }
        [HttpPost]
        public IActionResult Add(AddCarFormModel car) 
        {
            car.Categories = AddCategories();

            return View(car);
        }

        private IEnumerable<CarCategoryViewModel> AddCategories()
        {
            var categories = this.data
                .Categories
                .Select(c => new CarCategoryViewModel
                {
                    Id=c.Id,
                    Name=c.Name
                })
                .ToList();

            return categories;
        }
    }
}
