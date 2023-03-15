using Microsoft.AspNetCore.Mvc;
using MVCSchool_kod_do_skript.Models;
using MVCSchool_kod_do_skript.Services;

namespace MVCSchool_kod_do_skript.Controllers {
    public class SubjectsController : Controller {
        public SubjectService _service;
        public SubjectsController(SubjectService service) {
            this._service = service;
        }

        public async Task<IActionResult> Index() {
            var allStudents = await _service.GetAllAsync();
            return View(allStudents);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Subject newSubject) {
            if (ModelState.IsValid) {
                await _service.CreateAsync(newSubject);
                return RedirectToAction("Index");
            }
            else {
                return View();
            }
        }
        public async Task<IActionResult> Edit(int id) {
            var studentToEdit = await _service.GetByIdAsync(id);
            if (studentToEdit == null) {
                return View("NotFound");
            }
            return View(studentToEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")] Subject subject) {
            if (ModelState.IsValid) {
                await _service.UpdateAsync(id, subject);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public async Task<IActionResult> Delete(int id) {
            var studentToDelete = await _service.GetByIdAsync(id);
            if (studentToDelete == null) {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
