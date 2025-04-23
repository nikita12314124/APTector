namespace APTector.Models
{
    public class APTGroupProcedure
    {
        // Составной ключ: APTGroupId + ProcedureId
        public int APTGroupId { get; set; }
        public APTGroup APTGroup { get; set; } = null!;

        // Procedure.Id — string
        public string ProcedureId { get; set; } = string.Empty;
        public Procedure Procedure { get; set; } = null!;

        // Метрики для этой связи
        public double Probability { get; set; }
        public double Criticality { get; set; }
        public double BusinessImpact { get; set; }
    }
}
