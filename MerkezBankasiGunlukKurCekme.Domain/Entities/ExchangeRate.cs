using MerkezBankasiGunlukKurCekme.Domain.Enums;

namespace MerkezBankasiGunlukKurCekme.Domain.Entities
{
	public class ExchangeRate : IBaseEntity
	{
		public DateTime Date { get; set; }
		public string CurrencyCode { get; set; }
		public string Name { get; set; }
		public int Unit { get; set; }
		public decimal ForexBuying { get; set; }
		public decimal ForexSelling { get; set; }
		public decimal BanknoteBuying { get; set; }
		public decimal BanknoteSelling { get; set; }
		public string UserCode { get; set; }
		public Status Status { get; set; }

		//Navigation Properties
		public List<User> Users { get; set; }
		public List<Currency> Currencies { get; set; }

		public ExchangeRate()
		{
			Users = new List<User>();
			Currencies = new List<Currency>();
		}
	}
}
