using Microsoft.AspNetCore.Mvc;
using APTector.Data;
using APTector.Models;
using System.Linq;

namespace APTector.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;
        public DashboardController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /Dashboard/Index
        // Принимает фильтры по региону и сфере, сортирует группировки по значимости (например, финансовые получают больший вес)
        public IActionResult Index(string region = "", string sphere = "")
        {
            var groupsQuery = _db.APTGroups.AsQueryable();
            if (!string.IsNullOrEmpty(region))
            {
                groupsQuery = groupsQuery.Where(g => g.Region == region);
            }
            if (!string.IsNullOrEmpty(sphere))
            {
                groupsQuery = groupsQuery.Where(g => g.Sector == sphere);
            }

            var groups = groupsQuery.ToList()
                .OrderByDescending(g => g.IsFinancial ? 10 : 5)
                .ThenBy(g => g.Name)
                .ToList();

            return View(groups);
        }
    }
}
