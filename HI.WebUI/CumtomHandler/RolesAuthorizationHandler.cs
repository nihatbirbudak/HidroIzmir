using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using HI.WebUI.Core;

namespace HI.WebUI.CumtomHandler
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            RolesAuthorizationRequirement requirement)
        {

            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            var validRole = false;

            if (requirement.AllowedRoles == null ||
               requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
                var claims = context.User.Claims;
                var CustomerDTO = HIConvert.HIJsonDeSerializeUser(claims.FirstOrDefault(z => z.Type == "User").Value);
                var roles = requirement.AllowedRoles;


                if (roles.Contains(CustomerDTO.Role.RoleName))
                {
                    validRole = true;
                }


            }
            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;

        }
    }
}
