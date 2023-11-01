namespace Imoty.Services.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.Home;

    public class SalesService : ISalesService
    {
        private readonly IDeletableEntityRepository<Apartment> apartmentsRepository;
        private readonly IDeletableEntityRepository<House> housesRepository;
        private readonly IDeletableEntityRepository<BusinesStore> businesStoresRepository;
        private readonly IDeletableEntityRepository<Warehouse> warehousesRepository;
        private readonly IDeletableEntityRepository<Field> fieldsRepository;

        public SalesService(
            IDeletableEntityRepository<Apartment> apartmentsRepository,
            IDeletableEntityRepository<House> housesRepository,
            IDeletableEntityRepository<BusinesStore> businesStoresRepository,
            IDeletableEntityRepository<Warehouse> warehousesRepository,
            IDeletableEntityRepository<Field> fieldsRepository)
        {
            this.apartmentsRepository = apartmentsRepository;
            this.housesRepository = housesRepository;
            this.businesStoresRepository = businesStoresRepository;
            this.warehousesRepository = warehousesRepository;
            this.fieldsRepository = fieldsRepository;
        }

        public IEnumerable<PropertyForSaleRentInListViewModel> GetAllSales(int page, int itemsNumber = 15)
        {
            List<PropertyForSaleRentInListViewModel> propertiesForSale = new List<PropertyForSaleRentInListViewModel>();

            var apartments = this.apartmentsRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(Apartment),
                }).ToList();

            var houses = this.housesRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    CategoryName = nameof(House),
                }).ToList();

            var warehouses = this.warehousesRepository.All()
                .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .Select(x => new PropertyForSaleRentInListViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(Warehouse),
               }).ToList();

            var businesStores = this.businesStoresRepository.All()
               .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .Select(x => new PropertyForSaleRentInListViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(BusinesStore),
               }).ToList();

            var fields = this.fieldsRepository.All()
              .OrderByDescending(x => x.Id)
              .Select(x => new PropertyForSaleRentInListViewModel
              {
                  Id = x.Id,
                  Type = x.Type,
                  ImageUrl = x.Images.FirstOrDefault().Extension,
                  CategoryName = nameof(Field),
              }).ToList();

            foreach (var field in fields)
            {
                propertiesForSale.Add(field);
            }

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
                .Select(x => new PropertyForSaleRentInListViewModel
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
            List<PropertyForSaleRentInListViewModel> propertiesForSale = new List<PropertyForSaleRentInListViewModel>();

            var apartments = this.apartmentsRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(Apartment),
                }).ToList();

            var houses = this.housesRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    CategoryName = nameof(House),
                }).ToList();

            var warehouses = this.warehousesRepository.All()
                .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .Select(x => new PropertyForSaleRentInListViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(Warehouse),
               }).ToList();

            var businesStores = this.businesStoresRepository.All()
               .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .Select(x => new PropertyForSaleRentInListViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(BusinesStore),
               }).ToList();

            var fields = this.fieldsRepository.All()
              .OrderByDescending(x => x.Id)
              .Select(x => new PropertyForSaleRentInListViewModel
              {
                  Id = x.Id,
                  Type = x.Type,
                  ImageUrl = x.Images.FirstOrDefault().Extension,
                  CategoryName = nameof(Field),
              }).ToList();

            foreach (var field in fields)
            {
                propertiesForSale.Add(field);
            }

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
                .Select(x => new PropertyForSaleRentInListViewModel
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
