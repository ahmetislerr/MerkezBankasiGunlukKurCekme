using MerkezBankasiGunlukKurCekme.Domain.Entities;
using MerkezBankasiGunlukKurCekme.Domain.Repositories;
using MerkezBankasiGunlukKurCekme.Infrastructure.Contex;

namespace MerkezBankasiGunlukKurCekme.Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}
	}
}
