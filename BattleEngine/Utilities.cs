using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace BattleEngine
{
    //**********************************************************
    // Utilities
    //**********************************************************
    class Utilities
    {
        //**********************************************************
        // Method to load display rules from jsonfile
        //**********************************************************
        static public void LoadDisplayRules(String jsonfilename)
        {
            using (StreamReader file = File.OpenText(jsonfilename))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JArray jArray = (JArray)JToken.ReadFrom(reader);
            }
        }
    }
}
