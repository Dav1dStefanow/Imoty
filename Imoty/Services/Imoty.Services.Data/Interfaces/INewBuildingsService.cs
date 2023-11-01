namespace Imoty.Services.Data.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;
    using Imoty.Web.ViewModels.Home;

    public interface INewBuildingsService
    {
        IEnumerable<PropertyForSaleRentInListViewModel> GetAllNewBuildings(int page, int itemsNumber = 15);

        int GetCount();
    }
}
