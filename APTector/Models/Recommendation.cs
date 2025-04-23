using System;
using APTector.Models;

namespace APTector.Models
{
    public class Recommendation
    {
        public int Id { get; set; }

        /// <summary>
        /// Текст рекомендации
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Когда рекомендация была создана
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Ссылка на APT-группу (необязательно)
        /// </summary>
        public int? APTGroupId { get; set; }
        public APTGroup? APTGroup { get; set; }
    }
}
