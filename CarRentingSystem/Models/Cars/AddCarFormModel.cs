using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Models.Cars
{
    public class AddCarFormModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        [Display(Name = "Image URL")]
        public string Image { get; set; }

        public int Year { get; set; }

        public string Category { get; set; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; }
    }
}
