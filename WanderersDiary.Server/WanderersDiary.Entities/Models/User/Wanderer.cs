using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Entities.Models.Auth;
using WanderersDiary.Entities.Character;

namespace WanderersDiary.Entities.Models.User
{
    public class Wanderer : IdentityUser
    {
        public string DisplayName { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; }

        public ICollection<Entities.Character.Character> Characters { get; set; }
    }
}
