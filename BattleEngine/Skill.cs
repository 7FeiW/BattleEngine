using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BattleEngine
{
    // **************************************************************************************
    //  Skill Class
    // *************************************************************************************
    class Skill
    {
        /*public Skill(string displayName, int attackPoint, int coolDownInterval, int weight)
        {
            Name = displayName;
            AttackPoints = attackPoint;
            Weight = weight;
            CoolDownInterval = coolDownInterval;
        }*/

        [JsonProperty("SkillName")]
        public string Name { get; set; } = "";
        [JsonProperty("AttackPoints")]
        public int AttackPoints { get; protected set; } = 0;
        [JsonProperty("Weight")]
        public int Weight { get;set; } = 0;
        [JsonProperty("CoolDownInterval")]
        public int CoolDownInterval { get; protected set; } = 0;

        [JsonProperty("SkillDisplayRules")]
        private List<SkillDisplayRule> mSkillDisplayRules = new List<SkillDisplayRule>();
        private int mSumOfDisplayRuleWeight = 0;



        // **************************************************************************************
        //  Method To add skill dispay rule
        //  TODO: need find better name than weight
        //  weight value here is not the actually weight
        // **************************************************************************************
        public void AddSkillDisplayRules(string text, int weight)
        {
            mSumOfDisplayRuleWeight += weight;
            var rule = new SkillDisplayRule();
            rule.DisplayText = text;
            rule.Weight = mSumOfDisplayRuleWeight;
            mSkillDisplayRules.Add(rule);
        }

        // **************************************************************************************
        // Return Display Text for current Skill
        // Display Text is random picked based on weight
        // **************************************************************************************
        public string GetDisplayText()
        {
            var random = new Random();
            var randomInt = random.Next(0, mSumOfDisplayRuleWeight);
            var skillDisplayRule = mSkillDisplayRules.OrderBy(s => s.Weight).ToList().First(s => s.Weight > randomInt).DisplayText;
            return skillDisplayRule;
        }

        //***************************************************************************************
        // OnDeserialized
        // Update skill weight after deserialized
        //***************************************************************************************
        [OnDeserialized]
        internal void OnDeserializedHandler(StreamingContext context)
        {
            foreach (var skillDisplayRule in mSkillDisplayRules)
            {
                mSumOfDisplayRuleWeight += skillDisplayRule.Weight;
                skillDisplayRule.Weight = mSumOfDisplayRuleWeight;
            }
        }
    }
}
