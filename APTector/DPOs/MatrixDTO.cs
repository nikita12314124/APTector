using APTector.DPOs;

namespace APTector.DTOs
{
    public class MatrixDTO
    {
        public string MatrixName { get; set; } = string.Empty;
        public List<TacticDTO> Tactics { get; set; } = new();
    }
}
