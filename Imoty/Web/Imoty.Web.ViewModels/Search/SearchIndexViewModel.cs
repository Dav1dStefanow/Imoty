namespace Imoty.Web.ViewModels.Search
{
    using System.Collections.Generic;

    public class SearchIndexViewModel
    {
        public SearchIndexViewModel()
        {
            this.Tags = new List<SearchTagsViewModel>();
        }

        public IEnumerable<SearchTagsViewModel> Tags { get; set; }
    }
}
