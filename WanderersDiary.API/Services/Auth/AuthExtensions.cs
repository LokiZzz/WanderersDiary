﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WanderersDiary.API.Services.Auth
{
    public static  class AuthExtensions
    {
        public static async Task<IdentityUser> GetIdentityUserAsync(this UserManager<IdentityUser> userManager, ClaimsPrincipal claimsPrincipal)
        {
            string value = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await userManager.FindByIdAsync(value);
        }

        public static string GetId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
