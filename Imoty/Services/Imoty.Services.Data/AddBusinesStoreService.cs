namespace Imoty.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Web.ViewModels.AddAd;

    public class AddBusinesStoreService : IAddBusinesStoreService
    {
        private readonly IDeletableEntityRepository<Construction> constructionsRepository;
        private readonly IDeletableEntityRepository<BusinesStore> businesStoresRepository;
        private readonly IRepository<BusinesStoreImage> businesStoreImagesRepository;

        public AddBusinesStoreService(
            IDeletableEntityRepository<Construction> constructionsRepository,
            IDeletableEntityRepository<BusinesStore> businesStoresRepository,
            IRepository<BusinesStoreImage> businesStoreImagesRepository)
        {
            this.constructionsRepository = constructionsRepository;
            this.businesStoresRepository = businesStoresRepository;
            this.businesStoreImagesRepository = businesStoreImagesRepository;
        }

        public async Task AddBusinesStoreAsync(AddBusinesStoreViewModel viewModel)
        {
            if (!this.constructionsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Construction))
            {
                await this.constructionsRepository.AddAsync(new Construction { Name = viewModel.Construction });
            }

            await this.constructionsRepository.SaveChangesAsync();

            Construction construction = this.constructionsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Construction);

            var input = new BusinesStore
            {
                Name = viewModel.Name,
                PopulatedArea = viewModel.PopulatedArea,
                Location = viewModel.Location,
                Rooms = viewModel.Rooms,
                FrontSpace = viewModel.FrontSpace,
                ConstructionId = construction.Id,
                Price = viewModel.Price,
                Description = viewModel.Description,
                SquareMeters = viewModel.SquareMeters,
            };

            await this.businesStoresRepository.AddAsync(input);
            await this.businesStoresRepository.SaveChangesAsync();
        }
    }
}
