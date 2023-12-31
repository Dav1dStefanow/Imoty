﻿namespace Imoty.Services.Data
{
    using System.IO;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.AddAd;

    public class AddBusinesStoreService : IAddBusinesStoreService
    {
        private readonly string[] allowedExtentions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<BusinesStore> businesStoresRepository;
        private readonly IRepository<BusinesStoreImage> businesStoreImagesRepository;
        private readonly CostructionValidationService costructionValidationService;
        private readonly TownValidationService townValidationService;
        private readonly DistrictValidationService districtValidationService;
        private readonly IDeletableEntityRepository<Tag> tagRepository;

        public AddBusinesStoreService(
            IDeletableEntityRepository<BusinesStore> businesStoresRepository,
            IRepository<BusinesStoreImage> businesStoreImagesRepository,
            CostructionValidationService costructionValidationService,
            TownValidationService townValidationService,
            DistrictValidationService districtValidationService,
            IDeletableEntityRepository<Tag> tagRepository)
        {
            this.businesStoresRepository = businesStoresRepository;
            this.businesStoreImagesRepository = businesStoreImagesRepository;
            this.costructionValidationService = costructionValidationService;
            this.townValidationService = townValidationService;
            this.districtValidationService = districtValidationService;
            this.tagRepository = tagRepository;
        }

        public async Task AddBusinesStoreAsync(AddBusinesStoreViewModel viewModel, string userId, string imagePath)
        {
            Construction construction = this.costructionValidationService.ValidateConstruction(viewModel);

            Town town = this.townValidationService.ValidateTown(viewModel);

            District district = this.districtValidationService.ValidateDistrict(viewModel);

            var input = new BusinesStore
            {
                Type = viewModel.Type,
                TownId = town.Id,
                DistrictId = district.Id,
                BathRooms = viewModel.BathRooms,
                FrontSpace = viewModel.FrontSpace,
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

                var dbImage = new BusinesStoreImage
                {
                    AddedByUserId = userId,
                    BusinesStore = input,
                    Extension = extension,
                };
                input.Images.Add(dbImage);
                await this.businesStoreImagesRepository.AddAsync(dbImage);

                Directory.CreateDirectory($"{imagePath}/businesStores/");
                var physicalPath = $"{imagePath}/businesStores/{dbImage.Id}.{extension}";
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

            await this.tagRepository.SaveChangesAsync();
            await this.businesStoresRepository.AddAsync(input);
            await this.businesStoresRepository.SaveChangesAsync();
        }
    }
}
