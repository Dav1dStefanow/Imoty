namespace Imoty.Web.ViewModels.Home
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SalesRentsOrNBListViewModel : PagingViewModel
    {
        public IEnumerable<PropertyForSaleRentInListViewModel> PropertiesForSale { get; set; }
    }
}
