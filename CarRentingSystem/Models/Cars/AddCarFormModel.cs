namespace CarRentingSystem.Models.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static CarRentingSystem.Data.DataConstantse;
    public class AddCarFormModel
    {
        [Required]
        [StringLength(CarBrandMaxLength, MinimumLength = CarBrandMinLength)]
        public string Brand { get; set; }

        [Required]
        [StringLength(CarModelMaxLength,MinimumLength = CarModelMinLength)]
        public string Model { get; set; }

        [Required]
        [StringLength(int.MaxValue,
            MinimumLength = CarDescriptionMinLength,
            ErrorMessage ="The field {0} must be with min length of {2}" )]
        public string Description { get; set; }

        [Url]
        [Display(Name = "Image URL")]
        public string Image { get; set; }

        [Range(CarYearMinValue, CarYearMaxValue)]
        public int Year { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; }
    
    }
}
