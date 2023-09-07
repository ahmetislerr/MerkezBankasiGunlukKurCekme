using MerkezBankasiGunlukKurCekme.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerkezBankasiGunlukKurCekme.Application.Models.DTOs
{
	public class RegisterDTO
	{
		public string UserName { get; set; }
		public string UserCode { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string Email { get; set; }
		public Status Status => Status.Active;
	}
}
