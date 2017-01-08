using System;   
using System.Collections.Generic;
using System.Linq;

namespace BattleEngine
{
    class Hand
    {
        public Hand()
        {
            mCards = new List<Card>();
        }

        private List<Card> mCards;

        // **************************************************************************************
        // Method to Add Card into Current Hand
        // **************************************************************************************
        public void AddCard(Card card)
        {
            mCards.Add(card);
        }

        // **************************************************************************************
        // Return Bool value to indicate if all cards are dead
        // **************************************************************************************
        public bool AllDead()
        {
            var numOfAlive = mCards.Count(x => x.IsAlive == true);
            return numOfAlive == 0;
        }

        // **************************************************************************************
        // Update Cool Down Time on each Card
        // This should only be called to update cool down on each round
        // **************************************************************************************
        public void UpdateCoolDown(int updateValue = -1)
        {
            foreach (var card in mCards)
            {
                card.UpdateCoolDown(updateValue);
            }
        }

        // **************************************************************************************
        // return a list of cards , where health is none zero and cool down time is zero
        // **************************************************************************************
        public List<Card> GetCurrentActableCards()
        {
            return mCards.FindAll(x => x.IsAlive == true && x.CoolDownTime == 0).ToList();
        }

        //***************************************************************************************
        // method to pick a victim, take damange and retrun damange Report
        //***************************************************************************************
        public DamageReport UnderAttack(int attackPoint)
        {
            // victim is the random pick from remaining alive cards
            var victim = mCards.FindAll(x => x.IsAlive == true).OrderBy(x => Guid.NewGuid()).First();
            // Now victim is under attack
            victim.UpdateHealthPoint(-attackPoint);
            var damageReport = new DamageReport(victim.Name, victim.HealthPoint);
            return damageReport;
        }
    }
}
