using System.ComponentModel.DataAnnotations;

namespace MVCSchool_kod_do_skript.ViewModels {
    public class LoginVM {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public bool Remember { get; set; }
        public string? ReturnUrl { get; set; }
    }

}
