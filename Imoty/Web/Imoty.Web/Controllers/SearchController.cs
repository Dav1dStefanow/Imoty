namespace Imoty.Web.Controllers
{
    using Imoty.Services.Data.Interfaces;
    using Imoty.Web.ViewModels.Home;
    using Imoty.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : BaseController
    {
        private readonly ITagService tagService;
        private readonly IPropertyService propertyService;

        public SearchController(
            ITagService tagService,
            IPropertyService propertyService)
        {
            this.tagService = tagService;
            this.propertyService = propertyService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
               Tags = this.tagService.GetAllTags<SearchTagsViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult List(SearchListInputModel model)
        {
           var viewModel = new ListViewModel
           {
                Properties = this.propertyService.GetByTags<PropertyForSaleRentInListViewModel>(model.Tags),
           };

           return this.View(viewModel);
        }
    }
}
