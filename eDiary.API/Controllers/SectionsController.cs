using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Tasks.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eDiary.API.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ISectionService ss;

        public SectionsController(ISectionService ss)
        {
            this.ss = ss;
        }

        // GET api/categories
        [HttpGet]
        [Authenticated]
        public async Task<IEnumerable<SectionCard>> GetAllSections()
        {
            return await ss.GetAllSectionsAsync();
        }

        // GET api/categories/1
        [HttpGet]
        [Authenticated]
        public async Task<SectionCard> GetSectionById(int id)
        {
            return await ss.GetSectionAsync(id);
        }

        // POST api/categories 
        [HttpPost]
        [Authenticated]
        public void CreateSection(SectionCard section)
        {
            ss.CreateSection(section);
        }

        // PUT api/categories/1 
        [HttpPut]
        [Authenticated]
        public void UpdateSection(SectionCard section)
        {
            ss.UpdateSection(section);
        }

        // DELETE api/categories/1 
        [HttpDelete]
        [Authenticated]
        public void DeleteSectionById(int id)
        {
            ss.DeleteSection(id);
        }
    }
}
