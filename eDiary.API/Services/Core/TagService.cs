using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
using eDiary.API.Services.Core.Interfaces;
using eDiary.API.Services.Validation;

namespace eDiary.API.Services.Core
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork uow;

        public TagService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<TagBO>> GetAllTagsAsync()
        {
            var tasks = await uow.TagRepository.GetAllAsync();
            return from t in tasks select new TagBO(t);
        }

        public async Task<TagBO> GetTagAsync(int id)
        {
            return new TagBO(await TryFindTag(id));
        }
        
        public async System.Threading.Tasks.Task CreateTagAsync(TagBO tag)
        {
            Validate.NotNull(tag, nameof(tag));
            var t = new Tag
            {
                Name = tag.Name
            };
            await uow.TagRepository.CreateAsync(t);
        }
        
        public async System.Threading.Tasks.Task UpdateTagAsync(TagBO tag)
        {
            Validate.NotNull(tag, nameof(tag));
            var t = await TryFindTag(tag.TagId);
            t.Name = tag.Name;
            uow.TagRepository.Update(t);
        }

        public async System.Threading.Tasks.Task DeleteTagAsync(int id)
        {
            uow.TagRepository.Delete(await TryFindTag(id));
        }

        private async Task<Tag> TryFindTag(int id)
        {
            var tag = (await uow.TagRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (tag == null) throw new Exception("Tag not found");
            return tag;
        }
    }
}
