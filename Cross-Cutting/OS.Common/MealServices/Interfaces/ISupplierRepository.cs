using OS.Common.DataAccessHelpers;
using OS.Common.MealServices.TransfertObjects;

namespace OS.Common.MealServices.Interfaces
{
    public interface ISupplierRepository : IRepository<SupplierTO, int>
    {
        SupplierTO GetDefaultSupplier();
        void SetDefaultSupplier(SupplierTO Supplier);
    }
}
