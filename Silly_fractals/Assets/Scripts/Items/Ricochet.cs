public class Ricochet : ItemScript
{
    public override string GetName { get { return "�������"; } }

    public override string GetDescription { get { return "+1 �������"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.ricochet++;
    }
}
