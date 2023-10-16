namespace Imoty.Web.ViewModels.AddAd
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class AddBusinesStoreViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Type can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "Type has to be at least 4 digits long.")]
        [RegularExpression(
           "[A-Za-z-\\s]+",
           ErrorMessage = "Type has to start with upper case letter.")]
        public string Type { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Town name can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "Town name has to be at least 4 digits long.")]
        [RegularExpression(
           "[A-Za-z-\\s]+",
           ErrorMessage = "Town name should start with upper case letter.")]
        public string Town { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "District name can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "District name has to be at least 4 digits long.")]
        [RegularExpression(
           "[A-Za-z-\\s]+",
           ErrorMessage = "District name has to start with upper case letter.")]
        public string District { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price has to be positive a value.")]
        public decimal Price { get; set; }

        [Range(1, 100, ErrorMessage = "BathRooms has to have positive value.")]
        public int BathRooms { get; set; }

        [Range(1, 100, ErrorMessage = "Square meters has to have positive value.")]
        public int SquareMeters { get; set; }

        [Range(1, 100, ErrorMessage = "FrontSpace has to have positive value.")]
        public int FrontSpace { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Description name can't be more than 1000 digits.")]
        [MinLength(100, ErrorMessage = "Description name has to be at least 100 digits long.")]
        public string Description { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Construction name can't be more than 20 digits.")]
        [MinLength(5, ErrorMessage = "Construction name has to be at least 5 digits long.")]
        [RegularExpression(
           "[A-Z][a-z]+",
           ErrorMessage = "Construction has to start with upper case letter.")]

        public IEnumerable<IFormFile> Images { get; set; }

        public string Construction { get; set; }

        public IEnumerable<TagInputModel> Tags { get; set; }
    }
}
