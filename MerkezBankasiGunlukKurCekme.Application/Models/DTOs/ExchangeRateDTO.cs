using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerkezBankasiGunlukKurCekme.Application.Models.DTOs
{
	public class ExchangeRateDTO
	{
		public string CurrencyCode { get; set; }
		public string Name { get; set; }
		public int Unit { get; set; }
		public decimal ForexBuying { get; set; }
		public decimal ForexSelling { get; set; }
		public decimal BanknoteBuying { get; set; }
		public decimal BanknoteSelling { get; set; }
	}
}
