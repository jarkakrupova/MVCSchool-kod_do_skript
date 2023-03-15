using Microsoft.AspNetCore.Mvc;
using MVCSchool_kod_do_skript.Models;
using MVCSchool_kod_do_skript.Services;
using System.Xml;

namespace MVCSchool_kod_do_skript.Controllers {
    public class StudentsController : Controller {
        public StudentService _service;
        public StudentsController(StudentService service) {
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
        public async Task<IActionResult> Create(Student newStudent) {
            await _service.CreateAsync(newStudent);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id) {
            var studentToEdit = await _service.GetByIdAsync(id);
            if (studentToEdit == null) {
                return View("NotFound");
            }
            return View(studentToEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FirstName, LastName, DateOfBirth")] Student student) {
            await _service.UpdateAsync(id, student);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) {
            var studentToDelete = await _service.GetByIdAsync(id);
            if (studentToDelete == null) {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Load() {
            XmlDocument xmlDoc = new XmlDocument();
            //System.Diagnostics.Debug.WriteLine(Directory.GetCurrentDirectory()); //koren projektu
            string xmlfilepath = Path.Combine(Directory.GetCurrentDirectory(), "XML Files", "Students.xml");
            xmlDoc.Load(xmlfilepath);

            XmlElement koren = xmlDoc.DocumentElement;
            foreach (XmlNode node in koren.SelectNodes("/Students/Student")) {
                Student s = new Student {
                    FirstName = node.ChildNodes[0].InnerText,
                    LastName = node.ChildNodes[1].InnerText,
                    DateOfBirth = Convert.ToDateTime(node.ChildNodes[2].InnerText)
                };
                await _service.CreateAsync(s);
            }
            return RedirectToAction("Index");
        }
    }
}
