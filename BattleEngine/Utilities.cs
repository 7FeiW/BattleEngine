using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace BattleEngine
{
    //**********************************************************
    // Utilities
    //**********************************************************
    class Utilities
    {
        //**********************************************************
        // Method to load JArray From Json File
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
