using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phonebook.Data.Entities;

namespace Phonebook.Data
{
    public class PhonebookContext : DbContext
    {
        public DbSet<PhonebookEntity> Phonebooks { get; set; }
        public DbSet<EntryEntity> Entries { get; set; }

        public PhonebookContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PhonebookEntity>(ConfigurePhonebook);
            builder.Entity<EntryEntity>(ConfigureEntry);
        }

        private void ConfigurePhonebook(EntityTypeBuilder<PhonebookEntity> builder)
        {
            builder.ToTable("tblPhonebook");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
        private void ConfigureEntry(EntityTypeBuilder<EntryEntity> builder)
        {
            builder.ToTable("tblEntry");
            builder.HasIndex(cb => cb.Name);

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.Number)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
