using eDiary.API.Models.BusinessObjects;
using System;
using System.Linq;
using System.Web.Mvc;

namespace eDiary.API.Services.Tasks.Filters
{
    public class VerifySectionCard : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters.SingleOrDefault(p => p.Value is SectionCard);

            if (!(param.Value is SectionCard card)) throw new ArgumentNullException(nameof(card));
            if (card.Name == null) throw new ArgumentNullException(nameof(card.Name));
        }
    }
}
