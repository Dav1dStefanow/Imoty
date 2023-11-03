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
    using Imoty.Services.Mapping;
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

        public IEnumerable<T> GetAllNewBuildings<T>(int page, int itemsNumber = 15)
        {
            List<T> propertiesForSale = new List<T>();

            string newBuildingTag = "Ново строителство";
            var apartments = this.apartmentsRepository.All()
                .OrderByDescending(x => x.Id)
                .Where(x => x.Tags.Any(x => x.Name == newBuildingTag))
                .To<T>().ToList();

            var houses = this.housesRepository.All()
                .OrderByDescending(x => x.Id)
                .Where(x => x.Tags.Any(x => x.Name == newBuildingTag))
                .To<T>().ToList();

            var warehouses = this.warehousesRepository.All()
               .OrderByDescending(x => x.Id)
               .Where(x => x.Tags.Any(x => x.Name == newBuildingTag))
               .To<T>().ToList();

            var businesStores = this.businesStoresRepository.All()
               .OrderByDescending(x => x.Id)
               .Where(x => x.Tags.Any(x => x.Name == newBuildingTag))
               .To<T>().ToList();

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
                .Skip((page - 1) * itemsNumber).Take(itemsNumber)
                .ToList();

            return allProps;
        }

        public int GetCount<T>()
        {
            List<T> propertiesForSale = new List<T>();

            var apartments = this.apartmentsRepository.All()
                .OrderByDescending(x => x.Id)
                .To<T>().ToList();

            var houses = this.housesRepository.All()
                .OrderByDescending(x => x.Id)
                .To<T>().ToList();

            var warehouses = this.warehousesRepository.All()
               .OrderByDescending(x => x.Id)
               .To<T>().ToList();

            var businesStores = this.businesStoresRepository.All()
               .OrderByDescending(x => x.Id)
               .To<T>().ToList();

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
