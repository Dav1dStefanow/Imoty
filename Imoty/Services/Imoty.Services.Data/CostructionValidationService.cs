namespace Imoty.Services.Data
{
    using System.Linq;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Web.ViewModels.AddAd;

    public class CostructionValidationService
    {
        private readonly IDeletableEntityRepository<Construction> constructionsRepository;

        public CostructionValidationService(IDeletableEntityRepository<Construction> constructionsRepository)
        {
            this.constructionsRepository = constructionsRepository;
        }

        public Construction ValidateConstruction(AddApartmentViewModel viewModel)
        {
            if (!this.constructionsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Construction))
            {
                this.constructionsRepository.AddAsync(new Construction { Name = viewModel.Construction });
            }

            this.constructionsRepository.SaveChangesAsync();

            Construction construction = this.constructionsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Construction);

            return construction;
        }

        public Construction ValidateConstruction(AddHouseViewModel viewModel)
        {
            if (!this.constructionsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Construction))
            {
                this.constructionsRepository.AddAsync(new Construction { Name = viewModel.Construction });
            }

            this.constructionsRepository.SaveChangesAsync();

            Construction construction = this.constructionsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Construction);

            return construction;
        }

        public Construction ValidateConstruction(AddBusinesStoreViewModel viewModel)
        {
            if (!this.constructionsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Construction))
            {
                this.constructionsRepository.AddAsync(new Construction { Name = viewModel.Construction });
            }

            this.constructionsRepository.SaveChangesAsync();

            Construction construction = this.constructionsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Construction);

            return construction;
        }

        public Construction ValidateConstruction(AddWarehouseViewModel viewModel)
        {
            if (!this.constructionsRepository.AllAsNoTrackingWithDeleted().Any(c => c.Name == viewModel.Construction))
            {
                this.constructionsRepository.AddAsync(new Construction { Name = viewModel.Construction });
            }

            this.constructionsRepository.SaveChangesAsync();

            Construction construction = this.constructionsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(c => c.Name == viewModel.Construction);

            return construction;
        }
    }
}
