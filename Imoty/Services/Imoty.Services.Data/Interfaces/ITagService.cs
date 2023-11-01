namespace Imoty.Services.Data.Interfaces
{
    using System.Collections.Generic;

    using Imoty.Web.ViewModels.Search;

    public interface ITagService
    {
        IEnumerable<T> GetAllTags<T>();
    }
}
