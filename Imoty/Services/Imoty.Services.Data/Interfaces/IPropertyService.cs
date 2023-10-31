namespace Imoty.Services.Data.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;

    using Imoty.Web.ViewModels.Home;

    public interface IPropertyService
    {
        SinglePropertyViewModel GetByIdAndCategory(int id, string category);

        IEnumerable<PropertyForSaleRentViewModel> GetRandom(int count);
    }
}
