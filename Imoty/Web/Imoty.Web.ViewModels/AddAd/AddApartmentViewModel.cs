namespace Imoty.Web.ViewModels.AddAd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    public class AddApartmentViewModel : IValidatableObject
    {
        [Required]
        [MaxLength(50, ErrorMessage = "City/Village name can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "City/Village name must be at least 4 digits long.")]
        [RegularExpression(
           "[A-Z][a-z]+",
           ErrorMessage = "City/Village name has to start with upper case letter.")]
        public string PopulatedArea { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Location name can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "Location name has to be be at least 4 digits long.")]
        [RegularExpression(
         "[A-Z][a-z]+",
         ErrorMessage = "Locaion has to start with upper case letter.")]
        public string Location { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price has to have positive value.")]
        public decimal Price { get; set; }

        [Range(1, 10, ErrorMessage = "BedRooms has to have positive value.")]
        public int BedRooms { get; set; }

        [Range(1, 10, ErrorMessage = "BathRooms has to have positive value.")]
        public int BathRooms { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "SquareMeters has to have positive value.")]
        public int SquareMeters { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Description can't be more than 1000 digits.")]
        [MinLength(35, ErrorMessage = "Description has to be at least 35 digits long.")]
        public string Description { get; set; }

        [Range(1, 100, ErrorMessage = "TotalFloors has to have positive value.")]
        public int TotalFloors { get; set; }

        [Range(1, 10, ErrorMessage = "Garages has to have positive value.")]
        public int Garages { get; set; }

        [Range(1, 100, ErrorMessage = "Floor has to have positive value.")]
        public int Floor { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Construction name can't be more than 20 digits.")]
        [MinLength(5, ErrorMessage = "Construction name has to be at least 5 digits long.")]
        [RegularExpression(
         "[A-Z][a-z]+",
         ErrorMessage = "Construction name has to start with upper case letter.")]
        public string Construction { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.TotalFloors < this.Floor)
            {
                yield return new ValidationResult("Total floors can't be less than the floor yuor apartment is.");
            }

            if (this.BathRooms > this.BedRooms)
            {
                yield return new ValidationResult("There are no apartments with more bathrooms than bedrooms.");
            }
        }
    }
}
