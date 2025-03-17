using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs;
//using SchoolManagement.Application.Interfaces;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
using SchoolManagementMVC.SchoolManagement.Application.Services;

namespace SchoolManagementMVC.SchoolManagement.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return View(courses); // Pasamos la lista de cursos a la vista
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course); // Mostramos los detalles del curso
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View(); // Muestra el formulario para crear un curso
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseDTO createCourseDto)
        {
            if (ModelState.IsValid)
            {
                await _courseService.CreateCourseAsync(createCourseDto);
                return RedirectToAction(nameof(Index)); // Redirige al índice después de crear el curso
            }
            return View(createCourseDto); // Si hay errores en el modelo, vuelve a mostrar el formulario
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course); // Muestra el formulario de edición del curso
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateCourseDTO updateCourseDto)
        {
            if (id != updateCourseDto.TeacherID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _courseService.UpdateCourseAsync(id,updateCourseDto);
                return RedirectToAction(nameof(Index)); // Redirige al índice después de actualizar
            }

            return View(updateCourseDto); // Si hay errores en el modelo, vuelve a mostrar el formulario
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course); // Muestra el formulario de confirmación de eliminación
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return RedirectToAction(nameof(Index)); // Redirige al índice después de eliminar
        }
    }
}
