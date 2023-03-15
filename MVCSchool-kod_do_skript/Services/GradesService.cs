using Microsoft.EntityFrameworkCore;
using MVCSchool_kod_do_skript.Models;
using MVCSchool_kod_do_skript.ViewModels;

namespace MVCSchool_kod_do_skript.Services {
    public class GradesService {
        ApplicationDbContext dbContext;

        public GradesService(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Grade>> GetAllAsync() {
            return await dbContext.Grades.Include(n => n.Student).Include(c => c.Subject).ToListAsync();
        }
        public async Task<GradesDropdownsViewModel> GetNewGradesDropdownsValues() {
            var gradesDropdownsData = new GradesDropdownsViewModel() {
                Students = await dbContext.Students.OrderBy(n => n.LastName).ToListAsync(),
                Subjects = await dbContext.Subjects.OrderBy(x => x.Name).ToListAsync(),
            };
            return gradesDropdownsData;
        }
        public async Task CreateAsync(GradesViewModel newGrade) {
            var gradeToInsert = new Grade() {
                Student = dbContext.Students.FirstOrDefault(s => s.Id == newGrade.StudentId),
                Subject = dbContext.Subjects.FirstOrDefault(sub => sub.Id == newGrade.SubjectId),
                Date = DateTime.Today,
                What = newGrade.What,
                Mark = newGrade.Mark
            };
            if (gradeToInsert.Student != null && gradeToInsert.Subject != null) {
                await dbContext.Grades.AddAsync(gradeToInsert);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<Grade> GetByIdAsync(int id) {
            return await dbContext.Grades.Include(n => n.Student).Include(c => c.Subject).FirstOrDefaultAsync(n => n.Id == id);
        }
        public async Task UpdateAsync(int id, GradesViewModel updatedGrade) {
            var dbGrade = await dbContext.Grades.FirstOrDefaultAsync(n => n.Id == updatedGrade.Id);
            if (dbGrade != null) {
                dbGrade.Student = dbContext.Students.FirstOrDefault(n => n.Id == updatedGrade.StudentId);
                dbGrade.Subject = dbContext.Subjects.FirstOrDefault(x => x.Id == updatedGrade.SubjectId);
                dbGrade.What = updatedGrade.What;
                dbGrade.Mark = updatedGrade.Mark;
                dbGrade.Date = updatedGrade.Date;
            }

            dbContext.Update(dbGrade);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id) {
            var gradeToDelete = dbContext.Grades.FirstOrDefault(g => g.Id == id);
            dbContext.Grades.Remove(gradeToDelete);
            dbContext.SaveChanges();
        }

    }
}
