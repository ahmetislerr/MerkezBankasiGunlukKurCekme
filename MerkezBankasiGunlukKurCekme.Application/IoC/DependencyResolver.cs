using Autofac;
using AutoMapper;
using MerkezBankasiGunlukKurCekme.Application.AutoMapper;
using MerkezBankasiGunlukKurCekme.Application.Services.ExchangeRateService;
using MerkezBankasiGunlukKurCekme.Application.Services.UserService;
using MerkezBankasiGunlukKurCekme.Domain.Repositories;
using MerkezBankasiGunlukKurCekme.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerkezBankasiGunlukKurCekme.Application.IoC
{
	public class DependencyResolver : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
			builder.RegisterType<ExchangeRateService>().As<IExchangeRateService>().InstancePerLifetimeScope();
			builder.RegisterType<CurrencyRepository>().As<ICurrencyRepository>().InstancePerLifetimeScope();
			builder.RegisterType<ExchangeRateRepository>().As<IExchangeRateRepository>().InstancePerLifetimeScope();
			builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
			builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();




			#region AutoMapper
			builder.Register(context => new MapperConfiguration(cfg =>
			{
				//Register Mapper Profile
				cfg.AddProfile<Mapping>(); /// AutoMapper klasörünün altına eklediğimiz Mapping classını bağlıyoruz.
			}
			 )).AsSelf().SingleInstance();


			builder.Register(c =>
			{
				var context = c.Resolve<IComponentContext>();
				var config = context.Resolve<MapperConfiguration>();
				return config.CreateMapper(context.Resolve);
			})
			.As<IMapper>()
			.InstancePerLifetimeScope();
			#endregion

			base.Load(builder);
		}
	}
}
