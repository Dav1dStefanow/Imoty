namespace Imoty.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using Imoty.Web.ViewModels.AddAd;

    public interface IAddFieldService
    {
        Task AddFieldAsync(AddFieldViewModel viewModel);
    }
}
