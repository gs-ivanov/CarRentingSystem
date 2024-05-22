namespace CarRentingSystem.Models.API.Cars
{
    public class CarResponseModel
    {
        public int Id { get; init; }

        public string Brand { get; init; }

        public string Model { get; init; }

        public int CategoryId { get; init; }

        public string ImageUrl { get; init; }

        public int Year { get; init; }

        public string Category { get; init; }

    }
}
