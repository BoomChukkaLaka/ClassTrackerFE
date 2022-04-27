using ClassTrackerFE.Models;
using ClassTrackerFE.Models.DTO;
using ClassTrackerFE.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrackerFE.Controllers
{
    public class TeacherController : Controller
    {
        // Pull service from Startup Class
        private readonly IApiRequest<Teacher> _teacherService;
        private string controllerName = "Teacher";

        //added for filer upload method
        private readonly IWebHostEnvironment _hostingEnvironment;

        public TeacherController(IApiRequest<Teacher> teacherService, IWebHostEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
            _teacherService = teacherService;
        }

        public TeacherController(IApiRequest<Teacher> teacherService)
        {
            _teacherService = teacherService;
        }

        // GET: TeacherController
        public ActionResult Index()
        {
            var teachers = _teacherService.GetAll(controllerName);
            return View(teachers);
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            // Check to see if there is a token, if not - redirect to the login page
            if(!HttpContext.Session.Keys.Any(c => c.Equals("Token")))
            {
                return RedirectToAction("Login", "Auth");
            }

            var teacher = _teacherService.GetSingle(controllerName, id);
            return View(teacher);
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherCreate teacher)
        {
            try
            {
                Teacher newTeacher = new Teacher()
                {
                    TeacherName = teacher.TeacherName,
                    TeacherEmail = teacher.TeacherEmail,
                    TeacherPhone = teacher.TeacherPhone,
                };
                _teacherService.Create(controllerName, newTeacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_teacherService.GetSingle(controllerName, id));
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Teacher teacher)
        {
            try
            {
                _teacherService.Edit(controllerName, id, teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_teacherService.GetSingle(controllerName, id));
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Teacher teacher)
        {
            try
            {
                _teacherService.Delete(controllerName, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file) 
        {
            string folderRoot = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot//Uploads"); //defines the folder the files will live in
            string filePath = Path.Combine(folderRoot, file.FileName);  //takes the folder and adds the fileName on the end

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { success = true, message = "File Uploaded Succesfully"});
        }
    }
}
