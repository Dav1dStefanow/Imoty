namespace Imoty.Services.Data.Interfaces
{
    using System.Collections.Generic;

    using Imoty.Web.ViewModels.Home;

    public interface IPropertyService
    {
        SinglePropertyViewModel GetByIdAndCategory(int id, string category);

        IEnumerable<T> GetRandom<T>(int count);

        IEnumerable<T> GetByTagsAndType<T>(IEnumerable<int> tagIds, string serachInput);
    }
}
