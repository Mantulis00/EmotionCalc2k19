using Microsoft.EntityFrameworkCore;

namespace WebService
{
    public partial class EmotionDBContext : DbContext
    {
        public EmotionDBContext()
        {
        }

        public EmotionDBContext(DbContextOptions<EmotionDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<OwnedItems> OwnedItems { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EmotionDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OwnedItems>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OwnedItems)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ItemId_ToItems1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OwnedItems)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserId_ToUsers1");
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserData)
                    .HasForeignKey<UserData>(d => d.UserId)
                    .HasConstraintName("FK_UserId_ToUsers");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.ApiKey)
                    .IsRequired()
                    .HasColumnName("apiKey")
                    .HasMaxLength(100);

                entity.Property(e => e.ApiUrl)
                    .IsRequired()
                    .HasColumnName("apiURL")
                    .HasMaxLength(100);
            });
        }
    }
}
