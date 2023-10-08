namespace Imoty.Web.ViewModels.Home
{
    using System.Collections;
    using System.Collections.Generic;

    public class SalesInListViewModel
    {
        public IEnumerable<PropertyForSaleViewModel> PropertiesForSale { get; set; }

        public int PageNumber { get; set; }
    }
}
