using MerkezBankasiGunlukKurCekme.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace MerkezBankasiGunlukKurCekme.Domain.Entities
{
	public class User : IdentityUser, IBaseEntity
	{
		public string UserCode { get; set; }
		public string CurrencyCode { get; set; }
		public Status Status { get; set; }


		//Navigation Properties
		public List<Currency> Currencies { get; set; }
		public List<ExchangeRate> ExchangeRates { get; set; }

		public User()
		{
			Currencies = new List<Currency>();
			ExchangeRates = new List<ExchangeRate>();
		}
	}
}
