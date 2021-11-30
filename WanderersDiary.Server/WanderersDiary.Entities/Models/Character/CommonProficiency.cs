using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Contracts.Game;

namespace WanderersDiary.Entities.Models.Character
{
    public class CommonProficiency
    {
        /// <summary>
        /// Tool, language, vehicle, etc.
        /// </summary>
        public string Competence { get; set; }

        public EProficiency Proficiency { get; set; }
    }
}
