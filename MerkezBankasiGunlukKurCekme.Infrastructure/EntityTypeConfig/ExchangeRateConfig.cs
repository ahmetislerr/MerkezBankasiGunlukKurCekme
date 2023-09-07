using MerkezBankasiGunlukKurCekme.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerkezBankasiGunlukKurCekme.Infrastructure.EntityTypeConfig
{
	public class ExchangeRateConfig : BaseEntityConfig<ExchangeRate>
	{
		public override void Configure(EntityTypeBuilder<ExchangeRate> builder)
		{
			builder.HasKey(x => x.CurrencyCode); //Many to Many ilişkileri UserConfig ve CurrencyConfig de yapıldığı için tekrar yazmaya gerek yok.
			builder.Property(x => x.Date).IsRequired(true);
			builder.Property(x => x.ForexSelling).IsRequired(true);
			builder.Property(x => x.ForexBuying).IsRequired(true);
			builder.Property(x => x.BanknoteSelling).IsRequired(true);
			builder.Property(x => x.BanknoteBuying).IsRequired(true);
			builder.Property(x => x.Unit).IsRequired(true);
			//UserCode, Status, CurrencyCode base entityde zorunlu olduğu için tekrar buraya yazmaya gerek duymadım.
		}
	}
}
