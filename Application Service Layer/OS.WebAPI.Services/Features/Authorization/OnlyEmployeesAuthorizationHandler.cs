using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.WebAPI.Services.Features.Authorization
{
    public class OnlyEmployeesAuthorizationHandler : AuthorizationHandler<OnlyEmployeesRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyEmployeesRequirement requirement)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));
            if (requirement is null)
                throw new ArgumentNullException(nameof(requirement));

            if (context.User.IsInRole(Roles.Employee))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}