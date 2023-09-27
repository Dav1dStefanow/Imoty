namespace Imoty.Services.Data
{
    using System.Threading.Tasks;
    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Web.ViewModels.AddAd;

    public class AddFieldService : IAddFieldService
    {
        private readonly IDeletableEntityRepository<Field> fieldsRepository;
        private readonly IRepository<FieldImage> fieldImagesRepository;

        public AddFieldService(
            IDeletableEntityRepository<Field> fieldsRepository,
            IRepository<FieldImage> fieldImagesRepository)
        {
            this.fieldsRepository = fieldsRepository;
            this.fieldImagesRepository = fieldImagesRepository;
        }

        public async Task AddFieldAsync(AddFieldViewModel viewModel)
        {
            var input = new Field
            {
                Name = viewModel.Name,
                PopulatedArea = viewModel.PopulatedArea,
                Location = viewModel.Location,
                Price = viewModel.Price,
                Description = viewModel.Description,
                SquareMeters = viewModel.SquareMeters,
            };

            await this.fieldsRepository.AddAsync(input);
            await this.fieldsRepository.SaveChangesAsync();
        }
    }
}
