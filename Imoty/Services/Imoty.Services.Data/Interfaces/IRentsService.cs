namespace Imoty.Services.Data.Interfaces
{
    using System.Collections.Generic;

    using Imoty.Web.ViewModels.Home;

    public interface IRentsService
    {
        IEnumerable<T> GetAllRents<T>(int page, int itemsNumber = 15);

        int GetCount<T>();
    }
}
