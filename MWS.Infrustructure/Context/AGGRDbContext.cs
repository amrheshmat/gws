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
		public DbSet<Session> sessions { get; set; }
		public DbSet<Localization> localizations { get; set; }
		public DbSet<Language> languages { get; set; }
		public DbSet<Currency> currency { get; set; }
		public DbSet<Contact> contacts { get; set; }
		public DbSet<Setting> settings { get; set; }
		public DbSet<WhyChooseUs> whyChooseUs { get; set; }
		public DbSet<Faq> faqs { get; set; }
		public DbSet<About> abouts { get; set; }
		public DbSet<Term> terms { get; set; }
		public DbSet<Role> roles { get; set; }
		public DbSet<Permission> permissions { get; set; }
		public DbSet<RolePermission> rolePermissions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("users").HasKey(e => e.userId);
			modelBuilder.Entity<Session>().ToTable("sessions");
			modelBuilder.Entity<Localization>().ToTable("localizations");
			modelBuilder.Entity<Language>().ToTable("languages");
			modelBuilder.Entity<Currency>().ToTable("currency");
			modelBuilder.Entity<Contact>().ToTable("contacts");
			modelBuilder.Entity<RoomType>().ToTable("roomType");
			modelBuilder.Entity<Setting>().ToTable("settings");
			modelBuilder.Entity<WhyChooseUs>().ToTable("whyChooseUs");
			modelBuilder.Entity<Faq>().ToTable("faqs");
			modelBuilder.Entity<About>().ToTable("abouts");
			modelBuilder.Entity<Term>().ToTable("terms");
			modelBuilder.Entity<Permission>().ToTable("permissions").HasMany(e => e.roles).WithMany(e => e.permissions);
			modelBuilder.Entity<RolePermission>().ToTable("rolePermissions").HasKey(e => e.rolePermissionsId);
			modelBuilder.Entity<Role>().ToTable("roles").HasMany(e => e.users).WithOne(e => e.role);
			//modelBuilder.Entity<MotorAggrLogs>().ToTable("MOTORAGGRLOGS", "NONMED").HasKey(m => new { m.trxNo, m.docCode, m.docId });
		}

	}
}
