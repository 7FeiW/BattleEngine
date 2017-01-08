namespace BattleEngine
{
    class DamageReport
    {
        public DamageReport(string victimName, int victimHealthPoint)
        {
            VictimName = victimName;
            VictimHealthPoint = victimHealthPoint;
        }
        public string VictimName { get; }
        public int VictimHealthPoint { get; }
    }
}
