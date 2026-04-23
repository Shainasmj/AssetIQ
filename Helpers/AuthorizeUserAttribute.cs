using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AssetIQ.Constants;

namespace AssetIQ.Helpers
{
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userEmail = context.HttpContext.Session.GetString(SessionConstants.UserEmail);

            if (string.IsNullOrEmpty(userEmail))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
                return;
            }

            if (!string.IsNullOrEmpty(Role))
            {
                var userRole = context.HttpContext.Session.GetString(SessionConstants.UserRole);

                if (userRole != Role)
                {
                    context.Result = new ContentResult
                    {
                        Content = "Access Denied"
                    };
                }
            }
        }
    }
}