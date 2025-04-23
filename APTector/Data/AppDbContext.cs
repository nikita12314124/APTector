using Microsoft.EntityFrameworkCore;
using APTector.Models;

namespace APTector.Data
{
    public class AppDbContext : DbContext
    {
        // Конструктор принимает опции контекста, переданные из DI-контейнера
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet-свойства для каждой сущности, которые будут отображаться в таблицы базы данных
        public DbSet<Matrix> Matrices { get; set; } = null!;
        public DbSet<Tactic> Tactics { get; set; } = null!;
        public DbSet<Technique> Techniques { get; set; } = null!;
        public DbSet<Procedure> Procedures { get; set; } = null!;
        public DbSet<APTGroup> APTGroups { get; set; } = null!;
        public DbSet<APTGroupProcedure> APTGroupProcedures { get; set; } = null!;

        // Метод для настройки модели (отношений, ключей и т.д.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка составного ключа для сущности APTGroupProcedure:
            // Ключ состоит из APTGroupId и ProcedureId
            modelBuilder.Entity<APTGroupProcedure>()
                .HasKey(agp => new { agp.APTGroupId, agp.ProcedureId });

            // Настройка отношения «один ко многим» для APTGroupProcedure с APTGroup:
            modelBuilder.Entity<APTGroupProcedure>()
                .HasOne(agp => agp.APTGroup)
                .WithMany(g => g.APTGroupProcedures)
                .HasForeignKey(agp => agp.APTGroupId);

            // Настройка отношения «один ко многим» для APTGroupProcedure с Procedure:
            modelBuilder.Entity<APTGroupProcedure>()
                .HasOne(agp => agp.Procedure)
                .WithMany(p => p.APTGroupProcedures)
                .HasForeignKey(agp => agp.ProcedureId);
        }
    }
}
