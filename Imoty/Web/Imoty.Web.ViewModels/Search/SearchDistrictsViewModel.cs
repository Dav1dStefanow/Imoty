namespace Imoty.Web.ViewModels.Search
{
    using Imoty.Data.Models;
    using Imoty.Services.Mapping;

    public class SearchDistrictsViewModel : IMapFrom<District>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}