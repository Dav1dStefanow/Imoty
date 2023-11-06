namespace Imoty.Services.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Imoty.Data.Common.Repositories;
    using Imoty.Data.Models;
    using Imoty.Services.Data.Interfaces;
    using Imoty.Services.Mapping;

    public class TagService : ITagService
    {
        private readonly IDeletableEntityRepository<Tag> tagsRepository;

        public TagService(IDeletableEntityRepository<Tag> tagsRepository)
        {
            this.tagsRepository = tagsRepository;
        }

        public IEnumerable<T> GetAllTags<T>()
        {
            return this.tagsRepository.All().To<T>().ToList();
        }
    }
}
