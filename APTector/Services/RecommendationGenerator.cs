using APTector.Data;
using APTector.Models;
using APTector.Services;
using System.Collections.Generic;
using System.Linq;

namespace MyAPTFramework.Services
{
    public class RecommendationGenerator : IRecommendationGenerator
    {
        private readonly AppDbContext _db;

        public RecommendationGenerator(AppDbContext db)
        {
            _db = db;
        }

        public List<Recommendation> GenerateRecommendations(int aptGroupId)
        {
            var group = _db.APTGroups.Find(aptGroupId);
            if (group == null)
                return new List<Recommendation>();

            var recommendations = new List<Recommendation>();

            if (group.IsFinancial)
            {
                recommendations.Add(new Recommendation
                {
                    Description = $"Усилить мониторинг финансовых операций для группы {group.Name}",
                    APTGroupId = group.Id
                });
            }

            if (group.Procedures != null)
            {
                foreach (var proc in group.Procedures)
                {
                    recommendations.Add(new Recommendation
                    {
                        Description = $"Обновить правила обнаружения для процедуры {proc.Name}",
                        APTGroupId = group.Id
                    });
                }
            }

            return recommendations;
        }
    }
}
