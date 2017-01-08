namespace BattleEngine
{
    // **************************************************************************************
    // SkillDisplayRule Class
    // **************************************************************************************
    class SkillDisplayRule
    {
        public SkillDisplayRule(string text, int weight)
        {
            Text = text;
            Weight = weight;
        }
        public string Text { get; }
        public int Weight { get; }
    }
}
