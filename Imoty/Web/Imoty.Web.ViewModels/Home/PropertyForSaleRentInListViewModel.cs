namespace Imoty.Web.ViewModels.Home
{
    using AutoMapper;
    using Imoty.Data.Models;
    using Imoty.Services.Mapping;

    public class PropertyForSaleRentInListViewModel : IMapFrom<Apartment>, IMapFrom<House>, IMapFrom<Field>, IMapFrom<Warehouse>, IMapFrom<BusinesStore>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Type { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BusinesStore, PropertyForSaleRentInListViewModel>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(x => nameof(BusinesStore)));
            configuration.CreateMap<Warehouse, PropertyForSaleRentInListViewModel>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(x => nameof(Warehouse)));
            configuration.CreateMap<Apartment, PropertyForSaleRentInListViewModel>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(x => nameof(Apartment)));
            configuration.CreateMap<House, PropertyForSaleRentInListViewModel>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(x => nameof(House)));
            configuration.CreateMap<Field, PropertyForSaleRentInListViewModel>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(x => nameof(Field)));
        }
    }
}
