using System.ComponentModel.DataAnnotations;

namespace MVCSchool_kod_do_skript.Models {
    public class RoleModification {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[]? AddIds { get; set; }
        public string[]? DeleteIds { get; set; }
    }

}
