namespace APTector.Models
{
    public class IOC
    {
        public int Id { get; set; }

        /// <summary>
        /// Сам индикатор (IP, домен, хеш, URL и т.п.)
        /// </summary>
        public string Indicator { get; set; } = string.Empty;

        /// <summary>
        /// Тип индикатора (IP, Domain, FileHash и т.д.)
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Внешний ключ на процедуру
        /// </summary>
        public int ProcedureId { get; set; }
        public Procedure? Procedure { get; set; }
    }
}
