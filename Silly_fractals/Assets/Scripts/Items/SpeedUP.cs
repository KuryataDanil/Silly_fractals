public class SpeedUP : ItemScript
{
    public override string GetName { get { return "��������"; } }

    public override string GetDescription { get { return "+30% � ��������"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.speed.AddModifier(0.15f);
    }
}