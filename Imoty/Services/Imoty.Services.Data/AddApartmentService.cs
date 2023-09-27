namespace Imoty.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Web.ViewModels.AddAd;

    public class AddApartmentService : IAddApartmentService
    {
        private readonly IDeletableEntityRepository<Construction> constructionsRepository;
        private readonly IDeletableEntityRepository<Apartment> apartmentsRepository;
        private readonly IRepository<ApartmentImage> apartmentImagesRepository;

        public AddApartmentService(
            IDeletableEntityRepository<Construction> constructionsRepository,
            IDeletableEntityRepository<Apartment> apartmentsRepository,
            IRepository<ApartmentImage> apartmentImagesRepository)
        {
            this.constructionsRepository = constructionsRepository;
            this.apartmentsRepository = apartmentsRepository;
            this.apartmentImagesRepository = apartmentImagesRepository;
        }

        public async Task AddApartmentAsync(AddApartmentViewModel viewModel)
        {
            if (!this.constructionsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Construction))
            {
                await this.constructionsRepository.AddAsync(new Construction { Name = viewModel.Construction });
            }

            await this.constructionsRepository.SaveChangesAsync();

            Construction construction = this.constructionsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Construction);

            var input = new Apartment
            {
                PopulatedArea = viewModel.PopulatedArea,
                Location = viewModel.Location,
                BathRooms = viewModel.BathRooms,
                BedRooms = viewModel.BedRooms,
                Garages = viewModel.Garages,
                TotalFloors = viewModel.TotalFloors,
                ConstructionId = construction.Id,
                Floor = viewModel.Floor,
                Price = viewModel.Price,
                Description = viewModel.Description,
                SquareMeters = viewModel.SquareMeters,
            };

            await this.apartmentsRepository.AddAsync(input);
            await this.apartmentsRepository.SaveChangesAsync();
        }
    }
}
