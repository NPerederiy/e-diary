using eDiary.API.Models.EF;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Calendar;
using eDiary.API.Services.Calendar.Interfaces;
using eDiary.API.Services.Note;
using eDiary.API.Services.Note.Interfaces;
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
            Bind<IUnitOfWork>().To<UnitOfWork<BasicDiaryDbContext>>();
            Bind<IIdentityService>().To<IdentityService>();
            Bind<ICryptographyService>().To<CryptographyService>();
            Bind<ITaskService>().To<TaskService>();
            Bind<ISectionService>().To<SectionService>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectCategoryService>().To<ProjectCategoryService>();
            Bind<INoteService>().To<NoteService>();
            Bind<ICalendarService>().To<CalendarService>();
            Bind<IOperationResult>().To<OperationResult>();
        }
    }
}
