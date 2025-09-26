using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManagement.WebApi.Security
{
	 public class PermissionChecker  : AuthorizeAttribute, IAsyncAuthorizationFilter
	 {
		
		  public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
		  {
			   if (HasAllowAnonymous(context))
					return;

			   if (context.HttpContext.User.Identity.IsAuthenticated)
			   {
					return ;
			   }
			   else
			   {
					context.Result = new UnauthorizedObjectResult("ابتدا وارد احراز هویت را انجام بدهید ");
			   }
		  }

		  private bool HasAllowAnonymous(AuthorizationFilterContext context)
		  {
			   var metaData = context.ActionDescriptor.EndpointMetadata.OfType<dynamic>().ToList();
			   bool hasAllowAnonymous = false;
			   foreach (var f in metaData)
			   {
					try
					{
						 hasAllowAnonymous = f.TypeId.Name == "AllowAnonymousAttribute";
						 if (hasAllowAnonymous)
							  break;
					}
					catch
					{
						 // ignored
					}
			   }

			   return hasAllowAnonymous;
		  }
		
	 }
}
