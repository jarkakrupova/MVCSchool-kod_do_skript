using Microsoft.EntityFrameworkCore;
using MVCSchool_kod_do_skript.Models;

namespace MVCSchool_kod_do_skript.Services {
    public class SubjectService {
        //service saha do Db, takze potrebuje dbContext
        public ApplicationDbContext _dbContext;
        public SubjectService(ApplicationDbContext dbContext) {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<Subject>> GetAllAsync() {
            return await _dbContext.Subjects.ToListAsync();
        }
        public async Task CreateAsync(Subject newSubject) {
            await _dbContext.Subjects.AddAsync(newSubject);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Subject> GetByIdAsync(int id) {
            return await _dbContext.Subjects.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Subject> UpdateAsync(int id, Subject updatedSubject) {
            _dbContext.Update(updatedSubject);
            await _dbContext.SaveChangesAsync();
            return updatedSubject;
        }

        internal async Task DeleteAsync(int id) {
            var SubjectToDelete = await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Subjects.Remove(SubjectToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
