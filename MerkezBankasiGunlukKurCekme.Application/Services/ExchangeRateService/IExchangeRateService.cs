using MerkezBankasiGunlukKurCekme.Application.Models.DTOs;

namespace MerkezBankasiGunlukKurCekme.Application.Services.ExchangeRateService
{
	public interface IExchangeRateService
	{
		public Task<ResponseDataDTO> GetToday(RequestDataDTO request);
		public Task<ResponseDataDTO> GetSelectTime(RequestDataDTO request);
	}
}
