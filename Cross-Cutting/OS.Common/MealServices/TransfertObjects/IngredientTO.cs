using OS.Common.DataAccessHelpers;
using OS.Common.TranslationServices.TransfertObjects;

namespace OS.Common.MealServices.TransfertObjects
{
    public class IngredientTO : IEntity<int>
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public bool IsAllergen { get; set; }
    }

}
