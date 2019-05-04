using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVCCRUD.Models;

namespace AspNetCoreMVCCRUD.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteContext _context;

        public ClienteController(ClienteContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Cliente/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Cliente());
            else
                return View(_context.Clientes.Find(id));
        }

        // POST: Cliente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("ClienteId,CPF,Nome,SiglaEstado")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.ClienteId == 0)
                    _context.Add(cliente);
                else
                    _context.Update(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }


        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}