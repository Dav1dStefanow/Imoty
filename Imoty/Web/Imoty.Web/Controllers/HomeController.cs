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
        private readonly IImotyBgScraperService imotyBgScraperService;

        public HomeController(
            ISalesService salesService,
            IImotyBgScraperService imotyBgScraperService)
        {
            this.salesService = salesService;
            this.imotyBgScraperService = imotyBgScraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Agiencies()
        {
            return this.View();
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        public IActionResult Sales(int id = 1)
        {
            var viewModel = new SalesInListViewModel
            {
                PageNumber = id,
                PropertiesForSale = this.salesService.GetAllSales(id, 15),
            };
            return this.View(viewModel);
        }

        public IActionResult Rents()
        {
            return this.View();
        }

        public IActionResult NewBuilding()
        {
            return this.View();
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
