using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListaTarefas.Models;

namespace ListaTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly TarefaContext _context;

        public TarefasController(TarefaContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tarefas.ToListAsync());
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
                .FirstOrDefaultAsync(m => m.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarefaId,Nome,Descricao,Inicio,Fim,Importancia")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarefaId,Nome,Descricao,Inicio,Fim,Importancia")] Tarefa tarefa)
        {
            if (id != tarefa.TarefaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaExists(tarefa.TarefaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas
                .FirstOrDefaultAsync(m => m.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tarefas == null)
            {
                return Problem("Entity set 'TarefaContext.Tarefas'  is null.");
            }
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefaExists(int id)
        {
          return _context.Tarefas.Any(e => e.TarefaId == id);
        }
    }
}
