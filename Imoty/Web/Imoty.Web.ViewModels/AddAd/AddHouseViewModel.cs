﻿namespace Imoty.Web.ViewModels.AddAd
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddHouseViewModel : IValidatableObject
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "Name has to be at least 4 digits long.")]
        [RegularExpression(
          "[A-Z][a-z]+",
          ErrorMessage = "Name has to start with upper case letter.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "City/Village name can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "City/Village name must be at least 4 digits long.")]
        [RegularExpression(
           "[A-Z][a-z]+",
           ErrorMessage = "City/Village name should start with upper case letter.")]
        public string PopulatedArea { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Location name can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "Location name has to be at least 4 digits long.")]
        [RegularExpression(
           "[A-Z][a-z]+",
           ErrorMessage = "Location name has to start with upper case letter.")]
        public string Location { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price has to have positive value.")]
        public decimal Price { get; set; }

        [Range(1, 20, ErrorMessage = "BedRooms has to have positive value.")]
        public int BedRooms { get; set; }

        [Range(1, 20, ErrorMessage = "BathRooms has to have positive value.")]
        public int BathRooms { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Square meters has to have positive value.")]
        public int SquareMeters { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Built up area has to have positive value.")]
        public int BuiltUpArea { get; set; }

        [Required]
        [MinLength(30)]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Range(0, 10, ErrorMessage = "Garages has to have positive value.")]
        public int Garages { get; set; }

        [Range(1, 10, ErrorMessage = "Total floors has to have positive value.")]
        public int TotalFloors { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Construction name can't be more than 20 digits.")]
        [MinLength(5, ErrorMessage = "Construction name has to be at least 5 digits long.")]
        [RegularExpression(
           "[A-Z][a-z]+",
           ErrorMessage = "Construction name has to start with upper case letter.")]
        public string Construction { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if (this.BuiltUpArea > this.SquareMeters)
            {
                yield return new ValidationResult("Square meters of the property has to have some back yard space.");
            }
        }
    }
}