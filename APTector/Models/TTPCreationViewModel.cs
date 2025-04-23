using System.ComponentModel.DataAnnotations;

namespace APTector.Models
{
    public class TTPCreationViewModel
    {
        [Required]
        public string TacticId { get; set; } = string.Empty;

        [Required]
        public string TacticName { get; set; } = string.Empty;

        [Required]
        public int MatrixId { get; set; }

        [Required]
        public string TechniqueId { get; set; } = string.Empty;

        [Required]
        public string TechniqueName { get; set; } = string.Empty;

        [Required]
        public string ProcedureId { get; set; } = string.Empty;

        [Required]
        public string ProcedureName { get; set; } = string.Empty;

        // Поле для привязки TTP к группировке
        public int APTGroupId { get; set; }

        // Дополнительные метрики (если нужно)
        public double Probability { get; set; } = 0.0;
        public double Criticality { get; set; } = 0.0;
        public double BusinessImpact { get; set; } = 0.0;
    }
}