using Microsoft.AspNetCore.Mvc;
using APTector.Data;
using APTector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;

namespace APTector.Controllers
{
    public class ProcedureAssignmentController : Controller
    {
        private readonly AppDbContext _db;

        public ProcedureAssignmentController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /ProcedureAssignment/Assign?procedureId=PROC-001
        public IActionResult Assign(string procedureId)
        {
            if (string.IsNullOrEmpty(procedureId))
                return BadRequest("Не указан идентификатор процедуры.");

            var proc = _db.Procedures.FirstOrDefault(p => p.Id == procedureId);
            if (proc == null)
                return NotFound("Процедура не найдена.");

            // Получаем список APT-групп для выпадающего списка
            ViewBag.AptGroups = new SelectList(_db.APTGroups.ToList(), "Id", "Name");
            ViewBag.ProcedureName = proc.Name;
            ViewBag.ProcedureId = proc.Id;
            return View();
        }

        // POST: /ProcedureAssignment/Assign
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Assign(string procedureId, int aptGroupId, double probability, double criticality, double businessImpact)
        {
            if (string.IsNullOrEmpty(procedureId))
                return BadRequest("Не указан идентификатор процедуры.");

            // Если уже назначено, можно обновить метрики
            var existing = _db.APTGroupProcedures
                .FirstOrDefault(a => a.ProcedureId == procedureId && a.APTGroupId == aptGroupId);
            if (existing != null)
            {
                existing.Probability = probability;
                existing.Criticality = criticality;
                existing.BusinessImpact = businessImpact;
            }
            else
            {
                var assignment = new APTGroupProcedure
                {
                    ProcedureId = procedureId,
                    APTGroupId = aptGroupId,
                    Probability = probability,
                    Criticality = criticality,
                    BusinessImpact = businessImpact
                };
                _db.APTGroupProcedures.Add(assignment);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Navigation");
        }
    }
}
