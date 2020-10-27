namespace MagicEnglish.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RichTextMessageModels : DbContext
    {
        public RichTextMessageModels()
            : base("name=RichTextMessageModels")
        {
        }

        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(e => e.Contents)
                .IsUnicode(false);
        }
    }
}
