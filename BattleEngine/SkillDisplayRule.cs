using Newtonsoft.Json;
using System;

namespace BattleEngine
{
    // **************************************************************************************
    // SkillDisplayRule Class
    // **************************************************************************************
    class SkillDisplayRule : ICloneable<SkillDisplayRule>
    {
        [JsonProperty("DisplayText")]
        public string DisplayText { get; set; }
        [JsonProperty("Weight")]
        public int Weight { get; set;  }

        // **************************************************************************************
        // Methods to handle clone
        // **************************************************************************************
        public SkillDisplayRule Clone()
        {
            //Creates a shallow copy of the current 
            SkillDisplayRule clone = (SkillDisplayRule)this.MemberwiseClone();
            return clone;
        }
    }
}
