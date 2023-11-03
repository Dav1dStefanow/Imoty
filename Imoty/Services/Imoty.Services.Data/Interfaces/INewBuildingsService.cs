namespace Imoty.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface INewBuildingsService
    {
        IEnumerable<T> GetAllNewBuildings<T>(int page, int itemsNumber = 15);

        int GetCount<T>();
    }
}
