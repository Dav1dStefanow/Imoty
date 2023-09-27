namespace Imoty.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Imoty.Data;
    using Imoty.Data.Models;
    using Imoty.Web.ViewModels.AddAd;

    public interface IAddApartmentService
    {
        Task AddApartmentAsync(AddApartmentViewModel viewModel);
    }
}
