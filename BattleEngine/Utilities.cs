using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BattleEngine
{
    //**********************************************************
    // Utilities
    //**********************************************************
    class Utilities
    {
        static public Random Random = new Random();
        //**********************************************************
        // Method to load List of Cards From Json File
        //**********************************************************
        static public void SetRadomSeed(int seed)
        {
            Random = new Random(seed);
        }

        //**********************************************************
        // Method to load List of Cards From Json File
        //**********************************************************
        static public List<Card> LoadJCardsFromFile(String jsonfilename)
        { 
            using (StreamReader file = File.OpenText(jsonfilename))
            {
                string jsonString = file.ReadToEnd();
                List<Card> cards = JsonConvert.DeserializeObject<List<Card>>(jsonString);
                return cards;
            }
        }
    }
}
