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
    class Card : ICloneable<Card>
    {
        [JsonProperty("Id")]
        public string Id { get; private set; }
        [JsonProperty("Name")]
        public string Name { get; private set; } = "";
        [JsonProperty("HealthPoints")]
        public int HealthPoints { get; private set; }

        [JsonIgnore]
        public bool IsAlive { get; private set; } = true;
        [JsonIgnore]
        public int CoolDownTime { get; private set; } = 0;

        [JsonProperty("Skills")]
        private List<Skill> mSkills = new List<Skill>();

        [JsonIgnore]
        private Skill mCurrentSkill = null;
        [JsonIgnore]
        private int mSumOfWeights = 0;

        //******************************
        private Skill takeAction()
        {
            int randomInt = Utilities.Random.Next(0, mSumOfWeights);
            mCurrentSkill = mSkills.OrderBy(s => s.Weight).ToList().Where(s => s.Weight > randomInt).FirstOrDefault();
            return mCurrentSkill;
        }

        // **************************************************************************************
        // Method to Get Current  Action
        // **************************************************************************************
        public Action GetCurrentAction()
        {
            takeAction();
            CoolDownTime = mCurrentSkill.CoolDownInterval;
            var action = new Action(mCurrentSkill.GetDisplayText(), mCurrentSkill.AttackPoints);
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
        public Card Clone()
        {
            //Creates a shallow copy of the current 
            Card clone = (Card)this.MemberwiseClone();
            //Deep copy 
            handleDeepCopy(clone);
            return clone;
        }

        private void handleDeepCopy(Card clone)
        {
            clone.mSkills = mSkills.Select(skill => skill.Clone()).ToList();
        }

        //***************************************************************************************
        // OnDeserialized
        // Update skill weight after deserialized
        //***************************************************************************************
        [OnDeserialized]
        internal void OnDeserializedHandler(StreamingContext context)
        {
            //just be safe
            mSumOfWeights = 0;
            foreach (var skill in mSkills)
            {
                mSumOfWeights += skill.Weight;
                skill.Weight = mSumOfWeights;
            }
        }
    }
}
