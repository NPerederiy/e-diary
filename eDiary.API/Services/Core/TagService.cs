using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Core.Interfaces;
using eDiary.API.Services.Validation;
using eDiary.API.Util;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = eDiary.API.Models.Entities;

namespace eDiary.API.Services.Core
{
    public class TagService : BaseService, ITagService
    {
        private readonly IUnitOfWork uow;

        public TagService()
        {
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }

        public async Task<IEnumerable<TagBO>> GetAllTagsAsync()
        {
            var tasks = await uow.TagRepository.GetAllAsync();
            return from t in tasks select new TagBO(t);
        }

        public async Task<TagBO> GetTagAsync(int id)
        {
            return new TagBO(await FindEntityAsync(uow.TagRepository, x => x.Id == id));
        }
        
        public async Task CreateTagAsync(TagBO tag)
        {
            Validate.NotNull(tag, nameof(tag));
            var t = new Entities.Tag
            {
                Name = tag.Name
            };
            await uow.TagRepository.CreateAsync(t);
        }
        
        public async Task UpdateTagAsync(TagBO tag)
        {
            Validate.NotNull(tag, nameof(tag));
            var t = await FindEntityAsync(uow.TagRepository, x => x.Id == tag.TagId);
            t.Name = tag.Name;
            uow.TagRepository.Update(t);
        }

        public async Task DeleteTagAsync(int id)
        {
            uow.TagRepository.Delete(await FindEntityAsync(uow.TagRepository, x => x.Id == id));
        }
    }
}
