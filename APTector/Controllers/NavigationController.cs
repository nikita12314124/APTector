using Microsoft.AspNetCore.Mvc;
using APTector.Data;
using APTector.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APTector.Controllers
{
    public class NavigationController : Controller
    {
        private readonly AppDbContext _db;
        public NavigationController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /Navigation/Index
        // Загружаем все матрицы вместе с вложенными тактиками, техниками и процедурами
        public IActionResult Index()
        {
            var matrices = _db.Matrices
                .Include(m => m.Tactics)
                    .ThenInclude(t => t.Techniques)
                        .ThenInclude(te => te.Procedures)
                .ToList();
            return View(matrices);
        }
    }
}
