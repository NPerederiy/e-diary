using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Calendar.Interfaces;

namespace eDiary.API.Services.Calendar
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
