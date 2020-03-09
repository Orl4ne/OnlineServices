using OS.Common.MealServices.TransfertObjects;

using System.Collections.Generic;

namespace OS.Common.MealServices
{
    public interface IMSAttendeeRole
    {
        List<MealTO> GetMenu();
    }
}