using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Entities.Models.User;

namespace WanderersDiary.Entities.Models.Auth
{
    public class RefreshToken : EntityBase
    {
        public string Token { get; set; }
        public bool IsUsed { get; set; } 
        public bool IsRevoked { get; set; } 
        public DateTime ExpiryDate { get; set; } 

        public Wanderer User { get; set; }
    }
}
