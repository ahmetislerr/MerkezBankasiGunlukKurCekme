using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerkezBankasiGunlukKurCekme.Application.Models.DTOs
{
	public class ResponseDataDTO
	{
		public List<ExchangeRateDTO> Data { get; set; }
		public string Error { get; set; }
	}
}
