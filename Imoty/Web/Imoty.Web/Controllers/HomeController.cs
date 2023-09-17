namespace Imoty.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using Imoty.Data;
    using Imoty.Web.ViewModels;
    using Imoty.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModelIntro()
            {
                Year = DateTime.UtcNow.Year,
                Date = DateTime.UtcNow,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModelIntro input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        public IActionResult Agiencies()
        {
            return this.View();
        }

        public IActionResult AddAd()
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
