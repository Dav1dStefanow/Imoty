namespace Imoty.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Imoty.Web.ViewModels.Administration.Enumerators;

    public class IndexViewModelIntro
    {
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ProfessionType Profession { get; set; }

        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(4)]
        [RegularExpression(
            "[A-Z][a-z]+",
            ErrorMessage = "Name should start with upper case letter.")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Range(2000, 2023)]
        [Display(Name= "Your current year")]
        public int Year { get; set; }
    }
}
