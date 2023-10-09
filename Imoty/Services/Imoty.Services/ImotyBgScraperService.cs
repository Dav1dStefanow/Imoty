namespace Imoty.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.ConstrainedExecution;
    using System.Threading.Tasks;

    using AngleSharp;
    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Services.Data;

    public class ImotyBgScraperService : IImotyBgScraperService
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;
        private readonly IDeletableEntityRepository<Apartment> apartmentsRepository;
        private readonly IRepository<ApartmentImage> apartmentImagesRepository;
        private readonly IDeletableEntityRepository<Tag> tagRepository;
        private readonly IDeletableEntityRepository<BusinesStore> businesStoresRepository;
        private readonly IRepository<BusinesStoreImage> businesStoreImagesRepository;
        private readonly IDeletableEntityRepository<Field> fieldsRepository;
        private readonly IRepository<FieldImage> fieldImagesRepository;
        private readonly IDeletableEntityRepository<House> housesRepository;
        private readonly IRepository<HouseImage> houseImagesRepository;
        private readonly IDeletableEntityRepository<Warehouse> warehousesRepository;
        private readonly IRepository<WarehouseImage> warehouseImagesRepository;
        private readonly IDeletableEntityRepository<Construction> constructionsRepository;
        private readonly IDeletableEntityRepository<Town> townsRepository;
        private readonly IDeletableEntityRepository<District> districtsRepository;

        public ImotyBgScraperService(
            IDeletableEntityRepository<Apartment> apartmentsRepository,
            IRepository<ApartmentImage> apartmentImagesRepository,
            IDeletableEntityRepository<Tag> tagRepository,
            IDeletableEntityRepository<BusinesStore> businesStoresRepository,
            IRepository<BusinesStoreImage> businesStoreImagesRepository,
            IDeletableEntityRepository<Field> fieldsRepository,
            IRepository<FieldImage> fieldImagesRepository,
            IDeletableEntityRepository<House> housesRepository,
            IRepository<HouseImage> houseImagesRepository,
            IDeletableEntityRepository<Warehouse> warehousesRepository,
            IRepository<WarehouseImage> warehouseImagesRepository,
            IDeletableEntityRepository<Construction> constructionsRepository,
            IDeletableEntityRepository<Town> townsRepository,
            IDeletableEntityRepository<District> districtsRepository)
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
            this.apartmentsRepository = apartmentsRepository;
            this.apartmentImagesRepository = apartmentImagesRepository;
            this.tagRepository = tagRepository;
            this.businesStoresRepository = businesStoresRepository;
            this.businesStoreImagesRepository = businesStoreImagesRepository;
            this.fieldsRepository = fieldsRepository;
            this.fieldImagesRepository = fieldImagesRepository;
            this.housesRepository = housesRepository;
            this.houseImagesRepository = houseImagesRepository;
            this.warehousesRepository = warehousesRepository;
            this.warehouseImagesRepository = warehouseImagesRepository;
            this.constructionsRepository = constructionsRepository;
            this.townsRepository = townsRepository;
            this.districtsRepository = districtsRepository;
        }

        public async Task PopulateDbWithProperiesAsync(string link)
        {
            var doc = await this.context.OpenAsync(link);

            // Type
            var tipe = doc.QuerySelector($"#offerContent > div.col-lg-5.col-xl-4 > div > div:nth-child(1) > div > h4");
            string type = tipe.TextContent.Trim();
            Console.WriteLine($"Type: {type}");

            // Town / District / Price / Price in sq. meters / square meters
            string town = null;
            string district = null;
            int price = 0;
            int squareMeters = 0;
            int floor = 0;
            int totalFloors = 0;
            int buildUpAreea = 0;
            int yard = 0;
            List<string> tableElements = new List<string>();
            try
            {
                for (int j = 1; j <= 5; j++)
                {
                    for (var k = 1; k <= 5; k++)
                    {
                        var morreInfo = doc.QuerySelectorAll($"#offerContent > div.col-lg-5.col-xl-4 > div > div:nth-child(1) > div > table > tbody > tr:nth-child({j}) > td:nth-child({k})");
                        foreach (var item in morreInfo)
                        {
                            tableElements.Add(item.TextContent);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            for (int j = 0; j < tableElements.Count; j++)
            {
                switch (tableElements[j])
                {
                    case "Населено място":
                        town = tableElements[j + 1];
                        break;
                    case "Местоположение":
                        district = tableElements[j + 1];
                        break;
                    case "Цена":
                        string[] parts = tableElements[j + 1].Split().ToArray();
                        if (parts.Length == 2)
                        {
                            price = int.Parse(parts[0]);
                        }
                        else if (parts.Length == 3)
                        {
                            price = int.Parse(parts[0] + parts[1]);
                        }

                        break;
                    case "Площ":
                        string[] tokens = tableElements[j + 1].Split().ToArray();
                        if (tokens.Length == 2)
                        {
                            squareMeters = int.Parse(tokens[0]);
                        }
                        else if (tokens.Length == 3)
                        {
                            squareMeters = int.Parse(tokens[0] + tokens[1]);
                        }

                        break;
                    case "Двор":
                        string[] asd = tableElements[j + 1].Split().ToArray();
                        if (asd.Length == 2)
                        {
                            yard = int.Parse(asd[0]);
                        }
                        else if (asd.Length == 3)
                        {
                            yard = int.Parse(asd[0] + asd[1]);
                        }

                        break;
                    case "Застроена площ":
                        string[] ddf = tableElements[j + 1].Split().ToArray();
                        if (ddf.Length == 2)
                        {
                            buildUpAreea = int.Parse(ddf[0]);
                        }
                        else if (ddf.Length == 3)
                        {
                            buildUpAreea = int.Parse(ddf[0] + ddf[1]);
                        }

                        break;
                    case "Етажност":
                        totalFloors = int.Parse(tableElements[j + 1]);
                        break;
                    case "Етаж":
                        string[] floorz = tableElements[j + 1].Split().ToArray();
                        floor = int.Parse(floorz[0]);
                        totalFloors = int.Parse(floorz[2]);
                        break;
                }
            }

            Console.WriteLine("Town: " + town);
            Console.WriteLine($"District: {district}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Square Meters: {squareMeters}");
            Console.WriteLine($"Yard: {yard}");
            Console.WriteLine($"Build-Up Areea: {buildUpAreea}");
            Console.WriteLine($"Floor: {floor}");
            Console.WriteLine($"Total Floors: {totalFloors}");
            Console.WriteLine();

            // bedrooms / bathrooms
            int bedRooms = 0;
            int bathRooms = 0;
            try
            {
                var moreInfo = doc.QuerySelectorAll("#offerContent > div.col-lg-7.col-xl-8 > ul > li");
                int i = 1;
                foreach (var element in moreInfo)
                {
                    if (i == 2)
                    {
                        Console.Write("BedRooms: ");
                        string[] bedRoomz = element.TextContent.Split().ToArray();
                        bedRooms = int.Parse(bedRoomz[0]);
                        Console.WriteLine(bedRooms);

                    }
                    else if (i == 3)
                    {
                        Console.Write("BathRooms: ");
                        string[] bathRoomz = element.TextContent.Split().ToArray();
                        bathRooms = int.Parse(bathRoomz[0]);
                        Console.WriteLine(bathRooms);
                    }

                    i++;
                }
            }
            catch (Exception)
            {
            }

            // Construction
            var conztruction = doc.QuerySelector($"#accordion_0-collapse-1 > div > ul:nth-child(2) > li");
            string construction = conztruction.TextContent;
            Console.WriteLine($"Construction: {construction}");

            // Description
            var description = doc.QuerySelector("#offerContent > div.col-lg-7.col-xl-8 > div.tdescription");
            string dezcription = description.TextContent;
            Console.WriteLine("Description: " + dezcription);
            Console.WriteLine();

            // Tags
            List<string> otherAttributes = new List<string>();
            try
            {
                for (int i = 4; i < 100; i++)
                {
                    if (i % 2 == 0)
                    {
                        var elements = doc.QuerySelectorAll($"#accordion_0-collapse-1 > div > ul:nth-child({i}) > li");
                        foreach (var element in elements)
                        {
                            otherAttributes.Add(element.TextContent);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            // Get Images
            List<string> images = new List<string>();
            var imageUrls = doc.GetElementById("parent-carousel").QuerySelectorAll("div > div > a > img");
            foreach (var imageUrl in imageUrls)
            {
                images.Add(imageUrl.GetAttribute("src"));
            }

            // Validation
            if (!this.constructionsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == construction))
            {
                await this.constructionsRepository.AddAsync(new Construction { Name = construction });
                await this.constructionsRepository.SaveChangesAsync();
            }

            if (!this.townsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == town))
            {
                await this.townsRepository.AddAsync(new Town { Name = town });
                await this.townsRepository.SaveChangesAsync();
            }

            if (!this.districtsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == district))
            {
                await this.districtsRepository.AddAsync(new District { Name = district });
                await this.districtsRepository.SaveChangesAsync();
            }

            District dizztrict = this.districtsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == district);
            Town townn = this.townsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == town);
            Construction conzztruction = this.constructionsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == construction);

            if (floor != 0)
            {
                var apartment = new Apartment
                {
                    Type = type,
                    TownId = townn.Id,
                    DistrictId = dizztrict.Id,
                    ConstructionId = conzztruction.Id,
                    BathRooms = bathRooms,
                    BedRooms = bedRooms,
                    TotalFloors = totalFloors,
                    Floor = floor,
                    Price = price,
                    Description = dezcription,
                    SquareMeters = squareMeters,
                };

                if (price < 10000)
                {
                    apartment.ForSale = false;
                }
                else
                {
                    apartment.ForSale = true;
                }

                foreach (var tagDto in otherAttributes)
                {
                    var tag = this.tagRepository.All().FirstOrDefault(t => t.Name == tagDto);
                    if (tag == null)
                    {
                        tag = new Tag { Name = tagDto };
                        await this.tagRepository.AddAsync(tag);
                    }

                    apartment.Tags.Add(tag);
                }

                await this.tagRepository.SaveChangesAsync();
                foreach (var imageDto in images)
                {
                    var image = this.apartmentImagesRepository.All().FirstOrDefault(t => t.Extension == imageDto);
                    if (image == null)
                    {
                        image = new ApartmentImage { Extension = imageDto, ApartmentId = apartment.Id };
                        await this.apartmentImagesRepository.AddAsync(image);
                    }

                    apartment.Images.Add(image);
                }

                await this.apartmentsRepository.AddAsync(apartment);
                await this.apartmentsRepository.SaveChangesAsync();
                await this.apartmentImagesRepository.SaveChangesAsync();
            }
            else if (totalFloors != 0)
            {
                var house = new House
                {
                    Type = type,
                    TownId = townn.Id,
                    DistrictId = dizztrict.Id,
                    ConstructionId = conzztruction.Id,
                    BathRooms = bathRooms,
                    BedRooms = bedRooms,
                    TotalFloors = totalFloors,
                    Price = price,
                    Description = dezcription,
                    SquareMeters = squareMeters,
                    BuiltUpArea = buildUpAreea,
                };

                if (price < 10000)
                {
                    house.ForSale = false;
                }
                else
                {
                    house.ForSale = true;
                }

                foreach (var tagDto in otherAttributes)
                {
                    var tag = this.tagRepository.All().FirstOrDefault(t => t.Name == tagDto);
                    if (tag == null)
                    {
                        tag = new Tag { Name = tagDto };
                        await this.tagRepository.AddAsync(tag);
                    }

                    house.Tags.Add(tag);
                }

                await this.tagRepository.SaveChangesAsync();
                foreach (var imageDto in images)
                {
                    var image = this.houseImagesRepository.All().FirstOrDefault(t => t.Extension == imageDto);
                    if (image == null)
                    {
                        image = new HouseImage { Extension = imageDto, HouseId = house.Id };
                        await this.houseImagesRepository.AddAsync(image);
                    }

                    house.Images.Add(image);
                }

                await this.housesRepository.AddAsync(house);
                await this.housesRepository.SaveChangesAsync();
                await this.houseImagesRepository.SaveChangesAsync();
            }
            else if (bedRooms == 0)
            {
                var store = new BusinesStore
                {
                    Type = type,
                    TownId = townn.Id,
                    DistrictId = dizztrict.Id,
                    ConstructionId = conzztruction.Id,
                    BathRooms = bathRooms,
                    Price = price,
                    Description = dezcription,
                    SquareMeters = squareMeters,
                    FrontSpace = yard,
                };

                if (price < 10000)
                {
                    store.ForSale = false;
                }
                else
                {
                    store.ForSale = true;
                }
                foreach (var tagDto in otherAttributes)
                {
                    var tag = this.tagRepository.All().FirstOrDefault(t => t.Name == tagDto);
                    if (tag == null)
                    {
                        tag = new Tag { Name = tagDto };
                        await this.tagRepository.AddAsync(tag);
                    }

                    store.Tags.Add(tag);
                }

                await this.tagRepository.SaveChangesAsync();
                foreach (var imageDto in images)
                {
                    var image = this.businesStoreImagesRepository.All().FirstOrDefault(t => t.Extension == imageDto);
                    if (image == null)
                    {
                        image = new BusinesStoreImage { Extension = imageDto, BusinesStoreId = store.Id };
                        await this.businesStoreImagesRepository.AddAsync(image);
                    }

                    store.Images.Add(image);
                }

                await this.businesStoresRepository.AddAsync(store);
                await this.businesStoresRepository.SaveChangesAsync();
                await this.businesStoreImagesRepository.SaveChangesAsync();
            }
            else if (bedRooms == 0 && bathRooms == 0 && price > 10000)
            {
                var field = new Field
                {
                    Type = type,
                    TownId = townn.Id,
                    DistrictId = dizztrict.Id,
                    Price = price,
                    Description = dezcription,
                    SquareMeters = squareMeters,
                };

                foreach (var tagDto in otherAttributes)
                {
                    var tag = this.tagRepository.All().FirstOrDefault(t => t.Name == tagDto);
                    if (tag == null)
                    {
                        tag = new Tag { Name = tagDto };
                        await this.tagRepository.AddAsync(tag);
                    }

                    field.Tags.Add(tag);
                }

                await this.tagRepository.SaveChangesAsync();
                foreach (var imageDto in images)
                {
                    var image = this.fieldImagesRepository.All().FirstOrDefault(t => t.Extension == imageDto);
                    if (image == null)
                    {
                        image = new FieldImage { Extension = imageDto, FieldId = field.Id };
                        await this.fieldImagesRepository.AddAsync(image);
                    }

                    field.Images.Add(image);
                }

                await this.fieldsRepository.AddAsync(field);
                await this.fieldsRepository.SaveChangesAsync();
                await this.fieldImagesRepository.SaveChangesAsync();
            }
            else
            {
                var warehouse = new Warehouse
                {
                    Type = type,
                    TownId = townn.Id,
                    DistrictId = dizztrict.Id,
                    ConstructionId = conzztruction.Id,
                    Price = price,
                    Description = dezcription,
                    SquareMeters = squareMeters,
                };

                if (price < 10000)
                {
                    warehouse.ForSale = false;
                }
                else
                {
                    warehouse.ForSale = true;
                }

                foreach (var tagDto in otherAttributes)
                {
                    var tag = this.tagRepository.All().FirstOrDefault(t => t.Name == tagDto);
                    if (tag == null)
                    {
                        tag = new Tag { Name = tagDto };
                        await this.tagRepository.AddAsync(tag);
                    }

                    warehouse.Tags.Add(tag);
                }

                await this.tagRepository.SaveChangesAsync();
                foreach (var imageDto in images)
                {
                    var image = this.warehouseImagesRepository.All().FirstOrDefault(t => t.Extension == imageDto);
                    if (image == null)
                    {
                        image = new WarehouseImage { Extension = imageDto, WarehouseId = warehouse.Id };
                        await this.warehouseImagesRepository.AddAsync(image);
                    }

                    warehouse.Images.Add(image);
                }

                await this.warehousesRepository.AddAsync(warehouse);
                await this.warehousesRepository.SaveChangesAsync();
                await this.warehouseImagesRepository.SaveChangesAsync();
            }
        }
    }
}
