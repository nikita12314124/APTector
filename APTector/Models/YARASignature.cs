namespace APTector.Models
{
    public class YARASignature
    {
        public int Id { get; set; }

        /// <summary>
        /// Условное название правила
        /// </summary>
        public string SignatureName { get; set; } = string.Empty;

        /// <summary>
        /// Текстовое содержимое YARA-правила
        /// </summary>
        public string RuleContent { get; set; } = string.Empty;

        public int ProcedureId { get; set; }
        public Procedure? Procedure { get; set; }
    }
}
