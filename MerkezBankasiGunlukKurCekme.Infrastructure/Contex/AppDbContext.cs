using MerkezBankasiGunlukKurCekme.Domain.Entities;
using MerkezBankasiGunlukKurCekme.Infrastructure.EntityTypeConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MerkezBankasiGunlukKurCekme.Infrastructure.Contex
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext (DbContextOptions<AppDbContext> options) : base (options)
		{

		}

		public DbSet<Currency> Currencies { get; set; }
		public DbSet<ExchangeRate> ExchangeRates { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//Mapping Fluent API işlemleri
			builder.ApplyConfiguration(new CurrencyConfig());
			builder.ApplyConfiguration(new ExchangeRateConfig());
			builder.ApplyConfiguration(new UserConfig());

			base.OnModelCreating(builder);
		}
	}
}
