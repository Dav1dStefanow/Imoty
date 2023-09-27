namespace Imoty.Services.Data
{
    using Imoty.Web.ViewModels.AddAd;
    using System.Threading.Tasks;

    public interface IAddBusinesStoreService
    {
        Task AddBusinesStoreAsync(AddBusinesStoreViewModel viewModel);
    }
}
