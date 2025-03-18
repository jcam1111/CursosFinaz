
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Core.Entities;

//using SchoolManagement.Application.Interfaces;
using SchoolManagementMVC.SchoolManagement.Application.Services;
using System.Threading.Tasks;

namespace SchoolManagementMVC.SchoolManagement.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        // Constructor donde se inyecta el servicio de Teacher
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // Método para listar todos los profesores
        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return View(teachers); // Envia los profesores a la vista
        }

        // Método para mostrar el formulario de creación de un nuevo profesor
        public IActionResult Create()
        {
            return View();
        }

        // Método para procesar la creación de un nuevo profesor
        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherDTO createTeacherDto)
        {
            if (ModelState.IsValid)
            {
                //await _teacherService.CreateTeacherAsync(createTeacherDto, new Teacher(createTeacherDto.FirstName, createTeacherDto.LastName, createTeacherDto.Email)); // Llamamos al servicio para agregar el profesor
                //return RedirectToAction(nameof(Index)); // Redirige al listado de profesores
            }

            return View(createTeacherDto); // Si el modelo no es válido, retorna el formulario
        }

        // Método para mostrar el formulario de edición de un profesor
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound(); // Si no se encuentra el profesor, devuelve un error 404
            }
            return View(teacher); // Si se encuentra, pasa los datos a la vista
        }

        // Método para procesar la actualización de un profesor
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateTeacherDTO updateTeacherDto)
        {
            if (id != updateTeacherDto.Id)
            {
                return BadRequest(); // Si los ids no coinciden, se devuelve un error 400
            }

            if (ModelState.IsValid)
            {
                await _teacherService.UpdateTeacherAsync(id,updateTeacherDto); // Actualiza el profesor
                return RedirectToAction(nameof(Index)); // Redirige al listado de profesores
            }

            return View(updateTeacherDto); // Si el modelo no es válido, retorna el formulario
        }

        // Método para mostrar el formulario de eliminación de un profesor
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound(); // Si no se encuentra el profesor, devuelve un error 404
            }

            return View(teacher); // Si se encuentra, pasa los datos a la vista
        }

        // Método para procesar la eliminación de un profesor
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _teacherService.DeleteTeacherAsync(id); // Elimina el profesor
            return RedirectToAction(nameof(Index)); // Redirige al listado de profesores
        }

        // Método para mostrar los cursos de un profesor
        public async Task<IActionResult> Courses(int id)
        {
            var courses = await _teacherService.GetCoursesByTeacherAsync(id); // Llama al servicio para obtener los cursos del profesor
            if (courses == null)
            {
                return NotFound(); // Si no se encuentran los cursos, devuelve un error 404
            }

            return View(courses); // Muestra los cursos del profesor
        }
    }
}
