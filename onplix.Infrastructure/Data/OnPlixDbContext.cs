using Microsoft.EntityFrameworkCore;
using onplix.Domain.Entities;

namespace onplix.Infrastructure.Data
{
	public partial class OnPlixDbContext : DbContext
	{
		public OnPlixDbContext() { }
		public OnPlixDbContext(DbContextOptions<OnPlixDbContext> options) : base(options) { }

		public DbSet<Account> Accounts { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<Plan> Plans { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<Title> Titles { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<TitleGenre> TitleGenres { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Credit> Credits { get; set; }
		public DbSet<FilmMember> FilmMembers { get; set; }
		public DbSet<Series> Series { get; set; }
		public DbSet<Season> Seasons { get; set; }
		public DbSet<Episode> Episodes { get; set; }
		public DbSet<MediaAsset> MediaAssets { get; set; }
		public DbSet<WatchHistory> WatchHistories { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("Server=localhost,1433;Database=onplixDb;User Id=sa;Password=onplix@123;TrustServerCertificate=True;");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Account
			modelBuilder.Entity<Account>(entity =>
			{
				entity.HasKey(e => new { e.Id, e.Email });
				entity.Property(e => e.Email).HasMaxLength(256).IsRequired();
				entity.Property(e => e.DisplayName).HasMaxLength(25);
				entity.Property(e => e.MaturityRating).HasMaxLength(100);
				entity.Property(e => e.IsActive).HasMaxLength(1);
				entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
				entity.Property(e => e.UpdatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
			});

			// Series
			modelBuilder.Entity<Series>(entity =>
			{
				entity.HasKey(e => new { e.Id, e.TitleId });
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
				entity.Property(e => e.UpdatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
			});

			// Subscription
			modelBuilder.Entity<Subscription>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
				entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
				entity.Property(e => e.UpdatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
				entity.Property(e => e.CurrentPeriodStart).HasColumnType("datetime");
				entity.Property(e => e.CurrentPeriodEnd).HasColumnType("datetime");
				entity.Property(e => e.CancelAt).HasColumnType("datetime");
			});

			// Plan
			modelBuilder.Entity<Plan>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).HasMaxLength(256).IsRequired();
				entity.Property(e => e.Currency).HasMaxLength(50);
				entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
			});

			// PaymentMethod
			modelBuilder.Entity<PaymentMethod>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
			});

			// MediaAsset
			modelBuilder.Entity<MediaAsset>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.ContentRefType).HasMaxLength(50);
				entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
			});

			// Title
			modelBuilder.Entity<Title>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Type).HasMaxLength(15);
				entity.Property(e => e.Name).HasMaxLength(256);
				entity.Property(e => e.ReleasedYear).HasMaxLength(4);
				entity.Property(e => e.MaturityRating).HasMaxLength(100);
			});

			// Review
			modelBuilder.Entity<Review>(entity =>
			{
				entity.HasKey(e => e.Id);
			});

			// TitleGenre
			modelBuilder.Entity<TitleGenre>(entity =>
			{
				entity.HasKey(e => new { e.TitleId, e.GenreId });
			});

			// Genre
			modelBuilder.Entity<Genre>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).HasMaxLength(256);
				entity.Property(a => a.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
				entity.Property(a => a.UpdatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
			});

			// Credit
			modelBuilder.Entity<Credit>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(a => a.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
				entity.Property(a => a.UpdatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");

			});

			// TitleGenre
			modelBuilder.Entity<FavoriteTitle>(entity =>
			{
				entity.HasKey(e => new { e.TitleId, e.AccountId });
				entity.Property(a => a.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
				entity.Property(a => a.UpdatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
			});

			// Episode
			modelBuilder.Entity<Season>(entity =>
			{
				entity.HasKey(e => new { e.Id, e.SeriesId });
				entity
					.HasOne(e => e.Series)
					.WithMany(t => t.Seasons)
					.HasForeignKey(e => e.SeriesId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Seasons__Series__6477ECF3");
			});

			// Episode
			modelBuilder.Entity<Episode>(entity =>
			{
				entity.HasKey(e => new { e.Id, e.SeasonId, e.SeriesId });
				entity
					.HasOne(e => e.Season)
					.WithMany(t => t.Episodes)
					.HasForeignKey(e => e.SeasonId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Episodes__Season__6477ECF3");
			});

			modelBuilder.Entity<Operator>(entity =>
			{
				entity.Property(a => a.Email).HasMaxLength(256).IsRequired();
				entity.Property(a => a.DisplayName).HasMaxLength(255);
				entity.Property(a => a.Role).HasMaxLength(50).IsRequired();
				entity.Property(a => a.IsActive).HasDefaultValue(true);
				entity.Property(a => a.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
				entity.Property(a => a.UpdatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
			});
		}
	} 
}
