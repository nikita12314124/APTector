using Microsoft.AspNetCore.Mvc;
using APTector.Data;
using APTector.Models;
using System.Linq;

namespace APTector.Controllers
{
    public class TTPController : Controller
    {
        private readonly AppDbContext _db;
        public TTPController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /TTP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /TTP/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TTPCreationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Создаём (или находим) тактику
            var tactic = _db.Tactics.Find(model.TacticId);
            if (tactic == null)
            {
                tactic = new Tactic
                {
                    Id = model.TacticId,
                    Name = model.TacticName,
                    MatrixId = model.MatrixId
                };
                _db.Tactics.Add(tactic);
                _db.SaveChanges();
            }

            // Создаём (или находим) технику
            var technique = _db.Techniques.Find(model.TechniqueId);
            if (technique == null)
            {
                technique = new Technique
                {
                    Id = model.TechniqueId,
                    Name = model.TechniqueName,
                    TacticId = tactic.Id
                };
                _db.Techniques.Add(technique);
                _db.SaveChanges();
            }

            // Создаём (или находим) процедуру
            var procedure = _db.Procedures.Find(model.ProcedureId);
            if (procedure == null)
            {
                procedure = new Procedure
                {
                    Id = model.ProcedureId,
                    Name = model.ProcedureName,
                    TechniqueId = technique.Id
                };
                _db.Procedures.Add(procedure);
                _db.SaveChanges();
            }

            // Привязать процедуру к группе, если указали APTGroupId
            if (model.APTGroupId > 0)
            {
                var group = _db.APTGroups.Find(model.APTGroupId);
                if (group != null)
                {
                    // Проверим, нет ли уже привязки
                    var existingLink = _db.APTGroupProcedures
                        .FirstOrDefault(x => x.APTGroupId == group.Id && x.ProcedureId == procedure.Id);
                    if (existingLink == null)
                    {
                        var link = new APTGroupProcedure
                        {
                            APTGroupId = group.Id,
                            ProcedureId = procedure.Id,
                            Probability = model.Probability,
                            Criticality = model.Criticality,
                            BusinessImpact = model.BusinessImpact
                        };
                        _db.APTGroupProcedures.Add(link);
                        _db.SaveChanges();
                    }
                }
            }

            TempData["Message"] = "TTP успешно создан и привязан к группе (если указана)!";
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
