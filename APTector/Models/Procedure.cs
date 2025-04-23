using System.Collections.Generic;

namespace APTector.Models
{
    public class Procedure
    {
        // Строковый идентификатор (например, "PROC-001")
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        // Внешний ключ на Technique (Technique.Id — string)
        public string TechniqueId { get; set; } = string.Empty;
        public Technique? Technique { get; set; }

        // Связь многие-ко-многим с APTGroup через APTGroupProcedure
        public List<APTGroupProcedure> APTGroupProcedures { get; set; } = new();
    }
}
