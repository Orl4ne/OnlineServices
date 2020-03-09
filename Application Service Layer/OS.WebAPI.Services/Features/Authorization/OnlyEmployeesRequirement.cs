using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.WebAPI.Services.Features.Authorization
{
    public class OnlyEmployeesRequirement : IAuthorizationRequirement
    {
    }
}
