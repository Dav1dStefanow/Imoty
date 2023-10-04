namespace Imoty.Web.ViewModels.AddAd
{
    using System.ComponentModel.DataAnnotations;

    public class AddFieldViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage ="Type can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "Type has to be at least 4 digits long.")]
        [RegularExpression(
           "[A-Za-z-\\s]+",
           ErrorMessage = "Type has to start with upper case letter.")]
        public string Type { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Town name can't be more than 50 digits.")]
        [MinLength(4, ErrorMessage = "Town name must be at least 4 digits long.")]
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

        [Range(1, int.MaxValue, ErrorMessage = "Price has to have positive value.")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "SquareMeters has to have positive value.")]
        public int SquareMeters { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Description name can't be more than 1000 digits.")]
        [MinLength(35, ErrorMessage = "Description name has to be at least 35 digits long.")]
        public string Description { get; set; }
    }
}
