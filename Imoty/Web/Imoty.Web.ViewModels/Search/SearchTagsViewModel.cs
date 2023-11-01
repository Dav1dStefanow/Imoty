namespace Imoty.Web.ViewModels.Search
{
    using Imoty.Data.Models;
    using Imoty.Services.Mapping;

    public class SearchTagsViewModel : IMapFrom<Tag>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}