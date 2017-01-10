using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleEngine
{
    // **************************************************************************************
    //  Skill Class
    // *************************************************************************************
    class Skill
    {
        public Skill(string displayName, int attackPoint, int coolDownInterval, int weight)
        {
            SkillDisplayName = displayName;
            AttackPoint = attackPoint;
            Weight = weight;
            CoolDownInterval = coolDownInterval;
        }

        public string SkillDisplayName { get; protected set; } = "";
        public int AttackPoint { get; protected set; } = 0;
        public int Weight { get; protected set; } = 0;
        public int CoolDownInterval { get; protected set; } = 0;

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
