namespace Imoty.Services.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Services.Mapping;
    using Imoty.Web.ViewModels.Home;
    using Microsoft.EntityFrameworkCore;

    public class PropertyService : IPropertyService
    {
        private readonly IDeletableEntityRepository<Apartment> apartmentRepository;
        private readonly IDeletableEntityRepository<House> houseRepository;
        private readonly IDeletableEntityRepository<Warehouse> warehouseRepository;
        private readonly IDeletableEntityRepository<Field> fieldRepository;
        private readonly IDeletableEntityRepository<BusinesStore> businesStoreRepository;
        private readonly IDeletableEntityRepository<Town> townRepository;
        private readonly IDeletableEntityRepository<District> districtRepository;
        private readonly IDeletableEntityRepository<Construction> constructionRepository;

        public PropertyService(
            IDeletableEntityRepository<Apartment> apartmentRepository,
            IDeletableEntityRepository<House> houseRepository,
            IDeletableEntityRepository<Warehouse> warehouseRepository,
            IDeletableEntityRepository<Field> fieldRepository,
            IDeletableEntityRepository<BusinesStore> businesStoreRepository,
            IDeletableEntityRepository<Town> townRepository,
            IDeletableEntityRepository<District> districtRepository,
            IDeletableEntityRepository<Construction> constructionRepository)
        {
            this.apartmentRepository = apartmentRepository;
            this.houseRepository = houseRepository;
            this.warehouseRepository = warehouseRepository;
            this.fieldRepository = fieldRepository;
            this.businesStoreRepository = businesStoreRepository;
            this.townRepository = townRepository;
            this.districtRepository = districtRepository;
            this.constructionRepository = constructionRepository;
        }

        public SinglePropertyViewModel GetByIdAndCategory(int id, string category)
        {
            var singleProperty = new SinglePropertyViewModel();

            if (category == nameof(Apartment))
            {
                var apartment = this.apartmentRepository.All().Include(x => x.Images).Include(x => x.Tags).FirstOrDefault(a => a.Id == id);
                var town = this.townRepository.All().FirstOrDefault(a => a.Id == apartment.TownId);
                var district = this.districtRepository.All().FirstOrDefault(a => a.Id == apartment.DistrictId);
                var construction = this.constructionRepository.All().FirstOrDefault(a => a.Id == apartment.ConstructionId);

                singleProperty.CategoryName = category;
                singleProperty.Type = apartment.Type;
                singleProperty.TownName = town.Name;
                singleProperty.DistrictName = district.Name;
                singleProperty.Price = apartment.Price;
                singleProperty.Description = apartment.Description;
                singleProperty.ConstructionName = construction.Name;
                singleProperty.Floor = apartment.Floor;
                singleProperty.TotalFloors = apartment.TotalFloors;
                singleProperty.SquareMeters = apartment.SquareMeters;
                singleProperty.BathRooms = apartment.BathRooms;
                singleProperty.BedRooms = apartment.BedRooms;

                foreach (var image in apartment.Images)
                {
                    singleProperty.ImageUrls.Add(image.Extension);
                }

                foreach (var tag in apartment.Tags)
                {
                    singleProperty.Tags.Add(tag.Name);
                }
            }
            else if (category == nameof(House))
            {
                var house = this.houseRepository.All().Include(x => x.Images).Include(x => x.Tags).FirstOrDefault(a => a.Id == id);
                var town = this.townRepository.All().FirstOrDefault(a => a.Id == house.TownId);
                var district = this.districtRepository.All().FirstOrDefault(a => a.Id == house.DistrictId);
                var construction = this.constructionRepository.All().FirstOrDefault(a => a.Id == house.ConstructionId);

                singleProperty.CategoryName = category;
                singleProperty.Type = house.Type;
                singleProperty.TownName = town.Name;
                singleProperty.DistrictName = district.Name;
                singleProperty.Price = house.Price;
                singleProperty.Description = house.Description;
                singleProperty.ConstructionName = construction.Name;
                singleProperty.TotalFloors = house.TotalFloors;
                singleProperty.SquareMeters = house.SquareMeters;
                singleProperty.BathRooms = house.BathRooms;
                singleProperty.BedRooms = house.BedRooms;
                singleProperty.BuiltUpArea = house.BuiltUpArea;

                foreach (var image in house.Images)
                {
                    singleProperty.ImageUrls.Add(image.Extension);
                }

                foreach (var tag in house.Tags)
                {
                    singleProperty.Tags.Add(tag.Name);
                }
            }
            else if (category == nameof(Warehouse))
            {
                var warehouse = this.warehouseRepository.All().Include(x => x.Images).Include(x => x.Tags).FirstOrDefault(a => a.Id == id);
                var town = this.townRepository.All().FirstOrDefault(a => a.Id == warehouse.TownId);
                var district = this.districtRepository.All().FirstOrDefault(a => a.Id == warehouse.DistrictId);
                var construction = this.constructionRepository.All().FirstOrDefault(a => a.Id == warehouse.ConstructionId);

                singleProperty.CategoryName = category;
                singleProperty.Type = warehouse.Type;
                singleProperty.TownName = town.Name;
                singleProperty.DistrictName = district.Name;
                singleProperty.Price = warehouse.Price;
                singleProperty.Description = warehouse.Description;
                singleProperty.ConstructionName = construction.Name;
                singleProperty.SquareMeters = warehouse.SquareMeters;

                foreach (var image in warehouse.Images)
                {
                    singleProperty.ImageUrls.Add(image.Extension);
                }

                foreach (var tag in warehouse.Tags)
                {
                    singleProperty.Tags.Add(tag.Name);
                }
            }
            else if (category == nameof(Field))
            {
                var field = this.fieldRepository.All().Include(x => x.Images).Include(x => x.Tags).FirstOrDefault(a => a.Id == id);
                var town = this.townRepository.All().FirstOrDefault(a => a.Id == field.TownId);
                var district = this.districtRepository.All().FirstOrDefault(a => a.Id == field.DistrictId);

                singleProperty.CategoryName = category;
                singleProperty.Type = field.Type;
                singleProperty.TownName = town.Name;
                singleProperty.DistrictName = district.Name;
                singleProperty.Price = field.Price;
                singleProperty.Description = field.Description;
                singleProperty.SquareMeters = field.SquareMeters;

                foreach (var image in field.Images)
                {
                    singleProperty.ImageUrls.Add(image.Extension);
                }

                foreach (var tag in field.Tags)
                {
                    singleProperty.Tags.Add(tag.Name);
                }
            }
            else if (category == nameof(BusinesStore))
            {
                var businesStore = this.businesStoreRepository.All().Include(x => x.Images).Include(x => x.Tags).FirstOrDefault(a => a.Id == id);
                var town = this.townRepository.All().FirstOrDefault(a => a.Id == businesStore.TownId);
                var district = this.districtRepository.All().FirstOrDefault(a => a.Id == businesStore.DistrictId);
                var construction = this.constructionRepository.All().FirstOrDefault(a => a.Id == businesStore.ConstructionId);

                singleProperty.CategoryName = category;
                singleProperty.Type = businesStore.Type;
                singleProperty.TownName = town.Name;
                singleProperty.DistrictName = district.Name;
                singleProperty.Price = businesStore.Price;
                singleProperty.Description = businesStore.Description;
                singleProperty.ConstructionName = construction.Name;
                singleProperty.SquareMeters = businesStore.SquareMeters;
                singleProperty.BathRooms = businesStore.BathRooms;

                foreach (var image in businesStore.Images)
                {
                    singleProperty.ImageUrls.Add(image.Extension);
                }

                foreach (var tag in businesStore.Tags)
                {
                    singleProperty.Tags.Add(tag.Name);
                }
            }

            return singleProperty;
        }

        public IEnumerable<T> GetByTagsAndType<T>(IEnumerable<int> tagIds, string searchInput)
        {
            var buseinesstoreQuery = this.businesStoreRepository.All().Where(b => b.Type.Contains(searchInput)).AsQueryable();
            var warehouseQuery = this.warehouseRepository.All().Where(b => b.Type.Contains(searchInput)).AsQueryable();
            var apartmentQuery = this.apartmentRepository.All().Where(b => b.Type.Contains(searchInput)).AsQueryable();
            var houseQuery = this.houseRepository.All().Where(b => b.Type.Contains(searchInput)).AsQueryable();
            var fieldQuery = this.fieldRepository.All().Where(b => b.Type.Contains(searchInput)).AsQueryable();

            foreach (var id in tagIds)
            {
                apartmentQuery = apartmentQuery.Where(a => a.Tags.Any(t => t.Id == id));
                buseinesstoreQuery = buseinesstoreQuery.Where(a => a.Tags.Any(t => t.Id == id));
                warehouseQuery = warehouseQuery.Where(a => a.Tags.Any(t => t.Id == id));
                houseQuery = houseQuery.Where(a => a.Tags.Any(t => t.Id == id));
                fieldQuery = fieldQuery.Where(a => a.Tags.Any(t => t.Id == id));
            }

            //foreach (var id in townIds)
            //{
            //    apartmentQuery = apartmentQuery.Where(a => a.TownId == id);
            //    buseinesstoreQuery = buseinesstoreQuery.Where(a => a.TownId == id);
            //    warehouseQuery = warehouseQuery.Where(a => a.TownId == id);
            //    houseQuery = houseQuery.Where(a => a.TownId == id);
            //    fieldQuery = fieldQuery.Where(a => a.TownId == id);
            //}

            //foreach (var id in districtIds)
            //{
            //    apartmentQuery = apartmentQuery.Where(a => a.DistrictId == id);
            //    buseinesstoreQuery = buseinesstoreQuery.Where(a => a.DistrictId == id);
            //    warehouseQuery = warehouseQuery.Where(a => a.DistrictId == id);
            //    houseQuery = houseQuery.Where(a => a.DistrictId == id);
            //    fieldQuery = fieldQuery.Where(a => a.DistrictId == id);
            //}

            var apartmentlist = apartmentQuery.To<T>().ToList();
            var houselist = houseQuery.To<T>().ToList();
            var warehouselist = warehouseQuery.To<T>().ToList();
            var fieldlist = fieldQuery.To<T>().ToList();
            var businesstorelist = buseinesstoreQuery.To<T>().ToList();

            foreach (var prop in houselist)
            {
                apartmentlist.Add(prop);
            }

            foreach (var prop in warehouselist)
            {
                apartmentlist.Add(prop);
            }

            foreach (var prop in fieldlist)
            {
                apartmentlist.Add(prop);
            }

            foreach (var prop in businesstorelist)
            {
                apartmentlist.Add(prop);
            }

            return apartmentQuery.To<T>().ToList();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            List<T> propertiesForSale = new List<T>();

            var apartments = this.apartmentRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .To<T>().ToList();

            var houses = this.houseRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .To<T>().ToList();

            var warehouses = this.warehouseRepository.All()
                .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .To<T>().ToList();

            var businesStores = this.businesStoreRepository.All()
               .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
              .To<T>().ToList();

            var fields = this.fieldRepository.All()
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

            return propertiesForSale.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
        }
    }
}
