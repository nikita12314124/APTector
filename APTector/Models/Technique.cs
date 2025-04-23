using System.Collections.Generic;

namespace APTector.Models
{
    public class Technique
    {
        // Строковый идентификатор (например, "T1059")
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        // Внешний ключ на Tactic (Tactic.Id — string)
        public string TacticId { get; set; } = string.Empty;
        public Tactic? Tactic { get; set; }

        // Связь «1 ко многим» с процедурами
        public List<Procedure> Procedures { get; set; } = new();
    }
}
