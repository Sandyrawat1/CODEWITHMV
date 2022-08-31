using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CODEWITHMVC.Data;
using CODEWITHMVC.Models;

namespace CODEWITHMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EMPContext _context;

        public EmployeeController(EMPContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eMPMASTER = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eMPMASTER == null)
            {
                return NotFound();
            }

            return View(eMPMASTER);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emp_Code,Emp_Name,Designation")] EMPMASTER eMPMASTER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eMPMASTER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eMPMASTER);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eMPMASTER = await _context.Employees.FindAsync(id);
            if (eMPMASTER == null)
            {
                return NotFound();
            }
            return View(eMPMASTER);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emp_Code,Emp_Name,Designation")] EMPMASTER eMPMASTER)
        {
            if (id != eMPMASTER.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eMPMASTER);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EMPMASTERExists(eMPMASTER.Id))
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
            return View(eMPMASTER);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eMPMASTER = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eMPMASTER == null)
            {
                return NotFound();
            }

            return View(eMPMASTER);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eMPMASTER = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(eMPMASTER);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EMPMASTERExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
