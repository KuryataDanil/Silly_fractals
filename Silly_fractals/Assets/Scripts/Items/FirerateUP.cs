public class FirerateUP : ItemScript
{
    public override string GetName { get { return "+����������������"; } }

    public override string GetDescription { get { return "+20% ����������������"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.speed.AddModifier(0.2f);
    }
}
