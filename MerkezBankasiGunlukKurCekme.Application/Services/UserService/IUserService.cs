using MerkezBankasiGunlukKurCekme.Application.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace MerkezBankasiGunlukKurCekme.Application.Services.UserService
{
    public interface IUserService
    {
        Task<IdentityResult> Register(RegisterDTO model);
        Task<SignInResult> Login(LoginDTO model);
        Task<UpdateProfileDTO> GetByUserName(string userName);

        Task UpdateUser(UpdateProfileDTO model);

        Task LogOut();
    }
}
