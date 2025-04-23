namespace APTector.Services
{
    public interface IScoringEngine
    {
        /// <summary>
        /// Вычисляет скоринговое значение для заданной APT-группы.
        /// </summary>
        /// <param name="aptGroupId">Идентификатор группы</param>
        /// <returns>Скоринговое значение (double)</returns>
        double ComputeScore(int aptGroupId);

        /// <summary>
        /// Пересчитывает скоринг для всех групп.
        /// </summary>
        void RankAPTGroups();
    }
}
