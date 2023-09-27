namespace Imoty.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Web.ViewModels.AddAd;
    using Microsoft.EntityFrameworkCore.Metadata;

    public class AddHouseService : IAddHouseService
    {
        private readonly IDeletableEntityRepository<House> housesRepository;
        private readonly IDeletableEntityRepository<Construction> constructionsRepository;
        private readonly IRepository<HouseImage> houseImagesRepository;

        public AddHouseService(
            IDeletableEntityRepository<House> housesRepository,
            IDeletableEntityRepository<Construction> constructionsRepository,
            IRepository<HouseImage> houseImagesRepository)
        {
            this.housesRepository = housesRepository;
            this.constructionsRepository = constructionsRepository;
            this.houseImagesRepository = houseImagesRepository;
        }

        public async Task AddHouseAsync(AddHouseViewModel viewModel)
        {
            if (!this.constructionsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Construction))
            {
                await this.constructionsRepository.AddAsync(new Construction { Name = viewModel.Construction });
            }

            await this.constructionsRepository.SaveChangesAsync();

            Construction construction = this.constructionsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Construction);

            var input = new House
            {
                Name = viewModel.Name,
                PopulatedArea = viewModel.PopulatedArea,
                Location = viewModel.Location,
                BathRooms = viewModel.BathRooms,
                BedRooms = viewModel.BedRooms,
                Garages = viewModel.Garages,
                TotalFloors = viewModel.TotalFloors,
                ConstructionId = construction.Id,
                Price = viewModel.Price,
                Description = viewModel.Description,
                SquareMeters = viewModel.SquareMeters,
                BuiltUpArea = viewModel.BuiltUpArea,
            };

            await this.housesRepository.AddAsync(input);
            await this.housesRepository.SaveChangesAsync();
        }
    }
}
