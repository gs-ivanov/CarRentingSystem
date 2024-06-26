﻿namespace CarRentingSystem.Models.Api.Cars
{
    using CarRentingSystem.Services.Cars;
    using System.Collections.Generic;

    public class AllCarsApiResponseModel
    {
        public int CurrentPage { get; init; }

        public int CarsPerPage { get; init; }

        public int TotalCars { get; init; }

        public IEnumerable<CarServiceModel> Cars { get; set; }

    }
}
