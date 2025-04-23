namespace APTector.DPOs
{
    public class AptGroupDTO
    {
        public string GroupName { get; set; } = string.Empty;
        public bool IsFinancial { get; set; }
        public MetricDTO Metrics { get; set; } = new();
    }
}
