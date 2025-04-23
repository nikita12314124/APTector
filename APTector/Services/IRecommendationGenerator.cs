using APTector.Models;
using System.Collections.Generic;

namespace APTector.Services
{
    public interface IRecommendationGenerator
    {
        /// <summary>
        /// Генерирует список рекомендаций для заданной APT-группы.
        /// </summary>
        /// <param name="aptGroupId">Идентификатор группы</param>
        /// <returns>Список рекомендаций</returns>
        List<Recommendation> GenerateRecommendations(int aptGroupId);
    }
}
