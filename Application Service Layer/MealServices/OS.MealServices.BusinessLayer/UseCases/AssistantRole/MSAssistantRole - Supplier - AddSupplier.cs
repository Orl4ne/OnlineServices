﻿using OS.MealServices.BusinessLayer.Extensions;

using OS.Common.MealServices.TransfertObjects;

using System;

namespace OS.MealServices.BusinessLayer.UseCases
{
    public partial class MSAssistantRole
    {
        public bool AddSupplier(SupplierTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));

            if (Supplier.Id != 0)
                throw new Exception("Existing supplier");

            try
            {

                iMSUnitOfWork.SupplierRepository.Add(Supplier.ToDomain().ToTransfertObject());

                if (Supplier.IsDefault)
                    iMSUnitOfWork.SupplierRepository.SetDefaultSupplier(Supplier.ToDomain().ToTransfertObject());

                return true;
            }

            //TODO Code to test Unique Constraint on Name...
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
