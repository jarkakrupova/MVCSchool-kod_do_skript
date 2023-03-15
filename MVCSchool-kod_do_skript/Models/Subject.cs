using System.ComponentModel.DataAnnotations;

namespace MVCSchool_kod_do_skript.Models {
    public class Subject {
        public int Id { get; set; }
        //[StringLength(5, ErrorMessage = "The name should not be longer than 25 characters")]
        [MaxLength(50 , ErrorMessage = "The name should not be longer than 25 characters")]
        public string Name { get; set; }
    }
}
