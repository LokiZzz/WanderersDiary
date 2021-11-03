using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WanderersDiary.Entities.Models.User;

namespace WanderersDiary.API.Services.Auth
{
    public static  class AuthExtensions
    {
        public static async Task<Wanderer> GetIdentityUserAsync(this UserManager<Wanderer> userManager, ClaimsPrincipal claimsPrincipal)
        {
            string value = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await userManager.FindByIdAsync(value);
        }

        public static string GetId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static DateTime GetExpiryDate(this ClaimsPrincipal claimsPrincipal)
        {
            long utcExpiryDate = long.Parse(claimsPrincipal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            
            return UnixTimeStampToDateTime(utcExpiryDate);
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();

            return dtDateTime;
        }
    }
}
