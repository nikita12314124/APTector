using Microsoft.AspNetCore.Mvc;
using APTector.Data;
using APTector.Models;
using System.Linq;

namespace APTector.Controllers
{
    public class CorrelationRulesController : Controller
    {
        private readonly AppDbContext _db;

        public CorrelationRulesController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /CorrelationRules
        public IActionResult Index()
        {
            return View();
        }

        // POST: /CorrelationRules/Results
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Results(string organizationSector, string organizationRegion, string dataSources)
        {
            // Простой вариант фильтрации:
            // Считаем, что в APTGroup поле TargetIndustries содержит информацию о секторе,
            // а поле Region содержит регион организации.
            var groups = _db.APTGroups.Where(g =>
                                g.TargetIndustries.ToLower().Contains(organizationSector.ToLower()) &&
                                g.Region.ToLower() == organizationRegion.ToLower()
                            ).ToList();

            ViewBag.OrganizationSector = organizationSector;
            ViewBag.OrganizationRegion = organizationRegion;
            ViewBag.DataSources = dataSources;

            return View(groups);
        }
    }
}
