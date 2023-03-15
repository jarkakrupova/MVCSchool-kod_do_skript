using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCSchool_kod_do_skript.Services;
using MVCSchool_kod_do_skript.ViewModels;

namespace MVCSchool_kod_do_skript.Controllers {
    public class GradesController : Controller {
        GradesService _service;

        public GradesController(GradesService service) {
            _service = service;
        }

        public async Task<IActionResult> Index() {
            var allGrades = await _service.GetAllAsync();
            return View(allGrades);
        }

        public async Task<IActionResult> Create() {
            var gradesDropdownsData = await _service.GetNewGradesDropdownsValues();
            ViewBag.Students = new SelectList(gradesDropdownsData.Students, "Id", "LastName");
            ViewBag.Subjects = new SelectList(gradesDropdownsData.Subjects, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GradesViewModel newGrade) {
            if (!ModelState.IsValid) {
                var gradesDropdownsData = await _service.GetNewGradesDropdownsValues();
                ViewBag.Students = new SelectList(gradesDropdownsData.Students, "Id", "LastName");
                ViewBag.Subjects = new SelectList(gradesDropdownsData.Subjects, "Id", "Name");
                return View(newGrade);
            }
            await _service.CreateAsync(newGrade);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id) {
            var gradeToEdit = await _service.GetByIdAsync(id);
            if (gradeToEdit == null) {
                return View("NotFound");
            }
            var response = new GradesViewModel() {
                Id = gradeToEdit.Id,
                Date = gradeToEdit.Date,
                Mark = gradeToEdit.Mark,
                StudentId = gradeToEdit.Student.Id,
                SubjectId = gradeToEdit.Subject.Id,
                What = gradeToEdit.What
            };
            var gradesDropdownsData = await _service.GetNewGradesDropdownsValues();
            ViewBag.Students = new SelectList(gradesDropdownsData.Students, "Id", "LastName");
            ViewBag.Subjects = new SelectList(gradesDropdownsData.Subjects, "Id", "Name");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, GradesViewModel updatedGrade) {
            await _service.UpdateAsync(id, updatedGrade);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAsync(int id) {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
