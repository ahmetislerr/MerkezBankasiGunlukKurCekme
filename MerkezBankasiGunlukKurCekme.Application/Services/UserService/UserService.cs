using MerkezBankasiGunlukKurCekme.Application.Models.DTOs;
using MerkezBankasiGunlukKurCekme.Domain.Entities;
using MerkezBankasiGunlukKurCekme.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace MerkezBankasiGunlukKurCekme.Application.Services.UserService
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;

		//Dependency Injection
		public UserService(UserManager<User> userManager, SignInManager<User> singInManager, IUserRepository userRepository)
		{
			_userManager = userManager;
			_signInManager = singInManager;
			_userRepository = userRepository;
		}

		/// <summary>
		/// Username ile user Tablosunda bulunan User satırını çeker ve UpdateProfileDTO nesnesini doldurmaya yarar.
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public async Task<UpdateProfileDTO> GetByUserName(string userName)
		{
			UpdateProfileDTO result = await _userRepository.GetFilteredFirstOrDefault(
				select: x => new UpdateProfileDTO
				{
					Id = x.Id,
					UserName = x.UserName,
					UserCode = x.UserCode,
					Password = x.PasswordHash,
					Email = x.Email,
				},
				where: x => x.UserName == userName
				);

			return result;
		}

		/// <summary>
		/// Kullanıcının sisteme login olmasını ve user bilgilerine ulaşılabilmeyi sağlar.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<SignInResult> Login(LoginDTO model)
		{
			return await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
		}

		/// <summary>
		/// Sistemden çıkış için kullanır. User bilgileri sessiondan silmeye yarar.
		/// </summary>
		/// <returns></returns>
		public async Task LogOut()
		{
			await _signInManager.SignOutAsync();
		}

		/// <summary>
		/// Yeni bir user oluşturmayı sağlar.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<IdentityResult> Register(RegisterDTO model)
		{
			User user = new User();
			user.UserName = model.UserName;
			user.UserCode = model.UserCode;
			user.Email = model.Email;
			
			IdentityResult result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				await _signInManager.SignInAsync(user, isPersistent: false);
			}

			return result;

		}


		/// <summary>
		/// Id den kullanıcıyı çekerek güncelleme işlemi sağlar.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task UpdateUser(UpdateProfileDTO model)
		{
			User user = await _userRepository.GetDefault(x => x.Id == model.Id);

			

			if (model.Password != null)
			{
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
				await _userManager.UpdateAsync(user);
			}

			if (model.Email != null)
			{
				User isUserEmailExists = await _userManager.FindByEmailAsync(model.Email);

				if (isUserEmailExists == null)
				{
					await _userManager.SetEmailAsync(user, model.Email);
				}
			}
		}
	}
}
