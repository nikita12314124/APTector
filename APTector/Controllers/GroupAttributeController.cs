using Microsoft.AspNetCore.Mvc;
using APTector.Data;
using APTector.Models;
using System.Linq;

namespace APTector.Controllers
{
    public class GroupAttributeController : Controller
    {
        private readonly AppDbContext _db;
        public GroupAttributeController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /GroupAttribute/Index?region=...&sphere=...
        public IActionResult Index(string region = "", string sphere = "")
        {
            var groups = _db.APTGroups.AsQueryable();

            if (!string.IsNullOrEmpty(region))
                groups = groups.Where(g => g.Region == region);
            if (!string.IsNullOrEmpty(sphere))
                groups = groups.Where(g => g.Sector == sphere);

            // Для примера ранжируем по примитивному алгоритму: финансовым группам выставляем больший балл
            var groupList = groups.ToList()
                .OrderByDescending(g => g.IsFinancial ? 10 : 5)
                .ThenBy(g => g.Name)
                .ToList();

            return View(groupList);
        }
    }
}
