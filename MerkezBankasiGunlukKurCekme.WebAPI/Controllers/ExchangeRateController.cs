using MerkezBankasiGunlukKurCekme.Application.Models.DTOs;
using MerkezBankasiGunlukKurCekme.Application.Services.ExchangeRateService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerkezBankasiGunlukKurCekme.WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ExchangeRateController : ControllerBase
	{
		private readonly IExchangeRateService _exchangeRateService;

		public ExchangeRateController(IExchangeRateService exchangeRateService)
		{
			_exchangeRateService = exchangeRateService;
		}


		[HttpPost]
		public async Task<IActionResult> GetToday([FromBody] RequestDataDTO request)
		{
			return Ok( _exchangeRateService.GetToday(request));
			
		}

		[HttpPost]
		public async Task<IActionResult> GetSelectTime([FromBody] RequestDataDTO request)
		{
			return Ok(_exchangeRateService.GetSelectTime(request));

		}
	}
}
