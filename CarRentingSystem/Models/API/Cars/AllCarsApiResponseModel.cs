namespace CarRentingSystem.Models.API.Cars
{
    using System.Collections.Generic;

    public class AllCarsApiResponseModel
    {
        public int CurrentPage { get; init; }

        public int TotalCars { get; set; }

        public IEnumerable<CarResponseModel> Cars { get; set; }

    }
}
