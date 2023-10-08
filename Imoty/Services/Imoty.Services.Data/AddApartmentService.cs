namespace Imoty.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.AddAd;

    public class AddApartmentService : IAddApartmentService
    {
        private readonly IDeletableEntityRepository<Apartment> apartmentsRepository;
        private readonly IRepository<ApartmentImage> apartmentImagesRepository;
        private readonly CostructionValidationService validateConstructionService;
        private readonly TownValidationService townValidationService;
        private readonly DistrictValidationService districtValidationService;
        private readonly IDeletableEntityRepository<Tag> tagRepository;

        public AddApartmentService(
            IDeletableEntityRepository<Apartment> apartmentsRepository,
            IRepository<ApartmentImage> apartmentImagesRepository,
            CostructionValidationService validateConstructionService,
            TownValidationService townValidationService,
            DistrictValidationService districtValidationService,
            IDeletableEntityRepository<Tag> tagRepository)
        {
            this.apartmentsRepository = apartmentsRepository;
            this.apartmentImagesRepository = apartmentImagesRepository;
            this.validateConstructionService = validateConstructionService;
            this.townValidationService = townValidationService;
            this.districtValidationService = districtValidationService;
            this.tagRepository = tagRepository;
        }

        public async Task AddApartmentAsync(AddApartmentViewModel viewModel, string userId)
        {
            Construction construction = this.validateConstructionService.ValidateConstruction(viewModel);

            Town town = this.townValidationService.ValidateTown(viewModel);

            District district = this.districtValidationService.ValidateDistrict(viewModel);

            var input = new Apartment
            {
                Type = viewModel.Type,
                TownId = town.Id,
                DistrictId = district.Id,
                BathRooms = viewModel.BathRooms,
                BedRooms = viewModel.BedRooms,
                TotalFloors = viewModel.TotalFloors,
                ConstructionId = construction.Id,
                Floor = viewModel.Floor,
                Price = viewModel.Price,
                Description = viewModel.Description,
                SquareMeters = viewModel.SquareMeters,
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
            await this.apartmentsRepository.AddAsync(input);
            await this.apartmentsRepository.SaveChangesAsync();
        }
    }
}
