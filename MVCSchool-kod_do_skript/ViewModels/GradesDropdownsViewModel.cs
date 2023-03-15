using MVCSchool_kod_do_skript.Models;

namespace MVCSchool_kod_do_skript.ViewModels {
    public class GradesDropdownsViewModel {
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }
        public GradesDropdownsViewModel() {
            Students = new List<Student>();
            Subjects = new List<Subject>();
        }
    }

}
