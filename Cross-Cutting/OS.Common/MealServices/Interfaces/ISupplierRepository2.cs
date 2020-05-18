using OS.Common.DataAccessHelpers;
using OS.Common.MealServices.TransfertObjects;

namespace OS.Common.MealServices.Interfaces
{
    public interface ISupplierRepository2 : IRepositoryDO_NOT_USE<SupplierTO, int>
    {
        SupplierTO GetDefaultSupplier();
        void SetDefaultSupplier(SupplierTO Supplier);
    }
}
