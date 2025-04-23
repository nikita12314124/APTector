using APTector.Data;
using APTector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace APTector.Controllers
{
    public class TechniqueUIController : Controller
    {
        private readonly AppDbContext _db;

        public TechniqueUIController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /TechniqueUI
        public IActionResult Index()
        {
            // Загрузим Tactic, чтобы показать её имя
            var techniques = _db.Techniques.Include(te => te.Tactic).ToList();
            return View(techniques);
        }

        // GET: /TechniqueUI/Create
        public IActionResult Create()
        {
            // Для выпадающего списка — все Tactics
            ViewBag.Tactics = _db.Tactics.ToList();
            return View();
        }

        // POST: /TechniqueUI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Technique technique)
        {
            if (ModelState.IsValid)
            {
                _db.Techniques.Add(technique);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Tactics = _db.Tactics.ToList();
            return View(technique);
        }

        // GET: /TechniqueUI/Edit/T1059
        public IActionResult Edit(string id)
        {
            var technique = _db.Techniques.Find(id);
            if (technique == null)
                return NotFound();

            ViewBag.Tactics = _db.Tactics.ToList();
            return View(technique);
        }

        // POST: /TechniqueUI/Edit/T1059
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Technique technique)
        {
            if (id != technique.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _db.Techniques.Update(technique);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Tactics = _db.Tactics.ToList();
            return View(technique);
        }

        // GET: /TechniqueUI/Delete/T1059
        public IActionResult Delete(string id)
        {
            var technique = _db.Techniques.Find(id);
            if (technique == null)
                return NotFound();

            return View(technique);
        }

        // POST: /TechniqueUI/DeleteConfirmed/T1059
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var technique = _db.Techniques.Find(id);
            if (technique == null)
                return NotFound();

            _db.Techniques.Remove(technique);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
