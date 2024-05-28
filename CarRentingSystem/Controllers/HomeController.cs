namespace CarRentingSystem.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using CarRentingSystem.Data;
    using CarRentingSystem.Models;
    using CarRentingSystem.Services.Statistics;
    using CarRentingSystem.Models.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;

        private readonly CarRentingDbContext data;

        public HomeController(
            IStatisticsService statistics,
            CarRentingDbContext data)
        {
            this.statistics = statistics;
            this.data = data;
        }

        public IActionResult Index()
        {
            var cars = this.data
                .Cars
                .OrderByDescending(c => c.Id)
                .Select(c => new CarIndexViewModel
                {
                    Brand = c.Brand,
                    Model = c.Model,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Year = c.Year,
                })
                .Take(3)
                .ToList();

            var totalStatistics = this.statistics.Total();
            var indexCars = new IndexViewModel
            {
                TotalCars = totalStatistics.TotalCars,
                TotalUsers = totalStatistics.TotalUsers,
                Cars = cars
            };
            return View(indexCars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
