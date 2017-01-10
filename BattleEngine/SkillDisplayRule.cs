using Newtonsoft.Json;

namespace BattleEngine
{
    // **************************************************************************************
    // SkillDisplayRule Class
    // **************************************************************************************
    class SkillDisplayRule
    {
        /*public SkillDisplayRule(string text, int weight)
        {
            DisplayText = text;
            Weight = weight;
        }*/
        [JsonProperty("DisplayText")]
        public string DisplayText { get; set; }
        [JsonProperty("Weight")]
        public int Weight { get; set;  }
    }
}
