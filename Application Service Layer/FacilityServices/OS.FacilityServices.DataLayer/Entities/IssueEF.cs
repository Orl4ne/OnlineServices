using OS.Common.DataAccessHelpers;
using OS.Common.TranslationServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacilityServices.DataLayer.Entities
{
    [Table("Issues")]
    public class IssueEF : IEntity<int>, IMultiLanguageNameFields
    {
        [Key]
        public int Id { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public string NameDutch { get; set; }
        public string Description { get; set; }
        public ComponentTypeEF ComponentType { get; set; }
        public bool Archived { get; set; }
    }
}
