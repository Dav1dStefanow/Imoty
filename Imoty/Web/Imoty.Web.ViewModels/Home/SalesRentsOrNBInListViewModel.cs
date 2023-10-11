namespace Imoty.Web.ViewModels.Home
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SalesRentsOrNBInListViewModel
    {
        public IEnumerable<PropertyForSaleRentViewModel> PropertiesForSale { get; set; }

        public int PageNumber { get; set; }

        public int PropertiesCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PreviousPageNum => this.PageNumber - 1;

        public int NextPageNum => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.PropertiesCount / this.ItemsPerPage);

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;
    }
}
