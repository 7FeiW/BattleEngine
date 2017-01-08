namespace BattleEngine
{
    // **************************************************************************************
    // Action Class
    // **************************************************************************************
    class Action
    {
        public Action(string displayString, int attackPoint)
        {
            DisplayString = displayString;
            AttackPoint = attackPoint;
        }
        public string DisplayString { get; }
        public int AttackPoint { get; }
    }
}
