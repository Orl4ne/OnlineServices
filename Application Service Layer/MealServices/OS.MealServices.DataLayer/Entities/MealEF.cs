using OS.Common.DataAccessHelpers;
using OS.Common.MealServices.Enumerations;
using OS.Common.TranslationServices;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OS.MealServices.DataLayer.Entities
{
    [Table("Meals")]
    public class MealEF : IEntity<int>, IMultiLanguageNameFields
    {
        [Key]
        public int Id { get; set; }

        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }

        public MealType MealType { get; set; }

        public SupplierEF Supplier { get; set; }

        public IList<MealCompositionEF> MealsComposition { get; set; }
    }
}