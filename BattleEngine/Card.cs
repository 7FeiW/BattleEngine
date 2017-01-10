using System.Collections.Generic;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace BattleEngine
{
    // **************************************************************************************
    // Card Class
    // **************************************************************************************
    class Card : ICloneable
    {
        /*public Card(string name, int healthPoint)
        {
            Name = name;
            HealthPoints = healthPoint;
        }*/

        [JsonProperty("Name")]
        public string Name { get; protected set; } = "";
        [JsonProperty("HealthPoints")]
        public int HealthPoints { get; protected set; }

        [JsonIgnore]
        public bool IsAlive { get; private set; } = true;
        [JsonIgnore]
        public int CoolDownTime { get; private set; } = 0;

        [JsonProperty("Skills")]
        private List<Skill> mSkills = new List<Skill>();

        [JsonIgnore]
        private int mCurrentSkillIndex = -1;
        [JsonIgnore]
        private int mSumOfWeights = 0;

        //******************************
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
            var action = new Action(mSkills[mCurrentSkillIndex].GetDisplayText(), mSkills[mCurrentSkillIndex].AttackPoints);
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
            HealthPoints += updateByValue;
            IsAlive = HealthPoints > 0;
            return HealthPoints;
        }

        // **************************************************************************************
        // Method to cool down time  and return cool down time after update
        // **************************************************************************************
        public int UpdateCoolDown(int updateByValue)
        {
            CoolDownTime += updateByValue;
            return CoolDownTime;
        }


        // **************************************************************************************
        // Methods to handle clone
        // **************************************************************************************
        public object Clone()
        {
            var clone = this.MemberwiseClone();
            //handleCloned(clone);
            return clone;
        }

        private void handleCloned(Card clone)
        {

        }


        //***************************************************************************************
        // OnDeserialized
        // Update skill weight after deserialized
        //***************************************************************************************
        [OnDeserialized]
        internal void OnDeserializedHandler(StreamingContext context)
        {
            foreach(var skill in mSkills)
            {
                mSumOfWeights += skill.Weight;
                skill.Weight = mSumOfWeights;
            }
        }
    }
}
