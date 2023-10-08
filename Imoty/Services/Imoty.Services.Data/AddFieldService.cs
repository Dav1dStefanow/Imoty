namespace Imoty.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.AddAd;

    public class AddFieldService : IAddFieldService
    {
        private readonly IDeletableEntityRepository<Field> fieldsRepository;
        private readonly IRepository<FieldImage> fieldImagesRepository;
        private readonly TownValidationService townValidationService;
        private readonly DistrictValidationService districtValidationService;
        private readonly IDeletableEntityRepository<Tag> tagRepository;

        public AddFieldService(
            IDeletableEntityRepository<Field> fieldsRepository,
            IRepository<FieldImage> fieldImagesRepository,
            TownValidationService townValidationService,
            DistrictValidationService districtValidationService,
            IDeletableEntityRepository<Tag> tagRepository)
        {
            this.fieldsRepository = fieldsRepository;
            this.fieldImagesRepository = fieldImagesRepository;
            this.townValidationService = townValidationService;
            this.districtValidationService = districtValidationService;
            this.tagRepository = tagRepository;
        }

        public async Task AddFieldAsync(AddFieldViewModel viewModel, string userId)
        {
            Town town = this.townValidationService.ValidateTown(viewModel);

            District district = this.districtValidationService.ValidateDistrict(viewModel);

            var input = new Field
            {
                Type = viewModel.Type,
                TownId = town.Id,
                DistrictId = district.Id,
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
            await this.fieldsRepository.AddAsync(input);
            await this.fieldsRepository.SaveChangesAsync();
        }
    }
}
