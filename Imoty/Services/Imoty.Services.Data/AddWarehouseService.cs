namespace Imoty.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Web.ViewModels.AddAd;

    public class AddWarehouseService : IAddWarehouseService
    {
        private readonly IDeletableEntityRepository<Construction> constructionsRepository;
        private readonly IDeletableEntityRepository<Warehouse> warehousesRepository;
        private readonly IRepository<WarehouseImage> warehouseImagesRepository;

        public AddWarehouseService(
            IDeletableEntityRepository<Construction> constructionsRepository,
            IDeletableEntityRepository<Warehouse> warehousesRepository,
            IRepository<WarehouseImage> warehouseImagesRepository)
        {
            this.constructionsRepository = constructionsRepository;
            this.warehousesRepository = warehousesRepository;
            this.warehouseImagesRepository = warehouseImagesRepository;
        }

        public async Task AddWarehouseAsync(AddWarehouseViewModel viewModel)
        {
            if (!this.constructionsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Construction))
            {
                await this.constructionsRepository.AddAsync(new Construction { Name = viewModel.Construction });
            }

            await this.constructionsRepository.SaveChangesAsync();

            Construction construction = this.constructionsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Construction);

            var input = new Warehouse
            {
                Name = viewModel.Name,
                PopulatedArea = viewModel.PopulatedArea,
                Location = viewModel.Location,
                ConstructionId = construction.Id,
                Price = viewModel.Price,
                Description = viewModel.Description,
                SquareMeters = viewModel.SquareMeters,
            };

            await this.warehousesRepository.AddAsync(input);
            await this.warehousesRepository.SaveChangesAsync();
        }
    }
}
