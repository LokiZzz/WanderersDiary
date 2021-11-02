using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Entities.Models.Auth;

namespace WanderersDiary.Entities.Models.User
{
    public class Wanderer : IdentityUser
    {
        public string DisplayName { get; set; }

        public HashSet<RefreshToken> RegreshTokens { get; set; }
        public HashSet<Character> Characters { get; set; }
    }
}
