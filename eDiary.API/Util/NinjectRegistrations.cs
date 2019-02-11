using eDiary.API.Models.EF;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services;
using eDiary.API.Services.Interfaces;
using Ninject.Modules;

namespace eDiary.API.Util
{
    public class NinjectRegistrations: NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork<BasicDiaryDbContext>>();
            Bind<ITaskService>().To<TaskService>();
            Bind<INoteService>().To<NoteService>();
            Bind<ICalendarService>().To<CalendarService>();
        }
    }
}
