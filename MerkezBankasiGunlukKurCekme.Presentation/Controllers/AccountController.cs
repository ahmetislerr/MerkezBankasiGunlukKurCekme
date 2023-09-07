using MerkezBankasiGunlukKurCekme.Application.Models.DTOs;
using MerkezBankasiGunlukKurCekme.Application.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MerkezBankasiGunlukKurCekme.Presentation.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private readonly IUserService _userService;

		public AccountController(IUserService appUserService)
		{
			_userService = appUserService;
		}

		[HttpGet]
		[AllowAnonymous] //Authorize kısıtlaması olsa bile action a erişimi sağlaması için.
		public IActionResult Register()
		{
			if (User.Identity.IsAuthenticated) //Sistemde Authenticate olmuş kullanıcı varsa register sayfasını görmemesi için.
			{
				return RedirectToAction("Index", "");
			}

			return View();
		}


		[HttpPost, AllowAnonymous]
		public async Task<IActionResult> Register(RegisterDTO model)
		{
			if (ModelState.IsValid)
			{
				var result = await _userService.Register(model);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "");
				}

				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(string.Empty, item.Description);
					TempData["Error"] = "Something went wrong";
				}
			}
			return View(model);
		}

		[AllowAnonymous]
		public IActionResult Login(string returnUrl = "/")
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "");
			}

			ViewData["ReturnUrl"] = returnUrl;

			return View();

		}

		[HttpPost, AllowAnonymous]
		public async Task<IActionResult> Login(LoginDTO model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				var result = await _userService.Login(model);

				if (result.Succeeded)
				{
					return RedirectToLocal(returnUrl);
				}

				ModelState.AddModelError("", "Invalid Login Attempt");
			}

			return View(model);

		}

		public async Task<IActionResult> LogOut()
		{
			await _userService.LogOut();
			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> Edit(string userName)
		{

			return View(await _userService.GetByUserName(userName));
		}

		[HttpPost]
		public async Task<IActionResult> Edit(UpdateProfileDTO model)
		{
			if (ModelState.IsValid)
			{
				await _userService.UpdateUser(model);
				return RedirectToAction("details");
			}
			return RedirectToAction("edit");
		}



		private IActionResult RedirectToLocal(string returnUrl = "/")
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction("index", "");
			}
		}
	}
}
