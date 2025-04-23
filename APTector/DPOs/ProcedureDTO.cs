namespace APTector.DPOs
{
    public class ProcedureDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<AptGroupDTO> AptGroups { get; set; } = new();
    }
}
