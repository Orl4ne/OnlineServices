using OS.Common.DataAccessHelpers;
using OS.Common.MealServices.TransfertObjects;

using System.Collections.Generic;

namespace OS.Common.MealServices.Interfaces
{
    public interface IMealRepository : IRepository<MealTO, int>
    {
        List<MealTO> GetMealsBySupplier(SupplierTO Supplier);
        List<MealTO> GetMealsByIngredient(List<IngredientTO> Ingredients);
        List<MealTO> GetMealsWithoutIngredient(List<IngredientTO> Ingredients);
    }
}
