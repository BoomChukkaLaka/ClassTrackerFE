using ClassTrackerFE.Models.DTO;
using ClassTrackerFE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ClassTrackerFE.Controllers
{
    public class TafeClassController : Controller
    {
        private static TafeClassService _tafeClassService;
        private static TeacherService _teacherService;
        public TafeClassController()
        {
            if (_tafeClassService == null)
            {
                _tafeClassService = new TafeClassService();
            }

            if( _teacherService == null)
            {
                _teacherService = new TeacherService();
            }
        }

        // GET: TafeClassController
        public ActionResult Index()
        {
            var tafeClasses = _tafeClassService.GetTafeClasses();
            return View(tafeClasses);
        }

        // GET: TafeClassController/Details/5
        public ActionResult Details(int id)
        {
            var tafeClass = _tafeClassService.GetSingleTafeClass(id);
            return View(tafeClass);
        }

        // GET: TafeClassController
        public ActionResult TafeClassesForTeacherId(int id)
        {
            var tafeClasses = _tafeClassService.GetTafeClassesForTeacher(id);
            return View("Index", tafeClasses);
        }

        // GET: TafeClassController/Create
        public ActionResult Create()
        {
            // Get a list of all teachers
            var teachers = _teacherService.GetTeachers();

            // Create a list of selectlistitems from teacher list
            var teacherSelect = teachers.Select(c => new SelectListItem
            {
                Value = c.TeacherId.ToString(),
                Text = c.TeacherName
            }).ToList();

            // Not Linq
            /* var teacherSelect2 = new List<SelectListItem>();

             foreach (var teacher in teachers)
             {
                 var teacherItem = new SelectListItem 
                 { 
                     Value = teacher.TeacherId.ToString(),
                     Text = teacher.TeacherName 
                 };
                 teacherSelect2.Add(teacherItem);
             }*/

            // Store this list in memory

            // ViewBag - Dynamic Object. Works with everything. Is heavy and can be slow with lots of data.
            ViewBag.TeacherSelect = teacherSelect;

            // ViewData - Key/Value(String/Object) Dictionary. Have to box and unbox but is light.
            //ViewData.Add("TeacherSelect", teacherSelect);


            return View();
        }

        // POST: TafeClassController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TafeClassCreate tafeClass)
        {
            try
            {
                _tafeClassService.CreateTafeClass(tafeClass);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TafeClassController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TafeClassController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TafeClassController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TafeClassController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
