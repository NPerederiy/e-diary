using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
using eDiary.API.Services.Core.Filters;
using eDiary.API.Services.Core.Interfaces;

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

        [VerifyTag]
        public async void CreateTagAsync(TagBO tag)
        {
            var t = new Tag
            {
                Name = tag.Name
            };
            await uow.TagRepository.CreateAsync(t);
        }

        [VerifyTag]
        public async void UpdateTagAsync(TagBO tag)
        {
            var t = await TryFindTag(tag.TagId);
            t.Name = tag.Name;
            uow.TagRepository.Update(t);
        }

        public async void DeleteTagAsync(int id)
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
