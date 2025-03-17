using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs;
//using SchoolManagement.Application.Interfaces;
using SchoolManagementMVC.SchoolManagement.Application.Services;
using System.Threading.Tasks;



namespace SchoolManagementMVC.SchoolManagement.Web.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        // Inyección del servicio IGradeService
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        // GET: Grade
        public async Task<IActionResult> Index()
        {
            var grades = await _gradeService.GetAllGradesAsync();
            return View(grades); // Devuelve una vista con la lista de calificaciones
        }

        // GET: Grade/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null)
            {
                return NotFound(); // Si no encuentra la calificación, devuelve NotFound
            }
            return View(grade); // Muestra los detalles de una calificación
        }

        // GET: Grade/Create
        public IActionResult Create()
        {
            return View(); // Muestra el formulario para crear una nueva calificación
        }

        // POST: Grade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGradeDTO createGradeDto)
        {
            if (ModelState.IsValid)
            {
                await _gradeService.CreateGradeAsync(createGradeDto); // Llama al servicio para agregar la calificación
                return RedirectToAction(nameof(Index)); // Redirige a la vista de la lista de calificaciones
            }
            return View(createGradeDto); // Si el modelo no es válido, vuelve a mostrar el formulario
        }

        // GET: Grade/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null)
            {
                return NotFound(); // Si no se encuentra la calificación, devuelve NotFound
            }
            return View(grade); // Muestra el formulario de edición
        }

        // POST: Grade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateGradeDTO updateGradeDto)
        {
            if (id != updateGradeDto.Id)
            {
                return BadRequest(); // Si el ID no coincide, devuelve BadRequest
            }

            if (ModelState.IsValid)
            {
                await _gradeService.UpdateGradeAsync(id,updateGradeDto); // Llama al servicio para actualizar la calificación
                return RedirectToAction(nameof(Index)); // Redirige a la vista de la lista de calificaciones
            }

            return View(updateGradeDto); // Si el modelo no es válido, vuelve a mostrar el formulario
        }

        // GET: Grade/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null)
            {
                return NotFound(); // Si no se encuentra la calificación, devuelve NotFound
            }
            return View(grade); // Muestra el formulario de confirmación de eliminación
        }

        // POST: Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gradeService.DeleteGradeAsync(id); // Llama al servicio para eliminar la calificación
            return RedirectToAction(nameof(Index)); // Redirige a la vista de la lista de calificaciones
        }
    }
}
