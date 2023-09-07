using MerkezBankasiGunlukKurCekme.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerkezBankasiGunlukKurCekme.Infrastructure.EntityTypeConfig
{
	public abstract class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.Property(x => x.CurrencyCode).IsRequired(true);
			builder.Property(x => x.UserCode).IsRequired(true);
			builder.Property(x => x.Status).IsRequired(true);
		}
	}
}
