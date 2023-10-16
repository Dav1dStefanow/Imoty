namespace Imoty.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Imoty.Data.Models;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.AddAd;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AddAdController : BaseController
    {
        private readonly IAddApartmentService addApartmentService;
        private readonly IAddHouseService addHouseService;
        private readonly IAddFieldService addFieldService;
        private readonly IAddBusinesStoreService addBusinesStoreService;
        private readonly IAddWarehouseService addWarehouseService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public AddAdController(
            IAddApartmentService addApartmentService,
            IAddHouseService addHouseService,
            IAddFieldService addFieldService,
            IAddBusinesStoreService addBusinesStoreService,
            IAddWarehouseService addWarehouseService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.addApartmentService = addApartmentService;
            this.addHouseService = addHouseService;
            this.addFieldService = addFieldService;
            this.addBusinesStoreService = addBusinesStoreService;
            this.addWarehouseService = addWarehouseService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult AddApartment()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddApartment(AddApartmentViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.addApartmentService.AddApartmentAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("ThankYou");
        }

        [Authorize]
        public IActionResult AddHouse()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddHouse(AddHouseViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.addHouseService.AddHouseAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("ThankYou");
        }

        [Authorize]
        public IActionResult AddWarehouse()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddWarehouse(AddWarehouseViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.addWarehouseService.AddWarehouseAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("ThankYou");
        }

        [Authorize]
        public IActionResult AddBusinesStore()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddBusinesStore(AddBusinesStoreViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.addBusinesStoreService.AddBusinesStoreAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("ThankYou");
        }

        [Authorize]
        public IActionResult AddField()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddField(AddFieldViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.addFieldService.AddFieldAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
