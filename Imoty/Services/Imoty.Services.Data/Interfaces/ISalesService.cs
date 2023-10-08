namespace Imoty.Services.Data.Interfaces
{
    using System.Collections.Generic;

    using Imoty.Web.ViewModels.Home;

    public interface ISalesService
    {
        IEnumerable<PropertyForSaleViewModel> GetAllSales(int page, int itemsNumber = 15);
    }
}
