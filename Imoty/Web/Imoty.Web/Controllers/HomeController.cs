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
    using Imoty.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class HomeController : BaseController
    {
        private readonly IAddApartmentService addPropertyService;
        private readonly ApplicationDbContext dbContext;

        public HomeController(
            IAddApartmentService addPropertyService,
            ApplicationDbContext dbContext)
        {
            this.addPropertyService = addPropertyService;
            this.dbContext = dbContext;
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

        public IActionResult Sales()
        {
            return this.View();
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
