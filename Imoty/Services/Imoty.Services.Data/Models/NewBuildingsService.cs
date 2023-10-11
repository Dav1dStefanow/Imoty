namespace Imoty.Services.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.Home;

    public class NewBuildingsService : INewBuildingsService
    {
        private readonly IDeletableEntityRepository<Apartment> apartmentsRepository;
        private readonly IDeletableEntityRepository<House> housesRepository;
        private readonly IDeletableEntityRepository<BusinesStore> businesStoresRepository;
        private readonly IDeletableEntityRepository<Warehouse> warehousesRepository;

        public NewBuildingsService(
            IDeletableEntityRepository<Apartment> apartmentsRepository,
            IDeletableEntityRepository<House> housesRepository,
            IDeletableEntityRepository<BusinesStore> businesStoresRepository,
            IDeletableEntityRepository<Warehouse> warehousesRepository)
        {
            this.apartmentsRepository = apartmentsRepository;
            this.housesRepository = housesRepository;
            this.businesStoresRepository = businesStoresRepository;
            this.warehousesRepository = warehousesRepository;
        }

        public IEnumerable<PropertyForSaleRentViewModel> GetAllNewBuildings(int page, int itemsNumber = 15)
        {
            List<PropertyForSaleRentViewModel> propertiesForSale = new List<PropertyForSaleRentViewModel>();

            string newBuildingTag = "Ново строителство";

            var apartments = this.apartmentsRepository.All()
                .OrderByDescending(x => x.Id)
                .Where(x => x.Tags.Any(x => x.Name == newBuildingTag))
                .Select(x => new PropertyForSaleRentViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(Apartment),
                }).ToList();

            var houses = this.housesRepository.All()
                .OrderByDescending(x => x.Id)
                .Where(x => x.Tags.Any(x => x.Name == newBuildingTag))
                .Select(x => new PropertyForSaleRentViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    CategoryName = nameof(House),
                }).ToList();

            var warehouses = this.warehousesRepository.All()
               .OrderByDescending(x => x.Id)
               .Where(x => x.Tags.Any(x => x.Name == newBuildingTag))
               .Select(x => new PropertyForSaleRentViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(Warehouse),
               }).ToList();

            var businesStores = this.businesStoresRepository.All()
               .OrderByDescending(x => x.Id)
               .Where(x => x.Tags.Any(x => x.Name == newBuildingTag))
               .Select(x => new PropertyForSaleRentViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(BusinesStore),
               }).ToList();

            foreach (var businesStore in businesStores)
            {
                propertiesForSale.Add(businesStore);
            }

            foreach (var apartment in apartments)
            {
                propertiesForSale.Add(apartment);
            }

            foreach (var house in houses)
            {
                propertiesForSale.Add(house);
            }

            foreach (var warehouse in warehouses)
            {
                propertiesForSale.Add(warehouse);
            }

            var allProps = propertiesForSale
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsNumber).Take(itemsNumber)
                .Select(x => new PropertyForSaleRentViewModel
                {
                    ImageUrl = x.ImageUrl,
                    CategoryName = x.CategoryName,
                    Type = x.Type,
                    Id = x.Id,
                })
                .ToList();

            return allProps;
        }

        public int GetCount()
        {
            List<PropertyForSaleRentViewModel> propertiesForSale = new List<PropertyForSaleRentViewModel>();

            var apartments = this.apartmentsRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .Select(x => new PropertyForSaleRentViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(Apartment),
                }).ToList();

            var houses = this.housesRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .Select(x => new PropertyForSaleRentViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    CategoryName = nameof(House),
                }).ToList();

            var warehouses = this.warehousesRepository.All()
                .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .Select(x => new PropertyForSaleRentViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(Warehouse),
               }).ToList();

            var businesStores = this.businesStoresRepository.All()
               .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .Select(x => new PropertyForSaleRentViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(BusinesStore),
               }).ToList();

            foreach (var businesStore in businesStores)
            {
                propertiesForSale.Add(businesStore);
            }

            foreach (var apartment in apartments)
            {
                propertiesForSale.Add(apartment);
            }

            foreach (var house in houses)
            {
                propertiesForSale.Add(house);
            }

            foreach (var warehouse in warehouses)
            {
                propertiesForSale.Add(warehouse);
            }

            var allProps = propertiesForSale
                .OrderByDescending(x => x.Id)
                .Select(x => new PropertyForSaleRentViewModel
                {
                    ImageUrl = x.ImageUrl,
                    CategoryName = x.CategoryName,
                    Type = x.Type,
                    Id = x.Id,
                })
                .ToList();

            return allProps.Count();
        }
    }
}
