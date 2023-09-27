﻿namespace Imoty.Web.ViewModels.AddAd
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddBusinesStoreViewModel
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
        [MinLength(4, ErrorMessage = "City/Village name has to be at least 4 digits long.")]
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

        [Range(1, int.MaxValue, ErrorMessage = "Price has to be positive a value.")]
        public decimal Price { get; set; }

        [Range(1, 100, ErrorMessage = "Rooms has to have positive value.")]
        public int Rooms { get; set; }

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
        public string Construction { get; set; }
    }
}