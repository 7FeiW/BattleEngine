using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleEngine
{
    class Skill
    {
        public Skill(string displayName, int attackPoint, int coolDownInterval, int weight)
        {
            SkillDisplayName = displayName;
            AttackPoint = attackPoint;
            Weight = weight;
            mSkillDisplayRules = new List<SkillDisplayRule>();
            mSumOfDisplayRuleWeight = 0;
            CoolDownInterval = coolDownInterval;
        }

        public string SkillDisplayName { get; }
        public int AttackPoint { get; }
        private List<SkillDisplayRule> mSkillDisplayRules;
        private int mSumOfDisplayRuleWeight;
        public int Weight { get; set; }
        public int CoolDownInterval { get; }


        // **************************************************************************************
        //  Method To add skill dispay rule
        //  TODO: need find better name than weight
        //  weight value here is not the actually weight
        // **************************************************************************************
        public void AddSkillDisplayRules(string text, int weight)
        {
            mSumOfDisplayRuleWeight += weight;
            var rule = new SkillDisplayRule(text, mSumOfDisplayRuleWeight);
            mSkillDisplayRules.Add(rule);
        }

        // **************************************************************************************
        // Return Display Text for current Skill
        // Display Text is random picked based on weight
        // **************************************************************************************
        public string GetDisplayText()
        {
            Random random = new Random();
            int randomInt = random.Next(0, mSumOfDisplayRuleWeight);
            string skillDisplayRule = mSkillDisplayRules.OrderBy(s => s.Weight).ToList().First(s => s.Weight > randomInt).Text;
            return skillDisplayRule;
        }
    }
}
