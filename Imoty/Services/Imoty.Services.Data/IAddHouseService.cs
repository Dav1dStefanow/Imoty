namespace Imoty.Services.Data
{
    using System.Threading.Tasks;

    using Imoty.Web.ViewModels.AddAd;

    public interface IAddHouseService
    {
        Task AddHouseAsync(AddHouseViewModel viewModel);
    }
}
