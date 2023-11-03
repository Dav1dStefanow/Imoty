namespace Imoty.Services.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Services.Mapping;
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

        public IEnumerable<T> GetAllSales<T>(int page, int itemsNumber = 15)
        {
            List<T> propertiesForSale = new List<T>();

            var apartments = this.apartmentsRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
               .To<T>().ToList();

            var houses = this.housesRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .To<T>().ToList();

            var warehouses = this.warehousesRepository.All()
                .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
              .To<T>().ToList();

            var businesStores = this.businesStoresRepository.All()
               .Where(x => x.ForSale == true)
              .To<T>().ToList();

            var fields = this.fieldsRepository.All()
              .OrderByDescending(x => x.Id)
              .To<T>().ToList();

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

            return propertiesForSale;
        }

        public int GetCount<T>()
        {
            List<T> propertiesForSale = new List<T>();

            var apartments = this.apartmentsRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .To<T>().ToList();

            var houses = this.housesRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .To<T>().ToList();

            var warehouses = this.warehousesRepository.All()
                .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .To<T>().ToList();

            var businesStores = this.businesStoresRepository.All()
               .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
              .To<T>().ToList();

            var fields = this.fieldsRepository.All()
              .OrderByDescending(x => x.Id)
              .To<T>().ToList();

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

            return propertiesForSale.Count();
        }
    }
}
