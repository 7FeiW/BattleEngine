using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var battleEngine = new BattleEngine();
            var handOne = CreateHand("HandOne");
            var handTwo = CreateHand("HandTwo");

            battleEngine.Battle(handOne, handTwo);

            Console.ReadKey();

        }

        static Hand CreateHand(string name)
        {
            var random = new Random();
            var hand = new Hand();
            foreach(int index in Enumerable.Range(1,5))
            {
                var card = new Card(name + "_card_" + index.ToString(), random.Next(100, 200));
                var skill = new Skill("skill_1_"+ random.Next(index, 10).ToString(), random.Next(10, 40), random.Next(10, 30), random.Next(1, 10));
                skill.AddSkillDisplayRules(skill.SkillDisplayName + " Heavy_Kick_Normal", random.Next(7,16));
                skill.AddSkillDisplayRules(skill.SkillDisplayName + " Heavy_Kick_Rare", random.Next(5,9));
                card.AddSkill(skill);

                var skillTwo = new Skill("skill_2_" + random.Next(index, 10).ToString(), random.Next(10, 40), random.Next(10, 30), random.Next(5, 10));
                skillTwo.AddSkillDisplayRules(skillTwo.SkillDisplayName + " light_attack_Normal", random.Next(5, 7));
                skillTwo.AddSkillDisplayRules(skillTwo.SkillDisplayName + " Booom_Rare", random.Next(4, 5));
                card.AddSkill(skillTwo);
                hand.AddCard(card);
            }
            return hand;
        }
    }
}
