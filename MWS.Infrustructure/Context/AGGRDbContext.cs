using Microsoft.EntityFrameworkCore;
using MWS.Data.Entities;

namespace MWS.Infrustructure.Context
{
	public class AGGRDbContext : DbContext
	{

		public AGGRDbContext(DbContextOptions<AGGRDbContext> options) : base(options)
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

		}

		public DbSet<User> users { get; set; }
		public DbSet<Localization> localizations { get; set; }
		public DbSet<Language> languages { get; set; }
		public DbSet<Currency> currency { get; set; }
		public DbSet<Contact> contacts { get; set; }
		public DbSet<Day> days { get; set; }
		public DbSet<TourDay> tourDays { get; set; }
		public DbSet<Include> includes { get; set; }
		public DbSet<Exclude> excludes { get; set; }
		public DbSet<Pack> packs { get; set; }
		public DbSet<HotelType> hotelType { get; set; }
		public DbSet<HotelRoomPricing> hotelRoomPricing { get; set; }
		public DbSet<RoomType> roomType { get; set; }
		public DbSet<TourAttachment> tourAttachments { get; set; }
		public DbSet<Expect> expects { get; set; }
		public DbSet<Tour> tours { get; set; }
		public DbSet<Booking> booking { get; set; }
		public DbSet<SpecialRequest> specialRequests { get; set; }
		public DbSet<Role> roles { get; set; }
		public DbSet<Permission> permissions { get; set; }
		public DbSet<RolePermission> rolePermissions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("users").HasKey(e => e.userId);
			modelBuilder.Entity<Localization>().ToTable("localizations");
			modelBuilder.Entity<Language>().ToTable("languages");
			modelBuilder.Entity<Currency>().ToTable("currency");
			modelBuilder.Entity<Tour>().ToTable("tours");
			modelBuilder.Entity<Contact>().ToTable("contacts");
			modelBuilder.Entity<Day>().ToTable("days");
			modelBuilder.Entity<TourDay>().ToTable("tourDays");
			modelBuilder.Entity<Include>().ToTable("includes");
			modelBuilder.Entity<Exclude>().ToTable("excludes");
			modelBuilder.Entity<Pack>().ToTable("packs");
			modelBuilder.Entity<HotelType>().ToTable("hotelType");
			modelBuilder.Entity<HotelRoomPricing>().ToTable("hotelRoomPricing");
			modelBuilder.Entity<RoomType>().ToTable("roomType");
			modelBuilder.Entity<TourAttachment>().ToTable("tourAttachments");
			modelBuilder.Entity<Expect>().ToTable("expects");
			modelBuilder.Entity<Booking>().ToTable("booking");
			modelBuilder.Entity<SpecialRequest>().ToTable("specialRequests");
			modelBuilder.Entity<Permission>().ToTable("permissions").HasMany(e => e.roles).WithMany(e => e.permissions);
			modelBuilder.Entity<RolePermission>().ToTable("rolePermissions").HasKey(e => e.rolePermissionsId);
			modelBuilder.Entity<Role>().ToTable("roles").HasMany(e => e.users).WithOne(e => e.role);
			//modelBuilder.Entity<MotorAggrLogs>().ToTable("MOTORAGGRLOGS", "NONMED").HasKey(m => new { m.trxNo, m.docCode, m.docId });
		}

	}
}
