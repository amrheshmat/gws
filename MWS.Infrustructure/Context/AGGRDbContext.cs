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
		public DbSet<Seo> seo { get; set; }
		public DbSet<Blog> blogs { get; set; }
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
		public DbSet<BlockedDates> blockedDates { get; set; }
		public DbSet<Tour> tours { get; set; }
		public DbSet<Booking> booking { get; set; }
		public DbSet<Setting> settings { get; set; }
		public DbSet<WhyChooseUs> whyChooseUs { get; set; }
		public DbSet<Faq> faqs { get; set; }
		public DbSet<Facilities> facilities { get; set; }
		public DbSet<About> abouts { get; set; }
		public DbSet<Term> terms { get; set; }
		public DbSet<AdditionalInformation> additionalInformation { get; set; }
		public DbSet<SpecialRequest> specialRequests { get; set; }
		public DbSet<Role> roles { get; set; }
		public DbSet<Permission> permissions { get; set; }
		public DbSet<RolePermission> rolePermissions { get; set; }
		public DbSet<TourLanguage> tourLanguages { get; set; }
		public DbSet<AdditionalActivity> additionalActivities { get; set; }
		public DbSet<BookAdditionalActivity> bookAdditionalActivities { get; set; }
		public DbSet<TourAdditionalActivity> tourAdditionalActivities { get; set; }
		public DbSet<FacebookToken> facebookTokens { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("users").HasKey(e => e.userId);
			modelBuilder.Entity<Seo>().ToTable("seo");
			modelBuilder.Entity<FacebookToken>().ToTable("facebookTokens");
			modelBuilder.Entity<Blog>().ToTable("blogs");
			modelBuilder.Entity<Localization>().ToTable("localizations");
			modelBuilder.Entity<AdditionalActivity>().ToTable("additionalActivities");
			modelBuilder.Entity<BookAdditionalActivity>().ToTable("bookAdditionalActivities");
			modelBuilder.Entity<TourAdditionalActivity>().ToTable("tourAdditionalActivities");
			modelBuilder.Entity<Language>().ToTable("languages");
			modelBuilder.Entity<Currency>().ToTable("currency");
			modelBuilder.Entity<Tour>().ToTable("tours");
			modelBuilder.Entity<Contact>().ToTable("contacts");
			modelBuilder.Entity<Day>().ToTable("days");
			modelBuilder.Entity<TourDay>().ToTable("tourDays");
			modelBuilder.Entity<TourLanguage>().ToTable("tourLanguages");
			modelBuilder.Entity<Include>().ToTable("includes");
			modelBuilder.Entity<Exclude>().ToTable("excludes");
			modelBuilder.Entity<Pack>().ToTable("packs");
			modelBuilder.Entity<HotelType>().ToTable("hotelType");
			modelBuilder.Entity<HotelRoomPricing>().ToTable("hotelRoomPricing");
			modelBuilder.Entity<RoomType>().ToTable("roomType");
			modelBuilder.Entity<TourAttachment>().ToTable("tourAttachments");
			modelBuilder.Entity<Expect>().ToTable("expects");
			modelBuilder.Entity<BlockedDates>().ToTable("blockedDates");
			modelBuilder.Entity<Booking>().ToTable("booking");
			modelBuilder.Entity<Setting>().ToTable("settings");
			modelBuilder.Entity<WhyChooseUs>().ToTable("whyChooseUs");
			modelBuilder.Entity<Faq>().ToTable("faqs");
			modelBuilder.Entity<Facilities>().ToTable("facilities");
			modelBuilder.Entity<About>().ToTable("abouts");
			modelBuilder.Entity<Term>().ToTable("terms");
			modelBuilder.Entity<AdditionalInformation>().ToTable("additionalInformations");
			modelBuilder.Entity<SpecialRequest>().ToTable("specialRequests");
			modelBuilder.Entity<Permission>().ToTable("permissions").HasMany(e => e.roles).WithMany(e => e.permissions);
			modelBuilder.Entity<RolePermission>().ToTable("rolePermissions").HasKey(e => e.rolePermissionsId);
			modelBuilder.Entity<Role>().ToTable("roles").HasMany(e => e.users).WithOne(e => e.role);
			//modelBuilder.Entity<MotorAggrLogs>().ToTable("MOTORAGGRLOGS", "NONMED").HasKey(m => new { m.trxNo, m.docCode, m.docId });
		}

	}
}
