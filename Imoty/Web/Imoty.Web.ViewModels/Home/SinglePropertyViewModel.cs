namespace Imoty.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using AutoMapper;
    using Imoty.Data.Models;
    using Imoty.Services.Mapping;

    public class SinglePropertyViewModel : IMapFrom<Apartment>, IMapFrom<House>, IMapFrom<Warehouse>, IMapFrom<Field>, IMapFrom<BusinesStore>, IHaveCustomMappings
    {
        public SinglePropertyViewModel()
        {
            this.ImageUrls = new List<string>();
            this.Tags = new List<string>();
        }

        public string CategoryName { get; set; }

        public string Type { get; set; }

        public string TownName { get; set; }

        public string DistrictName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ConstructionName { get; set; }

        public int SquareMeters { get; set; }

        public int BuiltUpArea { get; set; }

        public int BedRooms { get; set; }

        public int BathRooms { get; set; }

        public int TotalFloors { get; set; }

        public int Floor { get; set; }

        public ICollection<string> ImageUrls { get; set; }

        public ICollection<string> Tags { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BusinesStore, SinglePropertyViewModel>()
                 .ForMember(c => c.Tags, opt => opt.MapFrom(x => x.Tags))
                 .ForMember(c => c.ImageUrls, opt => opt.MapFrom(x => x.Images));
            configuration.CreateMap<Apartment, SinglePropertyViewModel>()
                .ForMember(c => c.Tags, opt => opt.MapFrom(x => x.Tags))
                .ForMember(c => c.ImageUrls, opt => opt.MapFrom(x => x.Images));
            configuration.CreateMap<House, SinglePropertyViewModel>()
                .ForMember(c => c.Tags, opt => opt.MapFrom(x => x.Tags))
                .ForMember(c => c.ImageUrls, opt => opt.MapFrom(x => x.Images));
            configuration.CreateMap<Field, SinglePropertyViewModel>()
                .ForMember(c => c.Tags, opt => opt.MapFrom(x => x.Tags))
                .ForMember(c => c.ImageUrls, opt => opt.MapFrom(x => x.Images));
            configuration.CreateMap<Warehouse, SinglePropertyViewModel>()
                .ForMember(c => c.Tags, opt => opt.MapFrom(x => x.Tags))
                .ForMember(c => c.ImageUrls, opt => opt.MapFrom(x => x.Images));
        }
    }
}
