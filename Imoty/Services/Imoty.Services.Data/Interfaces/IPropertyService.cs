namespace Imoty.Services.Data.Interfaces
{
    using System.Collections.Generic;

    using Imoty.Web.ViewModels.Home;

    public interface IPropertyService
    {
        SinglePropertyViewModel GetByIdAndCategory(int id, string category);

        IEnumerable<PropertyForSaleRentInListViewModel> GetRandom(int count);

        IEnumerable<PropertyForSaleRentInListViewModel> GetByTags(IEnumerable<int> tagIds);
    }
}
