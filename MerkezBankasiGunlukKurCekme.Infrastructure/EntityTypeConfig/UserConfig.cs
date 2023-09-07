using MerkezBankasiGunlukKurCekme.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerkezBankasiGunlukKurCekme.Infrastructure.EntityTypeConfig
{
	public class UserConfig : BaseEntityConfig<User>
	{
		public override void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);

			//Many to Many ilişkisi
			builder.HasMany(u => u.Currencies).WithMany(c => c.Users);
			builder.HasMany(u => u.ExchangeRates).WithMany(e => e.Users);

			builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(30);
			builder.Property(x => x.Email).IsRequired(true);
			builder.Property(x => x.PasswordHash).IsRequired(true);
			//UserCode, Status, CurrencyCode base entityde zorunlu olduğu için tekrar buraya yazmaya gerek duymadım.

		}
	}
}
