using MerkezBankasiGunlukKurCekme.Domain.Entities;
using MerkezBankasiGunlukKurCekme.Domain.Repositories;
using MerkezBankasiGunlukKurCekme.Infrastructure.Contex;

namespace MerkezBankasiGunlukKurCekme.Infrastructure.Repositories
{
	public class ExchangeRateRepository : BaseRepository<ExchangeRate>, IExchangeRateRepository
	{
		public ExchangeRateRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}
	}
}
