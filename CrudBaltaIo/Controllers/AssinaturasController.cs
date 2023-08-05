using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudBaltaIo.Data;
using CrudBaltaIo.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CrudBaltaIo.Controllers
{
    [Authorize]
    public class AssinaturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssinaturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Assinaturas != null ? 
                          View(await _context.Assinaturas.ToListAsync()) :
                          NotFound();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var assinatura = await _context.Assinaturas
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assinatura == null)
            {
                return NotFound();
            }

            return View(assinatura);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Assinatura assinatura)
        {
            if (!ModelState.IsValid)
            {
               return NotFound();
            }
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id ==  assinatura.IdAluno);
            if (aluno == null)
            {
               return NotFound("Aluno não encontrado");
            }

            if (assinatura.Inicio.Date < DateTime.Now.Date)
            {
                return BadRequest("A data de inicio não pode ser menor que a data atual");
            }

            var assinaturaExisteDate = _context.Assinaturas
                .OrderByDescending(a => a.Termino)
                .FirstOrDefault(a => a.IdAluno == assinatura.IdAluno);

            if(assinaturaExisteDate != null && assinaturaExisteDate.Ativo)
            {
                assinatura.Inicio = assinaturaExisteDate.Termino.AddDays(1);
                assinatura.Termino = assinatura.Inicio.AddYears(1);
                assinatura.Ativo = false;
            }

            _context.Assinaturas.Add(assinatura);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var assinatura = await _context.Assinaturas.FirstOrDefaultAsync(a => a.Id == id);

            if (assinatura == null)
            {
                return BadRequest();
            }
            return View(assinatura);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, Assinatura assinatura)
        {
            if (id != assinatura.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Update(assinatura);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var assinatura = await _context.Assinaturas
                .FirstOrDefaultAsync(m => m.Id == id);

            if (assinatura == null)
            {
                return NotFound();
            }

            return View(assinatura);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var assinatura = await _context.Assinaturas.FirstOrDefaultAsync(a => a.Id == id);

            if (assinatura == null)
            {
                return NotFound();
            }
            _context.Assinaturas.Remove(assinatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
