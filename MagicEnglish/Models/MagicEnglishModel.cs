namespace MagicEnglish.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MagicEnglishModel : DbContext
    {
        public MagicEnglishModel()
            : base("name=MagicEnglishModel")
        {
        }

        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<Location>()
                .Property(e => e.Longitude)
                .HasPrecision(11, 8);

            modelBuilder.Entity<Tutor>()
                .Property(e => e.Path)
                .IsUnicode(false);
        }
    }
}
