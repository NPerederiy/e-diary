using eDiary.API.Models.BusinessObjects;
using System;
using System.Linq;
using System.Web.Mvc;

namespace eDiary.API.Services.Notes.Filters
{
    public class VerifyNoteCard : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters.SingleOrDefault(p => p.Value is NoteCard);

            if (!(param.Value is NoteCard card)) throw new ArgumentNullException(nameof(card));
            if (card.Header == null) throw new ArgumentNullException(nameof(card.Header));
            if (card.CardStatus == null) throw new ArgumentNullException(nameof(card.CardStatus));
            if (card.CreatedAt == null) throw new ArgumentNullException(nameof(card.CreatedAt));
            if (card.UpdatedAt == null) throw new ArgumentNullException(nameof(card.UpdatedAt));
        }
    }
}
