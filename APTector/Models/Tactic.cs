using System.Collections.Generic;

namespace APTector.Models
{
    public class Tactic
    {
        // Первичный ключ — строка (например, "TA0001")
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        // Внешний ключ на Matrix (Matrix.Id — int)
        public int MatrixId { get; set; }
        public Matrix? Matrix { get; set; }

        // Связь «1 ко многим» с техниками
        public List<Technique> Techniques { get; set; } = new();
    }
}
