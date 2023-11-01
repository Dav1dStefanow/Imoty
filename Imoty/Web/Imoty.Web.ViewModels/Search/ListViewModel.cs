namespace Imoty.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using Imoty.Web.ViewModels.Home;

    public class ListViewModel
    {
        public ListViewModel()
        {
            this.Properties = new List<PropertyForSaleRentInListViewModel>();
        }

        public IEnumerable<PropertyForSaleRentInListViewModel> Properties { get; set; }
    }
}
