namespace Imoty.Web.Controllers
{
    using Imoty.Services.Data;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.Home;
    using Imoty.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : BaseController
    {
        private readonly TownValidationService townValidationService;
        private readonly DistrictValidationService districtValidationService;
        private readonly ITagService tagService;
        private readonly IPropertyService propertyService;

        public SearchController(
            TownValidationService townValidationService,
            DistrictValidationService districtValidationService,
            ITagService tagService,
            IPropertyService propertyService)
        {
            this.townValidationService = townValidationService;
            this.districtValidationService = districtValidationService;
            this.tagService = tagService;
            this.propertyService = propertyService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
               Tags = this.tagService.GetAllTags<SearchTagsViewModel>(),
               //Towns = this.townValidationService.GetAllTowns<SearchTownsViewModel>(),
               //Districts = this.districtValidationService.GetAllDistricts<SearchDistrictsViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult List(SearchListInputModel model)
        {
           var viewModel = new ListViewModel
           {
                Properties = this.propertyService.GetByTagsAndType<PropertyForSaleRentInListViewModel>(model.Tags, model.SearchInput),
           };

           return this.View(viewModel);
        }
    }
}
