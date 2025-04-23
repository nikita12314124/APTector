﻿namespace APTector.DPOs
{
    public class TacticDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<TechniqueDTO> Techniques { get; set; } = new();
    }
}
