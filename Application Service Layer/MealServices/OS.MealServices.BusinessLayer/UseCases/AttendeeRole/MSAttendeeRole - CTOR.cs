using OS.Common.MealServices;
using OS.Common.MealServices.Interfaces;
using System;

namespace OS.MealServices.BusinessLayer.UseCases
{
    public partial class MSAttendeeRole : IMSAttendeeRole
    {
        private readonly IMSUnitOfWork iMSUnitOfWork;

        public MSAttendeeRole(IMSUnitOfWork iMSUnitOfWork)
        {
            this.iMSUnitOfWork = iMSUnitOfWork ?? throw new ArgumentNullException(nameof(iMSUnitOfWork));
        }
    }
}
