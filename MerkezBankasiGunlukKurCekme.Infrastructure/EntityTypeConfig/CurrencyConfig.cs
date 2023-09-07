using MerkezBankasiGunlukKurCekme.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerkezBankasiGunlukKurCekme.Infrastructure.EntityTypeConfig
{
	public class CurrencyConfig : BaseEntityConfig<Currency>
	{
		public override void Configure(EntityTypeBuilder<Currency> builder)
		{
			builder.HasKey(x => x.CurrencyCode);

			//Many to Many ilişkisi. User ile bağlantısı UserConfigde yapıldığı için tekrar yapmaya gerek yok.
			builder.HasMany(c => c.ExchangeRates).WithMany(e => e.Currencies);

			builder.Property(x => x.Country).IsRequired(true);
			builder.Property(x => x.Symbol).IsRequired(true);
			//UserCode, Status, CurrencyCode base entityde zorunlu olduğu için tekrar buraya yazmaya gerek duymadım.
		}
	}
}
