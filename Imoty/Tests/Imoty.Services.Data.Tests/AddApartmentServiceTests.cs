namespace Imoty.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Web.ViewModels.AddAd;
    using Moq;
    using Xunit;

    public class AddApartmentServiceTests
    {
        [Fact]
        public async Task ApartmentRepositoryCountShouldBe1AsREsult()
        {
            var list = new List<Apartment>();
            var mockRepo = new Mock<IDeletableEntityRepository<Apartment>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Apartment>())).Callback((Apartment apartment) => list.Add(apartment));

            var imageList = new List<ApartmentImage>();
            var mockImageRepo = new Mock<IRepository<ApartmentImage>>();
            mockImageRepo.Setup(x => x.All()).Returns(imageList.AsQueryable());
            mockImageRepo.Setup(x => x.AddAsync(It.IsAny<ApartmentImage>())).Callback((ApartmentImage image) => imageList.Add(image));

            var tagList = new List<Tag>();
            var mockTagRepo = new Mock<IDeletableEntityRepository<Tag>>();
            mockTagRepo.Setup(x => x.All()).Returns(tagList.AsQueryable());
            mockTagRepo.Setup(x => x.AddAsync(It.IsAny<Tag>())).Callback((Tag tag) => tagList.Add(tag));

            var constructionList = new List<Construction>();
            var mockConsRepo = new Mock<IDeletableEntityRepository<Construction>>();
            mockConsRepo.Setup(x => x.All()).Returns(constructionList.AsQueryable());
            mockConsRepo.Setup(x => x.AddAsync(It.IsAny<Construction>())).Callback((Construction construction) => constructionList.Add(construction));

            var townList = new List<Town>();
            var mockTownRepo = new Mock<IDeletableEntityRepository<Town>>();
            mockTownRepo.Setup(x => x.All()).Returns(townList.AsQueryable());
            mockTownRepo.Setup(x => x.AddAsync(It.IsAny<Town>())).Callback((Town town) => townList.Add(town));

            var districtList = new List<District>();
            var mockDisRepo = new Mock<IDeletableEntityRepository<District>>();
            mockDisRepo.Setup(x => x.All()).Returns(districtList.AsQueryable());
            mockDisRepo.Setup(x => x.AddAsync(It.IsAny<District>())).Callback((District dis) => districtList.Add(dis));

            var validateConstructionService = new CostructionValidationService(mockConsRepo.Object);
            var townValidationService = new TownValidationService(mockTownRepo.Object);
            var districtValidationService = new DistrictValidationService(mockDisRepo.Object);

            var service = new AddApartmentService(mockRepo.Object, mockImageRepo.Object, validateConstructionService, townValidationService, districtValidationService, mockTagRepo.Object);



            var apartmentModel = new AddApartmentViewModel
            {
                Type = "4-стаен апартамент",
                Town = "Pazardzik",
                District = "Center",
            };

            await service.AddApartmentAsync(apartmentModel, "1", "dadadasasdadasd.jpg");

            Assert.Equal(1, list.Count());
        }
    }
}
