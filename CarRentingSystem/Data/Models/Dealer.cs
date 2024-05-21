namespace CarRentingSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}
