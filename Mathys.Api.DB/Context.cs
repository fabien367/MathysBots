namespace Mathys.Api.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<TemplateTable> TemplateTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firm>()
                .Property(e => e.FirmName)
                .IsUnicode(false);

            modelBuilder.Entity<Firm>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<Firm>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<TemplateTable>()
                .Property(e => e.Classification)
                .IsUnicode(false);

            modelBuilder.Entity<TemplateTable>()
                .Property(e => e.Problem)
                .IsUnicode(false);

            modelBuilder.Entity<TemplateTable>()
                .Property(e => e.Solution)
                .IsUnicode(false);
        }
    }
}
