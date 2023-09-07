using MerkezBankasiGunlukKurCekme.Application.Models.DTOs;
using System.Xml;

namespace MerkezBankasiGunlukKurCekme.Application.Services.ExchangeRateService
{
	public class ExchangeRateService : IExchangeRateService
	{
		public async Task<ResponseDataDTO> GetToday(RequestDataDTO request)
		{
			ResponseDataDTO result = new ResponseDataDTO();

			try
			{
				string link = string.Format("http://www.tcmb.gov.tr/kurlar/today.xml",request.Day.Equals(true) , request.Day.ToString().PadLeft(2, '0'), request.Month.ToString().PadLeft(2, '0'), request.Year);

				result.Data = new List<ExchangeRateDTO>();

				XmlDocument doc = new XmlDocument();
				doc.Load(link);
				if (doc.SelectNodes("Tarih_Date").Count < 1)
				{
					result.Error = "Currency information not found";
					return result;
				}

				foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
				{
					ExchangeRateDTO exchangeRate = new ExchangeRateDTO();

					exchangeRate.CurrencyCode = node.Attributes["Kod"].Value;
					exchangeRate.Name = node["Isim"].InnerText;
					exchangeRate.Unit = int.Parse(node["Unit"].InnerText);
					exchangeRate.ForexBuying = Convert.ToDecimal("0" + node["ForexBuying"].InnerText.Replace(".", ","));
					exchangeRate.ForexSelling = Convert.ToDecimal("0" + node["ForexSelling"].InnerText.Replace(".", ","));
					exchangeRate.BanknoteBuying = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText.Replace(".", ","));
					exchangeRate.BanknoteSelling = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText.Replace(".", ","));

					result.Data.Add(exchangeRate);
				}
			}
			catch (Exception ex)
			{
				result.Error = ex.Message;
			}


			return result;
		}

		public async Task<ResponseDataDTO> GetSelectTime(RequestDataDTO request)
		{
			ResponseDataDTO result = new ResponseDataDTO();

			try
			{
				string link = string.Format("http://www.tcmb.gov.tr/kurlar/{0}.xml", (request.IsToday) ? "today" : string.Format("{2}{1}/{0}{1}{2}", request.Day.ToString().PadLeft(2, '0'), request.Month.ToString().PadLeft(2, '0'), request.Year));

				result.Data = new List<ExchangeRateDTO>();

				XmlDocument doc = new XmlDocument();
				doc.Load(link);
				if (doc.SelectNodes("Tarih_Date").Count < 1)
				{
					result.Error = "Currency information not found";
					return result;
				}

				foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
				{
					ExchangeRateDTO exchangeRate = new ExchangeRateDTO();

					exchangeRate.CurrencyCode = node.Attributes["Kod"].Value;
					exchangeRate.Name = node["Isim"].InnerText;
					exchangeRate.Unit = int.Parse(node["Unit"].InnerText);
					exchangeRate.ForexBuying = Convert.ToDecimal("0" + node["ForexBuying"].InnerText.Replace(".", ","));
					exchangeRate.ForexSelling = Convert.ToDecimal("0" + node["ForexSelling"].InnerText.Replace(".", ","));
					exchangeRate.BanknoteBuying = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText.Replace(".", ","));
					exchangeRate.BanknoteSelling = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText.Replace(".", ","));

					result.Data.Add(exchangeRate);
				}
			}
			catch (Exception ex)
			{
				result.Error = ex.Message;
			}


			return result;
		}

	}
}
