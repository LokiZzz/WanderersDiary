using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WanderersDiary.Contracts.Game;

namespace WanderersDiary.Entities.Models.Character
{
    public class SkillProficiency : EntityBase
    {
        public ESkill Skill { get; set; }

        public EProficiency Proficiency { get; set; }
    }
}
