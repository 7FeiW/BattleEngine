using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleEngine
{
    class BattleEngine
    {
        private List<SkillDisplayRule> mDisplayRules;
        static private int S_MAX_STEPS = 100;

        public BattleEngine()
        {
            mDisplayRules = new List<SkillDisplayRule>();
        }

        public void Battle(Hand HandOne, Hand HandTwo)
        {
            int actionCount = 0;
            while(actionCount < S_MAX_STEPS)
            {
                
                var handOneActableCards = HandOne.GetCurrentActableCards();
                var handTwoActableCards = HandTwo.GetCurrentActableCards();

                int numOfActableCardsHandOne = handOneActableCards.Count;
                int numOfActableCardsHandTwo = handTwoActableCards.Count;
                
                if (numOfActableCardsHandOne + numOfActableCardsHandTwo == 0)
                {
                    HandOne.UpdateCoolDown(-1);
                    HandTwo.UpdateCoolDown(-1);
                    continue;
                }

                // count Only update when there is action taken
                actionCount += 1;
                Console.WriteLine("Round: " + actionCount.ToString());
                // Radom Suffled index for action Order
                var actionOrder = Enumerable.Range(0, numOfActableCardsHandOne + numOfActableCardsHandTwo).OrderBy(x => Guid.NewGuid()).ToList();

                // let us play
                var actablecards = handOneActableCards.Concat(handTwoActableCards).ToList();
                foreach (var idx in actionOrder)
                {
                    var currentAction = actablecards[idx].GetCurrentAction();
                    var attackPoint = currentAction.AttackPoint;
                    var displayString = currentAction.DisplayString;
                    var attackerName = actablecards[idx].Name;
                    var attackerHealthPoint = actablecards[idx].HealthPoint;
                    DamageReport damageReport;

                    if (idx < numOfActableCardsHandOne)
                    {
                        damageReport = HandOne.UnderAttack(attackPoint);
                    }
                    else
                    {
                        damageReport = HandTwo.UnderAttack(attackPoint);
                    }

                    var victimName = damageReport.VictimName;
                    var victimHealthPoint = damageReport.VictimHealthPoint;
                    Console.WriteLine(attackerName + " (HP: " + attackerHealthPoint.ToString() + ") " + displayString + " (Attack Point: " + attackPoint.ToString() + ") " + victimName + " (Remaining HP: " + victimHealthPoint.ToString() + ")");
                }

                if (HandOne.AllDead() || HandTwo.AllDead())
                {
                    Console.WriteLine("GameOver: HandOne --" + HandOne.AllDead().ToString() + " HandTwo --" + HandTwo.AllDead().ToString());
                    break;
                }
                HandOne.UpdateCoolDown();
                HandTwo.UpdateCoolDown();
            }
        }
    }
}
