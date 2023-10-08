namespace Imoty.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.AddAd;
    using Microsoft.EntityFrameworkCore.Metadata;

    public class AddHouseService : IAddHouseService
    {
        private readonly IDeletableEntityRepository<House> housesRepository;
        private readonly IRepository<HouseImage> houseImagesRepository;
        private readonly IDeletableEntityRepository<District> districtsRepository;
        private readonly CostructionValidationService costructionValidationService;
        private readonly TownValidationService townValidationService;
        private readonly DistrictValidationService districtValidationService;
        private readonly IDeletableEntityRepository<Tag> tagRepository;

        public AddHouseService(
            IDeletableEntityRepository<House> housesRepository,
            IRepository<HouseImage> houseImagesRepository,
            IDeletableEntityRepository<Town> townsRepository,
            IDeletableEntityRepository<District> districtsRepository,
            CostructionValidationService costructionValidationService,
            TownValidationService townValidationService,
            DistrictValidationService districtValidationService,
            IDeletableEntityRepository<Tag> tagRepository)
        {
            this.housesRepository = housesRepository;
            this.houseImagesRepository = houseImagesRepository;
            this.districtsRepository = districtsRepository;
            this.costructionValidationService = costructionValidationService;
            this.townValidationService = townValidationService;
            this.districtValidationService = districtValidationService;
            this.tagRepository = tagRepository;
        }

        public async Task AddHouseAsync(AddHouseViewModel viewModel, string userId)
        {
            Construction construction = this.costructionValidationService.ValidateConstruction(viewModel);

            Town town = this.townValidationService.ValidateTown(viewModel);

            District district = this.districtValidationService.ValidateDistrict(viewModel);

            var input = new House
            {
                Type = viewModel.Type,
                TownId = town.Id,
                DistrictId = district.Id,
                BathRooms = viewModel.BathRooms,
                BedRooms = viewModel.BedRooms,
                TotalFloors = viewModel.TotalFloors,
                ConstructionId = construction.Id,
                Price = viewModel.Price,
                Description = viewModel.Description,
                SquareMeters = viewModel.SquareMeters,
                BuiltUpArea = viewModel.BuiltUpArea,
                AddedByUserId = userId,
            };
            foreach (var tagg in viewModel.Tags)
            {
                var tag = this.tagRepository.All().FirstOrDefault(t => t.Name == tagg.TagName);
                if (tag == null)
                {
                    tag = new Tag { Name = tagg.TagName };
                    await this.tagRepository.AddAsync(tag);
                }

                input.Tags.Add(tag);
            }

            await this.tagRepository.SaveChangesAsync();
            await this.housesRepository.AddAsync(input);
            await this.housesRepository.SaveChangesAsync();
        }
    }
}
