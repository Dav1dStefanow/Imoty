namespace Imoty.Services.Data.Interfaces
{
    using Imoty.Web.ViewModels.Home;

    public interface IPropertyService
    {
        SinglePropertyViewModel GetByIdAndCategory(int id, string category);
    }
}
