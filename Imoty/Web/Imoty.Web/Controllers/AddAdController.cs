namespace Imoty.Web.Controllers
{
    using System.Threading.Tasks;

    using Imoty.Services.Data;
    using Imoty.Web.ViewModels.AddAd;
    using Microsoft.AspNetCore.Mvc;

    public class AddAdController : BaseController
    {
        private readonly IAddApartmentService addApartmentService;
        private readonly IAddHouseService addHouseService;
        private readonly IAddFieldService addFieldService;
        private readonly IAddBusinesStoreService addBusinesStoreService;
        private readonly IAddWarehouseService addWarehouseService;

        public AddAdController(
            IAddApartmentService addApartmentService,
            IAddHouseService addHouseService,
            IAddFieldService addFieldService,
            IAddBusinesStoreService addBusinesStoreService,
            IAddWarehouseService addWarehouseService)
        {
            this.addApartmentService = addApartmentService;
            this.addHouseService = addHouseService;
            this.addFieldService = addFieldService;
            this.addBusinesStoreService = addBusinesStoreService;
            this.addWarehouseService = addWarehouseService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AddApartment()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddApartment(AddApartmentViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.addApartmentService.AddApartmentAsync(input);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult AddHouse()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHouse(AddHouseViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.addHouseService.AddHouseAsync(input);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult AddWarehouse()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWarehouse(AddWarehouseViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.addWarehouseService.AddWarehouseAsync(input);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult AddBusinesStore()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBusinesStore(AddBusinesStoreViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.addBusinesStoreService.AddBusinesStoreAsync(input);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult AddField()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddField(AddFieldViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.addFieldService.AddFieldAsync(input);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
