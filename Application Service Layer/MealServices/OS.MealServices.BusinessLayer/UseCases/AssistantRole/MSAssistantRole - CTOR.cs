﻿using OS.Common.MealServices;
using OS.Common.MealServices.Interfaces;

namespace OS.MealServices.BusinessLayer.UseCases
{
    public partial class MSAssistantRole : MSAttendeeRole, IMSAssistantRole
    {
        private readonly IMSUnitOfWork iMSUnitOfWork;

        public MSAssistantRole(IMSUnitOfWork iMSUnitOfWork) : base(iMSUnitOfWork)
        {
            this.iMSUnitOfWork = iMSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iMSUnitOfWork));
        }
    }
}
