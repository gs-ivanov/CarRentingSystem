namespace CarRentingSystem.Controllers
{
    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Models.Cars;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.IO;
    using FileSystem= System.IO.File;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly CarRentingDbContext data;

        public CarsController(CarRentingDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View(new AddCarFormModel { Categories = this.AddCategories() });

        [HttpPost]
        public IActionResult Add(AddCarFormModel car, IFormFile imagef)  //IEnumerable<IFormFile> image
        {
            if (imagef==null|| imagef.Length>2*1024*1024)
            {
                this.ModelState.AddModelError("Imagef", "The Imagef is not valid. It is required and should be less than 2Mb");
            }
            /*// 1 st Variant
                        var imageInMemory = new MemoryStream(); //Otvarqme Memory Stream

                        imagef.CopyTo(imageInMemory);  // Copirame vatre imagef

                        var imageBytes = imageInMemory.ToArray();  // I imame byte masiv
            */
            // 2 nd Variant

            imagef.CopyTo(FileSystem.OpenWrite($"C:/Images/{imagef.FileName}"));

            if (this.data.Categories.Any(c => c.Id == car.CategoryId))
            {
                this.ModelState.AddModelError(nameof(car.CategoryId), "Category does not exists");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = AddCategories();

                return View(car);
            }

            var carData = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.Image,
                Year = car.Year,
                CategoryId = car.CategoryId,
            };

            this.data.Cars.Add(carData);

            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");


            //return View(car);
        }

        private IEnumerable<CarCategoryViewModel> AddCategories()
        {
            var categories = this.data
                .Categories
                .Select(c => new CarCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return categories;
        }
    }
}
