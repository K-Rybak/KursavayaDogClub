namespace KursavayaDogClub.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DogDbContext : DbContext
    {
        public DogDbContext()
            : base("name=DogDbContext")
        {
        }

        public virtual DbSet<AUTORIZE> AUTORIZE { get; set; }
        public virtual DbSet<AWARD> AWARD { get; set; }
        public virtual DbSet<BREED> BREED { get; set; }
        public virtual DbSet<DISTRICT> DISTRICT { get; set; }
        public virtual DbSet<DOG> DOG { get; set; }
        public virtual DbSet<DOG_ARCHIVE> DOG_ARCHIVE { get; set; }
        public virtual DbSet<DOG_AWARD> DOG_AWARD { get; set; }
        public virtual DbSet<OWNER> OWNER { get; set; }
        public virtual DbSet<STREET> STREET { get; set; }
        public virtual DbSet<USERJOURNAL> USERJOURNAL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AUTORIZE>()
                .Property(e => e.ID_USER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<AUTORIZE>()
                .Property(e => e.LOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<AUTORIZE>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<AWARD>()
                .Property(e => e.AWARD_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BREED>()
                .Property(e => e.BREED_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BREED>()
                .HasMany(e => e.DOG)
                .WithOptional(e => e.BREED)
                .HasForeignKey(e => e.ID_BREED)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DISTRICT>()
                .Property(e => e.DISTRICT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRICT>()
                .HasMany(e => e.OWNER)
                .WithRequired(e => e.DISTRICT)
                .HasForeignKey(e => e.ID_DISTRICT);

            modelBuilder.Entity<DOG>()
                .Property(e => e.DOG_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DOG>()
                .Property(e => e.SEX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOG>()
                .HasMany(e => e.DOG_AWARD)
                .WithRequired(e => e.DOG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOG_ARCHIVE>()
                .Property(e => e.DOG_ID_A)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DOG_ARCHIVE>()
                .Property(e => e.DOG_NAME_A)
                .IsUnicode(false);

            modelBuilder.Entity<DOG_ARCHIVE>()
                .Property(e => e.OWNER_ID_A)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DOG_ARCHIVE>()
                .Property(e => e.SEX_A)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOG_ARCHIVE>()
                .Property(e => e.ID_FATHER_A)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DOG_ARCHIVE>()
                .Property(e => e.ID_MOTHER_A)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DOG_ARCHIVE>()
                .Property(e => e.ID_BREED_A)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DOG_AWARD>()
                .Property(e => e.ID_PRIMARY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<OWNER>()
                .Property(e => e.OWNER_SURNAME)
                .IsUnicode(false);

            modelBuilder.Entity<OWNER>()
                .Property(e => e.OWNER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<OWNER>()
                .Property(e => e.OWNER_PATRONYMIC)
                .IsUnicode(false);

            modelBuilder.Entity<OWNER>()
                .Property(e => e.NUM_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<OWNER>()
                .HasMany(e => e.DOG)
                .WithRequired(e => e.OWNER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STREET>()
                .Property(e => e.STREET_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<STREET>()
                .HasMany(e => e.OWNER)
                .WithRequired(e => e.STREET)
                .HasForeignKey(e => e.ID_STREET)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERJOURNAL>()
                .Property(e => e.ID_JOURNAL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<USERJOURNAL>()
                .Property(e => e.LOGIN_JOURNAL)
                .IsUnicode(false);
        }
    }
}
