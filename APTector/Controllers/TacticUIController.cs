using APTector.Data;
using APTector.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APTector.Controllers
{
    public class TacticUIController : Controller
    {
        private readonly AppDbContext _db;

        public TacticUIController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /TacticUI
        public IActionResult Index()
        {
            // Загрузим связанные Matrix, чтобы показывать MatrixName
            var tactics = _db.Tactics.Include(t => t.Matrix).ToList();
            return View(tactics);
        }

        // GET: /TacticUI/Create
        public IActionResult Create()
        {
            // Для выпадающего списка — все имеющиеся матрицы
            ViewBag.Matrices = _db.Matrices.ToList();
            return View();
        }

        // POST: /TacticUI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tactic tactic)
        {
            if (ModelState.IsValid)
            {
                _db.Tactics.Add(tactic);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Matrices = _db.Matrices.ToList();
            return View(tactic);
        }

        // GET: /TacticUI/Edit/TA0001
        public IActionResult Edit(string id)
        {
            var tactic = _db.Tactics.Find(id);
            if (tactic == null)
                return NotFound();

            ViewBag.Matrices = _db.Matrices.ToList();
            return View(tactic);
        }

        // POST: /TacticUI/Edit/TA0001
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Tactic tactic)
        {
            if (id != tactic.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _db.Tactics.Update(tactic);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Matrices = _db.Matrices.ToList();
            return View(tactic);
        }

        // GET: /TacticUI/Delete/TA0001
        public IActionResult Delete(string id)
        {
            var tactic = _db.Tactics.Find(id);
            if (tactic == null)
                return NotFound();

            return View(tactic);
        }

        // POST: /TacticUI/DeleteConfirmed/TA0001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var tactic = _db.Tactics.Find(id);
            if (tactic == null)
                return NotFound();

            _db.Tactics.Remove(tactic);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
