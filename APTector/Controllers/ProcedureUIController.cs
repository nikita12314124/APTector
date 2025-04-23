using APTector.Data;
using APTector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace APTector.Controllers
{
    public class ProcedureUIController : Controller
    {
        private readonly AppDbContext _db;

        public ProcedureUIController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /ProcedureUI
        public IActionResult Index()
        {
            // Загрузим Technique, чтобы показать её имя
            var procedures = _db.Procedures.Include(p => p.Technique).ToList();
            return View(procedures);
        }

        // GET: /ProcedureUI/Create
        public IActionResult Create()
        {
            // Для выпадающего списка — все Techniques
            ViewBag.Techniques = _db.Techniques.ToList();
            return View();
        }

        // POST: /ProcedureUI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _db.Procedures.Add(procedure);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Techniques = _db.Techniques.ToList();
            return View(procedure);
        }

        // GET: /ProcedureUI/Edit/PROC-001
        public IActionResult Edit(string id)
        {
            var proc = _db.Procedures.Find(id);
            if (proc == null)
                return NotFound();

            ViewBag.Techniques = _db.Techniques.ToList();
            return View(proc);
        }

        // POST: /ProcedureUI/Edit/PROC-001
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Procedure procedure)
        {
            if (id != procedure.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _db.Procedures.Update(procedure);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Techniques = _db.Techniques.ToList();
            return View(procedure);
        }

        // GET: /ProcedureUI/Delete/PROC-001
        public IActionResult Delete(string id)
        {
            var proc = _db.Procedures.Find(id);
            if (proc == null)
                return NotFound();

            return View(proc);
        }

        // POST: /ProcedureUI/DeleteConfirmed/PROC-001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var proc = _db.Procedures.Find(id);
            if (proc == null)
                return NotFound();

            _db.Procedures.Remove(proc);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
