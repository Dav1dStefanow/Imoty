﻿namespace Imoty.Web.ViewModels.AddAd
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddWarehouseViewModel
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

        [Range(1, int.MaxValue, ErrorMessage = "Price has to be a positive value.")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "SquareMeters has to be a positive value.")]
        public int SquareMeters { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Description name can't be more than 1000 digits.")]
        [MinLength(35, ErrorMessage = "Description name has to be at least 35 digits long.")]
        public string Description { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Construction name can't be more than 20 digits.")]
        [MinLength(5, ErrorMessage = "Construction name has to be at least 5 digits long.")]
        [RegularExpression(
           "[A-Z][a-z]+",
           ErrorMessage = "Construction name has to start with upper case letter.")]
        public string Construction { get; set; }
    }
}
