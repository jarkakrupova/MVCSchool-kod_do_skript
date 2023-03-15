using System.ComponentModel;

namespace MVCSchool_kod_do_skript.ViewModels {
    public class GradesViewModel {
        public int Id { get; set; }
        [DisplayName("Student Name")]
        public int StudentId { get; set; }
        [DisplayName("Subject Name")]
        public int SubjectId { get; set; }
        public string What { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }

    }
}
