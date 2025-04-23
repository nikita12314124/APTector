using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace APTector.Models
{
    public class APTGroup
    {
        public int Id { get; set; }

        // Основное название группировки
        public string Name { get; set; } = string.Empty;

        // Флаг финансовой мотивации (если true – группировка ориентирована на финансовую выгоду)
        public bool IsFinancial { get; set; }

        // Базовые поля для описания группировки
        public string Impact { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;

        // Новые поля:

        // Мотивация: например, "Финансовая выгода", "Шпионаж", "Хактивизм"
        public string Motivation { get; set; } = string.Empty;

        // Альтернативные названия (например, через запятую)
        public string Aliases { get; set; } = string.Empty;

        // Дата или год, с которого группировка активна; nullable, если неизвестно
        public DateTime? ActiveSince { get; set; }

        // Целевые отрасли (например, "Государственный сектор, Финансы, СМИ")
        public string TargetIndustries { get; set; } = string.Empty;

        // Географический фокус (например, "Россия, СНГ" или конкретные страны/регионы)
        public string GeographicalFocus { get; set; } = string.Empty;

        // Ключевые кампании или значимые инциденты (короткий обзор наиболее известных кейсов)
        public string NotableCampaigns { get; set; } = string.Empty;

        // Уровень угрозы (например, числовой рейтинг от 1 до 10)
        public double? ThreatLevel { get; set; }

        // Уверенность в атрибуции (например, в процентах, или как значение от 0 до 1)
        public double? AttributionConfidence { get; set; }

        // Навигационное свойство для связи многие-ко-многим через таблицу-связку (например, для процедур)
        public List<APTGroupProcedure> APTGroupProcedures { get; set; } = new();

        // Вычисляемое свойство для удобного доступа к процедурам, но не мапится на базу
        [NotMapped]
        public IEnumerable<Procedure> Procedures => APTGroupProcedures.Select(link => link.Procedure);
    }
}
