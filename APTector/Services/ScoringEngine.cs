using APTector.Data;
using APTector.Models;
using System.Linq;

namespace APTector.Services
{
    public class ScoringEngine : IScoringEngine
    {
        private readonly AppDbContext _db;

        // Внедрение AppDbContext через конструктор для доступа к данным.
        public ScoringEngine(AppDbContext db)
        {
            _db = db;
        }

        // Метод для вычисления скоринга конкретной APT-группы.
        public double ComputeScore(int aptGroupId)
        {
            var group = _db.APTGroups.Find(aptGroupId);
            if (group == null)
                return 0.0;

            // Пример упрощенной логики скоринга:
            double score = group.IsFinancial ? 10.0 : 5.0;
            // Используем Count() с круглыми скобками, чтобы вызвать метод расширения
            int procedureCount = group.Procedures?.Count() ?? 0;
            score += procedureCount * 2;

            return score;
        }

        // Метод для пересчета скоринга для всех групп.
        public void RankAPTGroups()
        {
            var allGroups = _db.APTGroups.ToList();
            foreach (var group in allGroups)
            {
                double score = ComputeScore(group.Id);
                // Здесь можно добавить логику сохранения или логгирования результата
            }
        }
    }
}
