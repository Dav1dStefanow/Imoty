namespace Imoty.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Services.Mapping;
    using Imoty.Web.ViewModels.AddAd;

    public class DistrictValidationService
    {
        private readonly IDeletableEntityRepository<District> districtRepository;

        public DistrictValidationService(IDeletableEntityRepository<District> districtRepository)
        {
            this.districtRepository = districtRepository;
        }

        public District ValidateDistrict(AddApartmentViewModel viewModel)
        {
            if (!this.districtRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.District))
            {
                this.districtRepository.AddAsync(new District { Name = viewModel.District });
            }

            this.districtRepository.SaveChangesAsync();

            District district = this.districtRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.District);

            return district;
        }

        public District ValidateDistrict(AddHouseViewModel viewModel)
        {
            if (!this.districtRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.District))
            {
                this.districtRepository.AddAsync(new District { Name = viewModel.District });
            }

            this.districtRepository.SaveChangesAsync();

            District district = this.districtRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.District);

            return district;
        }

        public District ValidateDistrict(AddBusinesStoreViewModel viewModel)
        {
            if (!this.districtRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.District))
            {
                this.districtRepository.AddAsync(new District { Name = viewModel.District });
            }

            this.districtRepository.SaveChangesAsync();

            District district = this.districtRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.District);

            return district;
        }

        public District ValidateDistrict(AddWarehouseViewModel viewModel)
        {
            if (!this.districtRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.District))
            {
                this.districtRepository.AddAsync(new District { Name = viewModel.District });
            }

            this.districtRepository.SaveChangesAsync();

            District district = this.districtRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.District);

            return district;
        }

        public District ValidateDistrict(AddFieldViewModel viewModel)
        {
            if (!this.districtRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.District))
            {
                this.districtRepository.AddAsync(new District { Name = viewModel.District });
            }

            this.districtRepository.SaveChangesAsync();

            District district = this.districtRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.District);

            return district;
        }

        public IEnumerable<T> GetAllDistricts<T>()
        {
            return this.districtRepository.All().To<T>().ToList();
        }
    }
}
