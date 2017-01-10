using System;
using System.Linq;

namespace BattleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var battleEngine = new BattleEngine();
            var handOne = CreateHand("HandOne");
            var handTwo = CreateHand("HandTwo");

            battleEngine.Battle(handOne, handTwo);*/

            var Cards = Utilities.LoadJCardsFromFile(@"CardsMetaData.json");
            Console.ReadKey();

        }
    }
}
