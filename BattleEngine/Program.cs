using System;

namespace BattleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var Cards = Utilities.LoadJCardsFromFile(@"CardsMetaData.json");
            Utilities.SetRadomSeed((int)DateTime.Now.Ticks & 0x0000FFFF);
            var battleEngine = new BattleEngine();
            var handOne = new Hand();
            var handTwo = new Hand();

            handOne.AddCard(Cards[0].Clone());
            handOne.AddCard(Cards[0].Clone());
            handOne.AddCard(Cards[0].Clone());
            handOne.AddCard(Cards[0].Clone());
            handOne.AddCard(Cards[0].Clone());
            handTwo.AddCard(Cards[1].Clone());
            handTwo.AddCard(Cards[1].Clone());
            handTwo.AddCard(Cards[1].Clone());
            handTwo.AddCard(Cards[1].Clone());
            handTwo.AddCard(Cards[1].Clone());

            battleEngine.Battle(handOne, handTwo);
            Console.ReadKey();

        }
    }
}
