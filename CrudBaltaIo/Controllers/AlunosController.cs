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
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AlunosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            return _context.Alunos != null ?
                View(await _context.Alunos.ToListAsync()) : NotFound();
        }

        public async Task<IActionResult> Details(int? id)
        {

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest();
            }

            if (aluno.Imagem != null)
            {
                var folder = "arquivos/alunos/";
                folder += Guid.NewGuid().ToString() + "_" + aluno.Imagem.FileName;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                await aluno.Imagem.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                using var memoryStream = new MemoryStream();
                var copyFile = aluno.Imagem.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();
                var base64 = Convert.ToBase64String(fileBytes);
                aluno.ImagemBase64 = base64;
                aluno.ImagemUrl = serverFolder;

            }
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Aluno alunoAtualizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }

            if (alunoAtualizado.Imagem != null)
            {
                var folder = "arquivos/alunos/";
                folder += Guid.NewGuid().ToString() + "_" + alunoAtualizado.Imagem.FileName;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                await alunoAtualizado.Imagem.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                using var memoryStream = new MemoryStream();
                var copyFile = alunoAtualizado.Imagem.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();
                var base64 = Convert.ToBase64String(fileBytes);
                alunoAtualizado.ImagemBase64 = base64;
                alunoAtualizado.ImagemUrl = serverFolder;

            }

            Merge(alunoAtualizado, aluno);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private static void Merge(Aluno alunoAtualizado, Aluno? aluno)
        {
            aluno.NomeCompleto = alunoAtualizado.NomeCompleto;
            aluno.CpfAluno = alunoAtualizado.CpfAluno;
            aluno.Telefone = alunoAtualizado?.Telefone;
            aluno.DataNascimento = alunoAtualizado.DataNascimento;
            aluno.ImagemUrl = alunoAtualizado.ImagemUrl;
            aluno.ImagemBase64 = alunoAtualizado.ImagemBase64;
            aluno.Assinaturas = alunoAtualizado.Assinaturas;
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
            {
                return NotFound();
            }
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
