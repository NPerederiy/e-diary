using eDiary.API.Services.Validation;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace eDiary.API.Filters
{
    public static class HttpAuthenticationChallengeContextExtensions
    {
        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme));
        }

        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme, string parameter)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme, parameter));
        }

        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, AuthenticationHeaderValue challenge)
        {
            if (context == null)
            {
                Validate.NotNull(context, nameof(context));
                //throw new ArgumentNullException(nameof(context));
            }

            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
        }
    }
}
