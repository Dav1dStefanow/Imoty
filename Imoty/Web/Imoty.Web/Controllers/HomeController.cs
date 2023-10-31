namespace Imoty.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Imoty.Services;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels;
    using Imoty.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

    public class HomeController : BaseController
    {
        private readonly ISalesService salesService;
        private readonly IRentsService rentsService;
        private readonly INewBuildingsService newBuildingsService;
        private readonly IImotyBgScraperService imotyBgScraperService;
        private readonly IPropertyService propertyService;

        public HomeController(
            ISalesService salesService,
            IRentsService rentsService,
            INewBuildingsService newBuildingsService,
            IImotyBgScraperService imotyBgScraperService,
            IPropertyService propertyService)
        {
            this.salesService = salesService;
            this.rentsService = rentsService;
            this.newBuildingsService = newBuildingsService;
            this.imotyBgScraperService = imotyBgScraperService;
            this.propertyService = propertyService;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Properties = this.propertyService.GetRandom(10),
            };
            return this.View(model);
        }

        public IActionResult Sales(int id = 1)
        {
            const int ItemsPerPage = 15;

            var viewModel = new SalesRentsOrNBInListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                PropertiesCount = this.salesService.GetCount(),
                PropertiesForSale = this.salesService.GetAllSales(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult Rents(int id = 1)
        {
            const int ItemsPerPage = 15;

            var viewModel = new SalesRentsOrNBInListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                PropertiesCount = this.rentsService.GetCount(),
                PropertiesForSale = this.rentsService.GetAllSales(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult NewBuilding(int id = 1)
        {
            const int ItemsPerPage = 15;

            var viewModel = new SalesRentsOrNBInListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                PropertiesCount = this.newBuildingsService.GetCount(),
                PropertiesForSale = this.newBuildingsService.GetAllNewBuildings(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult ScrapData()
        {
            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ScrapData(ScrapDataViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.imotyBgScraperService.PopulateDbWithProperiesAsync(viewModel.PropertyLink);
            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ViewProperty(int id, string category)
        {
            var property = this.propertyService.GetByIdAndCategory(id, category);
            return this.View(property);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
