namespace CarRentingSystem.Controllers.API
{
    using CarRentingSystem.Data;
    using CarRentingSystem.Models.API.Statistics;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly CarRentingDbContext data;

        public StatisticsApiController(CarRentingDbContext data)
        => this.data = data;

        [HttpGet]
        public StatisticsResponseModel GetStatistics()
        {
            var totalCars = this.data.Cars.Count();
            var totalUsers = this.data.Users.Count();


            return new StatisticsResponseModel
            {
                TotalCars= totalCars,
                TotalUsers= totalUsers,
                TotalRents =0
            };
        }
    }
}
