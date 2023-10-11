namespace Imoty.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Imoty.Data;
    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Services;
    using Imoty.Services.Data;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels;
    using Imoty.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class HomeController : BaseController
    {
        private readonly ISalesService salesService;
        private readonly IRentsService rentsService;
        private readonly INewBuildingsService newBuildingsService;
        private readonly IImotyBgScraperService imotyBgScraperService;

        public HomeController(
            ISalesService salesService,
            IRentsService rentsService,
            INewBuildingsService newBuildingsService,
            IImotyBgScraperService imotyBgScraperService)
        {
            this.salesService = salesService;
            this.rentsService = rentsService;
            this.newBuildingsService = newBuildingsService;
            this.imotyBgScraperService = imotyBgScraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult ThankYou()
        {
            return this.View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
