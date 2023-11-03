namespace Imoty.Services.Data.Interfaces
{
    using System.Collections.Generic;

    using Imoty.Web.ViewModels.Home;

    public interface ISalesService
    {
        IEnumerable<T> GetAllSales<T>(int page, int itemsNumber = 15);

        int GetCount<T>();
    }
}
