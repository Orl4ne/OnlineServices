﻿using OS.MealServices.BusinessLayer.Extensions;

using OS.Common.MealServices.TransfertObjects;

using System;

namespace OS.MealServices.BusinessLayer.UseCases
{
    public partial class MSAssistantRole
    {
        public bool RemoveSupplier(SupplierTO Supplier)
        {
            try
            {
                if (Supplier is null)
                    throw new ArgumentNullException(nameof(Supplier));

                if (Supplier.Id == 0)
                    throw new Exception("Supplier not in DB.");

                iMSUnitOfWork.SupplierRepository.Remove(Supplier.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
