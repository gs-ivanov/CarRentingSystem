namespace CarRentingSystem.Models.API.Cars
{
    using CarRentingSystem.Models.Cars;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class AllCarsApiRequestModel
    {
        public string Brand { get; init; }

        public string SearchTerm { get; init; }

        public CarSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public  int CarsPerPage { get; set; } = 10;

        public int TotalCars { get; init; }

    }
}
