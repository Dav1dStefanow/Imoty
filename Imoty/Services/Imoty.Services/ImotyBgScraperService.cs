namespace Imoty.Services
{
    using System;

    using AngleSharp;

    internal class ImotyBgScraperService : IImotyBgScraperService
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;

        public ImotyBgScraperService()
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
        }

        public void PopulateDbWithProperies()
        {
            throw new NotImplementedException();
        }
    }
}
