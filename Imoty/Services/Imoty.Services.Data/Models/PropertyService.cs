namespace Imoty.Services.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Services.Data.Interfaces;
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

        public IEnumerable<PropertyForSaleRentInListViewModel> GetByTags(IEnumerable<int> tagIds)
        {
            List<PropertyForSaleRentInListViewModel> propertiesForSale = new List<PropertyForSaleRentInListViewModel>();
            foreach (int tagId in tagIds)
            {
                var apartments = this.apartmentRepository.All()
                .Where(x => x.Tags.Any(t => t.Id == tagId))
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(Apartment),
                }).ToList();

                foreach (var apartment in apartments)
                {
                    propertiesForSale.Add(apartment);
                }
            }

            foreach (int tagId in tagIds)
            {
                var houses = this.houseRepository.All()
                .Where(x => x.Tags.Any(t => t.Id == tagId))
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(House),
                }).ToList();

                foreach (var house in houses)
                {
                    propertiesForSale.Add(house);
                }
            }

            foreach (int tagId in tagIds)
            {
                var warehouses = this.warehouseRepository.All()
                .Where(x => x.Tags.Any(t => t.Id == tagId))
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(Warehouse),
                }).ToList();

                foreach (var warehouse in warehouses)
                {
                    propertiesForSale.Add(warehouse);
                }
            }

            foreach (int tagId in tagIds)
            {
                var fields = this.fieldRepository.All()
                .Where(x => x.Tags.Any(t => t.Id == tagId))
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(Field),
                }).ToList();

                foreach (var field in fields)
                {
                    propertiesForSale.Add(field);
                }
            }

            foreach (int tagId in tagIds)
            {
                var businesStores = this.businesStoreRepository.All()
                .Where(x => x.Tags.Any(t => t.Id == tagId))
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(BusinesStore),
                }).ToList();

                foreach (var businesStore in businesStores)
                {
                    propertiesForSale.Add(businesStore);
                }
            }

            return propertiesForSale;
        }

        public IEnumerable<PropertyForSaleRentInListViewModel> GetRandom(int count)
        {
            List<PropertyForSaleRentInListViewModel> propertiesForSale = new List<PropertyForSaleRentInListViewModel>();

            var apartments = this.apartmentRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    Type = x.Type,
                    CategoryName = nameof(Apartment),
                }).ToList();

            var houses = this.houseRepository.All()
                .Where(x => x.ForSale == true)
                .OrderByDescending(x => x.Id)
                .Select(x => new PropertyForSaleRentInListViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    ImageUrl = x.Images.FirstOrDefault().Extension,
                    CategoryName = nameof(House),
                }).ToList();

            var warehouses = this.warehouseRepository.All()
                .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .Select(x => new PropertyForSaleRentInListViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(Warehouse),
               }).ToList();

            var businesStores = this.businesStoreRepository.All()
               .Where(x => x.ForSale == true)
               .OrderByDescending(x => x.Id)
               .Select(x => new PropertyForSaleRentInListViewModel
               {
                   Id = x.Id,
                   Type = x.Type,
                   ImageUrl = x.Images.FirstOrDefault().Extension,
                   CategoryName = nameof(BusinesStore),
               }).ToList();

            var fields = this.fieldRepository.All()
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

            return propertiesForSale.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
        }
    }
}
