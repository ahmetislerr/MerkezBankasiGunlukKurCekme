﻿using MerkezBankasiGunlukKurCekme.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerkezBankasiGunlukKurCekme.Domain.Entities
{
	public interface IBaseEntity
	{
		public string UserCode { get; set; }
		public string CurrencyCode { get; set; }
		public Status Status { get; set; }
	}
}
