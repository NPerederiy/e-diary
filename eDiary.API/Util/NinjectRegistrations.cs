using eDiary.API.Models.EF;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Calendar;
using eDiary.API.Services.Calendar.Interfaces;
using eDiary.API.Services.Core;
using eDiary.API.Services.Core.Interfaces;
using eDiary.API.Services.Notes;
using eDiary.API.Services.Notes.Interfaces;
using eDiary.API.Services.Security;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Services.Tasks;
using eDiary.API.Services.Tasks.Interfaces;
using Ninject.Modules;

namespace eDiary.API.Util
{
    public class NinjectRegistrations: NinjectModule
    {
        public override void Load()
        {
            // EF 
            Bind<IUnitOfWork>().To<UnitOfWork<BasicDiaryDbContext>>();

            // Core
            Bind<IUserService>().To<UserService>();
            Bind<ITagService>().To<TagService>();

            // Security
            Bind<IIdentityService>().To<IdentityService>();
            Bind<ICryptographyService>().To<CryptographyService>();
            Bind<IOperationResult>().To<OperationResult>();

            // Tasks page
            Bind<ITaskService>().To<TaskService>();
            Bind<ISectionService>().To<SectionService>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectCategoryService>().To<ProjectCategoryService>();

            // Notes page 
            Bind<INoteService>().To<NoteService>();

            // Calendar page 
            Bind<ICalendarService>().To<CalendarService>();
        }
    }
}
