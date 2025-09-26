using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.EndPoint
{
	 public static class ClaimUtils
	 {
		  public static Guid GetUserId(this ClaimsPrincipal principal)
		  {
			   if (principal == null)
					throw new ArgumentNullException(nameof(principal));

			   return Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
		  }
	 }
}
