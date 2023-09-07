using AutoMapper;
using MerkezBankasiGunlukKurCekme.Application.Models.DTOs;
using MerkezBankasiGunlukKurCekme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerkezBankasiGunlukKurCekme.Application.AutoMapper
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			CreateMap<ExchangeRate,ExchangeRateDTO>().ReverseMap();
			CreateMap<User,RegisterDTO>().ReverseMap();
			CreateMap<User,LoginDTO>().ReverseMap();
			CreateMap<User,UpdateProfileDTO>().ReverseMap();

		}
	}
}
