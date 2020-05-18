using OS.Common.DataAccessHelpers;
using OS.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;

namespace OS.Common.FacilityServices.TransfertObjects
{
    public class ComponentTypeTO : IEntity<int>
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public bool Archived { get; set; }
    }
}
