using Microsoft.AspNetCore.Identity;

namespace MVCSchool_kod_do_skript.Models {
    public class RoleEdit {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }

}
