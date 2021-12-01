using Noel_Prueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace noe.Controllers
{
        public class PersonaController : Controller
        {
            private readonly NoelOrtizPruebaContext _context;

            public PersonaController(NoelOrtizPruebaContext context)
            {
                _context = context;
            }

        public async Task<IActionResult> Index()
        {
            var persona = await _context.Personas.ToListAsync();
            return View(persona);
        }
        //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? id)
            {
                ViewBag.PageName = id == null ? "Crear Persona" : "Editar persona";
                ViewBag.IsEdit = id == null ? false : true;
                if (id == null)
                {
                    return View();
                }
                else
                {
                    var persona = await _context.Personas.FindAsync(id);

                    if (persona == null)
                    {
                        return NotFound();
                    }
                    return View(persona);
                }
            }

            //AddOrEdit Post Method
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> AddOrEdit(int id, [Bind("Nombre,FechaDeNacimiento")]
        Persona personaData)
            {
                bool IsPersonaExist = false;

                Persona persona = await _context.Personas.FindAsync(id);

                if (persona != null)
                {
                    IsPersonaExist = true;
                }
                else
                {
                    persona = new();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        persona.Nombre = personaData.Nombre;
                        persona.FechaDeNacimiento = personaData.FechaDeNacimiento;


                        if (IsPersonaExist)
                        {
                            _context.Update(persona);
                        }
                        else
                        {
                            _context.Add(persona);
                        }
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(personaData);
            }

            //Persona Details
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);
                if (persona == null)
                {
                    return NotFound();
                }
                return View(persona);
            }

            // GET: Persona/Delete/1
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);

                if (persona == null)
                {
                    return NotFound();
                }

                return View(persona);
            }

            // POST: Persona/Delete/1
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(int id)
            {
                var persona = await _context.Personas.FindAsync(id);
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

        }
    
}