using eDiary.API.Models.BusinessObjects;
using System;
using System.Linq;
using System.Web.Mvc;

namespace eDiary.API.Services.Tasks.Filters
{
    public class VerifyTaskCard : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters.SingleOrDefault(p => p.Value is TaskCard);

            if (!(param.Value is TaskCard card)) throw new ArgumentNullException(nameof(card));
            if (card.Header == null) throw new ArgumentNullException(nameof(card.Header));
            if (card.TaskStatus == null) throw new ArgumentNullException(nameof(card.TaskStatus));
            if (card.CardStatus == null) throw new ArgumentNullException(nameof(card.CardStatus));
            if (card.Priority == null) throw new ArgumentNullException(nameof(card.Priority));
            if (card.Difficulty == null) throw new ArgumentNullException(nameof(card.Difficulty));
            if (card.CreatedAt == null) throw new ArgumentNullException(nameof(card.CreatedAt));
            if (card.UpdatedAt == null) throw new ArgumentNullException(nameof(card.UpdatedAt));
        }
    }
}
