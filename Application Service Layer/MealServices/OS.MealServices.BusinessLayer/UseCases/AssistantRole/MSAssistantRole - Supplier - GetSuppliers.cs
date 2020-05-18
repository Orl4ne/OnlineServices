﻿using OS.MealServices.BusinessLayer.Extensions;

using OS.Common.MealServices.TransfertObjects;

using System.Collections.Generic;
using System.Linq;

namespace OS.MealServices.BusinessLayer.UseCases
{
    public partial class MSAssistantRole
    {
        public List<SupplierTO> GetSuppliers()
            => iMSUnitOfWork.SupplierRepository
                    .GetAll()
                    .Select(x => x.ToDomain().ToTransfertObject())
                    .ToList();
        //TODO Comment to students Try..Catch if not connected to db?
    }
}
