using Microsoft.AspNetCore.Mvc;
using APTector.Data;
using APTector.Models;
using System.Linq;

namespace APTector.Controllers
{
    public class APTGroupUIController : Controller
    {
        private readonly AppDbContext _db;

        public APTGroupUIController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /APTGroupUI
        public IActionResult Index()
        {
            var groups = _db.APTGroups.ToList();
            return View(groups);
        }

        // GET: /APTGroupUI/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /APTGroupUI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(APTGroup model)
        {
            if (ModelState.IsValid)
            {
                _db.APTGroups.Add(model);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /APTGroupUI/Edit/5
        public IActionResult Edit(int id)
        {
            var group = _db.APTGroups.Find(id);
            if (group == null)
                return NotFound();

            return View(group);
        }

        // POST: /APTGroupUI/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, APTGroup model)
        {
            if (id != model.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _db.APTGroups.Update(model);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /APTGroupUI/Delete/5
        public IActionResult Delete(int id)
        {
            var group = _db.APTGroups.Find(id);
            if (group == null)
                return NotFound();

            return View(group);
        }

        // POST: /APTGroupUI/DeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var group = _db.APTGroups.Find(id);
            if (group == null)
                return NotFound();

            _db.APTGroups.Remove(group);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
