using System.Collections.Generic;

namespace APTector.Models
{
    public class Matrix
    {
        public int Id { get; set; }                            // Целочисленный ключ
        public string MatrixName { get; set; } = string.Empty;  // Название матрицы

        // Связь «1 ко многим» с тактиками
        public List<Tactic> Tactics { get; set; } = new();
    }
}
