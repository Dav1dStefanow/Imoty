namespace Imoty.Services.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.AddAd;

    public class AddWarehouseService : IAddWarehouseService
    {
        private readonly string[] allowedExtentions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Warehouse> warehousesRepository;
        private readonly IRepository<WarehouseImage> warehouseImagesRepository;
        private readonly CostructionValidationService costructionValidationService;
        private readonly TownValidationService townValidationService;
        private readonly DistrictValidationService districtValidationService;
        private readonly IDeletableEntityRepository<Tag> tagRepository;

        public AddWarehouseService(
            IDeletableEntityRepository<Warehouse> warehousesRepository,
            IRepository<WarehouseImage> warehouseImagesRepository,
            CostructionValidationService costructionValidationService,
            TownValidationService townValidationService,
            DistrictValidationService districtValidationService,
            IDeletableEntityRepository<Tag> tagRepository)
        {
            this.warehousesRepository = warehousesRepository;
            this.warehouseImagesRepository = warehouseImagesRepository;
            this.costructionValidationService = costructionValidationService;
            this.townValidationService = townValidationService;
            this.districtValidationService = districtValidationService;
            this.tagRepository = tagRepository;
        }

        public async Task AddWarehouseAsync(AddWarehouseViewModel viewModel, string userId, string imagePath)
        {
            Construction construction = this.costructionValidationService.ValidateConstruction(viewModel);

            Town town = this.townValidationService.ValidateTown(viewModel);

            District district = this.districtValidationService.ValidateDistrict(viewModel);

            var input = new Warehouse
            {
                Type = viewModel.Type,
                TownId = town.Id,
                DistrictId = district.Id,
                ConstructionId = construction.Id,
                Price = viewModel.Price,
                Description = viewModel.Description,
                SquareMeters = viewModel.SquareMeters,
                AddedByUserId = userId,
            };

            if (viewModel.Price < 10000)
            {
                input.ForSale = false;
            }
            else
            {
                input.ForSale = true;
            }

            foreach (var image in viewModel.Images)
            {
                string extension = Path.GetExtension(image.FileName);
                if (!this.allowedExtentions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new WarehouseImage
                {
                    AddedByUserId = userId,
                    Warehouse = input,
                    Extension = extension,
                };
                input.Images.Add(dbImage);
                await this.warehouseImagesRepository.AddAsync(dbImage);

                Directory.CreateDirectory($"{imagePath}/warehouses/");
                var physicalPath = $"{imagePath}/warehouses/{dbImage.Id}.{extension}";
                using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

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

            await this.warehouseImagesRepository.SaveChangesAsync();
            await this.tagRepository.SaveChangesAsync();
            await this.warehousesRepository.AddAsync(input);
            await this.warehousesRepository.SaveChangesAsync();
        }
    }
}
