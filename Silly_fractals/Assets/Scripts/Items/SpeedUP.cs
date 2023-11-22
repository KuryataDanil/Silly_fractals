public class SpeedUP : ItemScript
{
    public override string GetName { get { return "Скорость"; } }

    public override string GetDescription { get { return "+30% к скорости"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.speed.AddModifier(0.15f);
    }
}