public class Ricochet : ItemScript
{
    public override string GetName { get { return "Рикошет"; } }

    public override string GetDescription { get { return "+1 рикошет"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.ricochet++;
    }
}
