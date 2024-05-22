namespace CarRentingSystem.Controllers.API
{
    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Linq;

    [ApiController]
    [Route("/api/cars")]
    public class CarsApiController : ControllerBase
    {
        private readonly CarRentingDbContext data;

        public CarsApiController(CarRentingDbContext data)
        => this.data = data;

        [HttpGet]
        public ActionResult<IEnumerable> GetCar()
        {
            var cars=this.data.Cars.ToList();

            if (!cars.Any())
            {
                return NotFound();
            }

            return Ok(cars);
        }

        //[HttpGet]
        //[Route("{id}")]

        //public object GetDetails(int id)
        //{
        //    return id * 5 * 1000;
        //}

        [HttpGet]
        [Route("{id}")]

        public IActionResult GetDetails(int id)
        {
            var car = this.data.Cars.Find(id);

            if (car==null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        //[Authorize]
        [HttpPost]
        public IActionResult SaveCar(Car car)
        {
            //var carData = new Car
            //{
            //    Brand=car.Brand,
            //    Model=car.Model
            //};

            return Ok("Good!!!");
        }

        //[Route("/details")] // /api/cars/datails
        //[Route("/api/cars/details")] // /api/cars/datails
        //public IActionResult Post2(Car car)
        //{
        //    return View();
        //}
    }
}
