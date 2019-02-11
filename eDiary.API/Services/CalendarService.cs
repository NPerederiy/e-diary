using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Interfaces;

namespace eDiary.API.Services
{
    public class CalendarService: ICalendarService
    {
        private readonly IUnitOfWork uow;

        public CalendarService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
