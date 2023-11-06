namespace Imoty.Web.ViewModels.Search
{
    using System.Collections.Generic;

    public class SearchListInputModel
    {
        public IEnumerable<int> Tags { get; set; }

        //public IEnumerable<int> Towns { get; set; }

        //public IEnumerable<int> Districts { get; set; }

        public string SearchInput { get; set; }
    }
}
