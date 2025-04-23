using Microsoft.AspNetCore.Mvc;
using APTector.Data;
using APTector.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APTector.Controllers
{
    public class GroupNavigationController : Controller
    {
        private readonly AppDbContext _db;
        public GroupNavigationController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /GroupNavigation/Details/1
        public IActionResult Details(int id)
        {
            var group = _db.APTGroups
                .Include(g => g.APTGroupProcedures)
                    .ThenInclude(link => link.Procedure)
                        .ThenInclude(p => p.Technique)
                            .ThenInclude(t => t.Tactic)
                .FirstOrDefault(g => g.Id == id);
            if (group == null)
                return NotFound();

            return View(group);
        }
    }
}
