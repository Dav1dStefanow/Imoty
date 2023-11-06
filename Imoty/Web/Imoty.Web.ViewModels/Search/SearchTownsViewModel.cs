namespace Imoty.Web.ViewModels.Search
{
    using Imoty.Data.Models;
    using Imoty.Services.Mapping;

    public class SearchTownsViewModel : IMapFrom<Town>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}