namespace Imoty.Services.Data.Interfaces
{
    using Imoty.Web.ViewModels.AddAd;
    using System.Threading.Tasks;

    public interface IAddBusinesStoreService
    {
        Task AddBusinesStoreAsync(AddBusinesStoreViewModel viewModel);
    }
}
