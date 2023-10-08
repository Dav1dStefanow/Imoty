namespace Imoty.Web.ViewModels.AddAd
{
    using System.ComponentModel.DataAnnotations;

    public class TagInputModel
    {
        [Required]
        [RegularExpression(
          "[A-Za-z-\\s]+",
          ErrorMessage = "Tag name has to start with upper case letter.")]
        public string TagName { get; set; }
    }
}
