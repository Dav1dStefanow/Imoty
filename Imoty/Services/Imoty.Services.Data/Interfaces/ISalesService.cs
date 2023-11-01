namespace Imoty.Services.Data.Interfaces
{
    using System.Collections.Generic;

    using Imoty.Web.ViewModels.Home;

    public interface ISalesService
    {
        IEnumerable<PropertyForSaleRentInListViewModel> GetAllSales(int page, int itemsNumber = 15);

        int GetCount();
    }
}
