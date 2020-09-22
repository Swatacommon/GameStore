using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models
{
    public partial class GameStoreContext : DbContext
    {
        public GameStoreContext()
        {
        }

        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<GameCategorys> GameCategorys { get; set; }
        public virtual DbSet<GameGenres> GameGenres { get; set; }
        public virtual DbSet<GameImages> GameImages { get; set; }
        public virtual DbSet<GameMethodActivations> GameMethodActivations { get; set; }
        public virtual DbSet<GamePlatforms> GamePlatforms { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<MethodActivations> MethodActivations { get; set; }
        public virtual DbSet<OrderGames> OrderGames { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Platforms> Platforms { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AOL90O5\\SSQLSERVER;Database=GameStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<GameCategorys>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.CategoryId });

                entity.HasIndex(e => e.CategoryId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.GameCategorys)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameCategory_Categories");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameCategorys)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameCategory_Games");
            });

            modelBuilder.Entity<GameGenres>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.GenreId });

                entity.HasIndex(e => e.GenreId);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameGenres)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameGenre_Games");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GameGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameGenre_Genres");
            });

            modelBuilder.Entity<GameImages>(entity =>
            {
                entity.HasKey(e => new { e.ImageName, e.GameId });

                entity.Property(e => e.ImageName).HasMaxLength(350);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameImages)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameImages_Games");

                entity.HasOne(d => d.ImageNameNavigation)
                    .WithMany(p => p.GameImages)
                    .HasForeignKey(d => d.ImageName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameImages_Image");
            });

            modelBuilder.Entity<GameMethodActivations>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.MethodActivationId });

                entity.HasIndex(e => e.MethodActivationId);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameMethodActivations)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameMethodActivation_Games");

                entity.HasOne(d => d.MethodActivation)
                    .WithMany(p => p.GameMethodActivations)
                    .HasForeignKey(d => d.MethodActivationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameMethodActivation_MethodActivations");
            });

            modelBuilder.Entity<GamePlatforms>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PlatformId });

                entity.HasIndex(e => e.PlatformId);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GamePlatforms)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GamePlatform_Games");

                entity.HasOne(d => d.Platform)
                    .WithMany(p => p.GamePlatforms)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GamePlatform_Platforms");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasIndex(e => e.PublisherId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game_Publishers");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(350);

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<MethodActivations>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<OrderGames>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.GameId });

                entity.HasIndex(e => e.GameId);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.OrderGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderGame_Games");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderGames)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderGame_Orders");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("Order_date")
                    .HasColumnType("date");

                entity.Property(e => e.TotalPrice).HasColumnName("Total_price");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_Users");
            });

            modelBuilder.Entity<Platforms>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
