namespace APTector.DPOs
{
    public class TechniqueDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<ProcedureDTO> Procedures { get; set; } = new();
    }
}
