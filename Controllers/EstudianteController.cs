using Microsoft.AspNetCore.Mvc;
using CRUD_ADONET.Models;
using CRUD_ADONET.Data;

namespace CRUD_ADONET.Controllers
{
    public class EstudianteController : Controller
    {

        EstudianteData _EstudianteData = new EstudianteData();
        public IActionResult Listar()
        {
            //Listar Lista de Estudiante
            var oLista = _EstudianteData.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Guardar Estudiante    
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(EstudianteModel oEstudiante)
        {
            //Guardar Estudiante    
            var res = _EstudianteData.GuardarEstudiante(oEstudiante);
            if (res)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int CodEstudiante)
        {
            var oEstudiante = _EstudianteData.ObtenerEstudiante(CodEstudiante);
            return View(oEstudiante);
            //Editar Estudiante
        }

        [HttpPost]
        public IActionResult Editar(EstudianteModel oEstudiante)
        {
            if (!ModelState.IsValid)
                return View();
            var respuesta = _EstudianteData.EditarEstudiante(oEstudiante);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int CodEstudiante)
        {
            // Obtén los datos del estudiante para mostrar en la vista
            var estudiante = _EstudianteData.ObtenerEstudiante(CodEstudiante);

            if (estudiante == null)
            {
                // Maneja el caso cuando no se encuentra el estudiante
                return NotFound("Estudiante no encontrado.");
            }
            return View(estudiante); // Pasa el modelo correcto a la vista
        }

        [HttpPost]
        public IActionResult Eliminar(EstudianteModel oEstudiante)
        {
            var resultado = _EstudianteData.EliminarEstudiante(oEstudiante.CodEstudiante);

            if (resultado)
            {
                TempData["Mensaje"] = "Estudiante eliminado correctamente.";
                return RedirectToAction("Listar"); // Redirige a la lista de estudiantes
            }
            else
            {
                TempData["Error"] = "Hubo un problema al eliminar el estudiante.";
                return RedirectToAction("Eliminar", new { oEstudiante.CodEstudiante });
            }
        }

    }
}