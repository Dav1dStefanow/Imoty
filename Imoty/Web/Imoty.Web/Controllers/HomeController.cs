namespace Imoty.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using Imoty.Data;
    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Data.Models.ImageModels;
    using Imoty.Services.Data;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels;
    using Imoty.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class HomeController : BaseController
    {
        private readonly ISalesService salesService;

        public HomeController(ISalesService salesService)
        {
            this.salesService = salesService;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
