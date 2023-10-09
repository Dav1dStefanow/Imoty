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

        public SalesService(IDeletableEntityRepository<Apartment> apartmentsRepository)
        {
            this.apartmentsRepository = apartmentsRepository;
        }

        public IEnumerable<PropertyForSaleViewModel> GetAllSales(int page, int itemsNumber = 15)
        {
            var properties = this.apartmentsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsNumber).Take(itemsNumber)
                .Select(x => new PropertyForSaleViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    CategoryName = nameof(Apartment),
                }).ToList();
            return properties;
        }
    }
}
