namespace Imoty.Web.ViewModels.Home
{
    using System;

    public class PagingViewModel
    {
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
