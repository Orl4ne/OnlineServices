﻿using OS.Common.DataAccessHelpers;
using OS.Common.TranslationServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OS.MealServices.DataLayer.Entities
{
    [Table("Ingredients")]
    public class IngredientEF: IEntity<int>, IMultiLanguageNameFields
    {
        [Key]
        public int Id{get;set;}
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public bool IsAllergen { get; set; }

        public IList<MealCompositionEF> MealsWithIngredient { get; set; }
    }

}
