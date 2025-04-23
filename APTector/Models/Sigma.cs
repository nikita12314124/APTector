using APTector.Models;

namespace APTector.Models
{
    public class Sigma
    {
        public int Id { get; set; }

        /// <summary>
        /// Название правила Sigma
        /// </summary>
        public string RuleName { get; set; } = string.Empty;

        /// <summary>
        /// Текст правила (YAML-формат или другой)
        /// </summary>
        public string RuleContent { get; set; } = string.Empty;

        public int ProcedureId { get; set; }
        public Procedure? Procedure { get; set; }
    }
}
