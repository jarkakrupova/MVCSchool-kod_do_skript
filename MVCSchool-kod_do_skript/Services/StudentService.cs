using Microsoft.EntityFrameworkCore;
using MVCSchool_kod_do_skript.Models;

namespace MVCSchool_kod_do_skript.Services {
    public class StudentService {
        //service saha do Db, takze potrebuje dbContext
        public ApplicationDbContext _dbContext;
        public StudentService(ApplicationDbContext dbContext) {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<Student>> GetAllAsync() {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task CreateAsync(Student newStudent) {
            await _dbContext.Students.AddAsync(newStudent);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Student> GetByIdAsync(int id) {
            return await _dbContext.Students.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Student> UpdateAsync(int id, Student updatedStudent) {
            _dbContext.Update(updatedStudent);
            await _dbContext.SaveChangesAsync();
            return updatedStudent;
        }

        internal async Task DeleteAsync(int id) {
            var studentToDelete = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Students.Remove(studentToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
