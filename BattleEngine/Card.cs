using System.Collections.Generic;
using System;
using System.Linq;

namespace BattleEngine
{
    // **************************************************************************************
    // Card Class
    // **************************************************************************************
    class Card
    {
        public Card(string name, int healthPoint)
        {
            Name = name;
            HealthPoint = healthPoint;
            
            // init rests
            mSumOfWeights = 0;
            mCurrentSkillIndex = -1;
            IsAlive = true;
            CoolDownTime = 0;
            mSkills = new List<Skill>();
        }

        public string Name { get; private set; }
        public int HealthPoint { get; private  set; }

        public bool IsAlive { get; private set; }
        public int CoolDownTime { get; private set; }
        private List<Skill> mSkills;
        private int mCurrentSkillIndex;
        private int mSumOfWeights;

        private int takeAction()
        {
            Random random = new Random();
            int randomInt = random.Next(0, mSumOfWeights);
            mCurrentSkillIndex = mSkills.OrderBy(s => s.Weight).ToList().FindIndex(s => s.Weight > randomInt);
            return mCurrentSkillIndex;
        }

        // **************************************************************************************
        // Method to Get Current  Action
        // **************************************************************************************
        public Action GetCurrentAction()
        {
            takeAction();
            CoolDownTime = mSkills[mCurrentSkillIndex].CoolDownInterval;
            var action = new Action(mSkills[mCurrentSkillIndex].GetDisplayText(), mSkills[mCurrentSkillIndex].AttackPoint);
            return action;
        }

        // **************************************************************************************
        // Method to Add Skill to this Card
        // **************************************************************************************
        public void AddSkill(Skill skill)
        {
            mSumOfWeights += skill.Weight;
            skill.Weight = mSumOfWeights;
            mSkills.Add(skill);
        }

        // **************************************************************************************
        // Method to Update Health Point and return health Point after update
        // **************************************************************************************
        public int UpdateHealthPoint(int updateByValue)
        {
            HealthPoint += updateByValue;
            IsAlive = HealthPoint > 0;
            return HealthPoint;
        }

        // **************************************************************************************
        // Method to cool down time  and return cool down time after update
        // **************************************************************************************
        public int UpdateCoolDown(int updateByValue)
        {
            CoolDownTime += updateByValue;
            return CoolDownTime;
        }
    }
}
