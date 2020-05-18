using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.WebAPI.Services.Features.Authorization
{
    public static class Policies
    {
        public const string OnlyEmployees = nameof(OnlyEmployees);
        public const string OnlyManagers = nameof(OnlyManagers);
        public const string OnlyThirdParties = nameof(OnlyThirdParties);
    }
}
