namespace Imoty.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using Imoty.Web.ViewModels.AddAd;

    public interface IAddWarehouseService
    {
        Task AddWarehouseAsync(AddWarehouseViewModel viewModel, string userId, string imagePath);
    }
}
