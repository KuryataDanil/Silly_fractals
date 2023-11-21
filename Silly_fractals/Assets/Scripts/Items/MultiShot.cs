public class MultiShot : ItemScript
{
    public override string GetName { get { return "Мультивыстрел"; } }

    public override string GetDescription { get { return "+1 мультивыстрел"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.multyshot++;
    }
}