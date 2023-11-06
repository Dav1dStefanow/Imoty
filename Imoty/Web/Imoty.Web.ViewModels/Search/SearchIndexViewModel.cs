namespace Imoty.Web.ViewModels.Search
{
    using System.Collections.Generic;

    public class SearchIndexViewModel
    {
        public SearchIndexViewModel()
        {
            this.Tags = new List<SearchTagsViewModel>();
            this.Towns = new List<SearchTownsViewModel>();
            this.Districts = new List<SearchDistrictsViewModel>();
        }

        public IEnumerable<SearchTagsViewModel> Tags { get; set; }

        public IEnumerable<SearchTownsViewModel> Towns { get; set; }

        public IEnumerable<SearchDistrictsViewModel> Districts { get; set; }
    }
}
