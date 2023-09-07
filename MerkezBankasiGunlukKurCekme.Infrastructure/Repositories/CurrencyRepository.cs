using MerkezBankasiGunlukKurCekme.Domain.Entities;
using MerkezBankasiGunlukKurCekme.Domain.Repositories;
using MerkezBankasiGunlukKurCekme.Infrastructure.Contex;

namespace MerkezBankasiGunlukKurCekme.Infrastructure.Repositories
{
	public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
	{
		public CurrencyRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}
	}
}
