using MerkezBankasiGunlukKurCekme.Domain.Enums;

namespace MerkezBankasiGunlukKurCekme.Domain.Entities
{
	public class Currency : IBaseEntity
	{
		public string CurrencyCode { get; set; }
		public string Country { get; set; }
		public string Symbol { get; set; }
		public string UserCode { get; set; }
		public Status Status { get; set; }

		//Navigation Properties
		public List<User> Users { get; set; }
		public List<ExchangeRate> ExchangeRates { get; set; }

		public Currency()
		{
			Users = new List<User>();
			ExchangeRates = new List<ExchangeRate>();
		}
	}
}
