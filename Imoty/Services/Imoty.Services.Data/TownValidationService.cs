﻿namespace Imoty.Services.Data
{
    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Services.Mapping;
    using Imoty.Web.ViewModels.AddAd;
    using System.Collections.Generic;
    using System.Linq;

    public class TownValidationService
    {
        private readonly IDeletableEntityRepository<Town> townRepository;

        public TownValidationService(
            IDeletableEntityRepository<Town> townRepository)
        {
            this.townRepository = townRepository;
        }

        public Town ValidateTown(AddApartmentViewModel viewModel)
        {
            if (!this.townRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Town))
            {
                this.townRepository.AddAsync(new Town { Name = viewModel.Town });
            }

            this.townRepository.SaveChangesAsync();

            Town town = this.townRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Town);

            return town;
        }

        public Town ValidateTown(AddHouseViewModel viewModel)
        {
            if (!this.townRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Town))
            {
                this.townRepository.AddAsync(new Town { Name = viewModel.Town });
            }

            this.townRepository.SaveChangesAsync();

            Town town = this.townRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Town);

            return town;
        }

        public Town ValidateTown(AddBusinesStoreViewModel viewModel)
        {
            if (!this.townRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Town))
            {
                this.townRepository.AddAsync(new Town { Name = viewModel.Town });
            }

            this.townRepository.SaveChangesAsync();

            Town town = this.townRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Town);

            return town;
        }

        public Town ValidateTown(AddWarehouseViewModel viewModel)
        {
            if (!this.townRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Town))
            {
                this.townRepository.AddAsync(new Town { Name = viewModel.Town });
            }

            this.townRepository.SaveChangesAsync();

            Town town = this.townRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Town);

            return town;
        }

        public Town ValidateTown(AddFieldViewModel viewModel)
        {
            if (!this.townRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Town))
            {
                this.townRepository.AddAsync(new Town { Name = viewModel.Town });
            }

            this.townRepository.SaveChangesAsync();

            Town town = this.townRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Town);

            return town;
        }

        public IEnumerable<T> GetAllTowns<T>()
        {
            return this.townRepository.All().To<T>().ToList();
        }
    }
}
