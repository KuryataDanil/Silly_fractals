public class BulletSpeedUP : ItemScript
{
    public override string GetName { get { return "+�������� �������"; } }

    public override string GetDescription { get { return "+30% � �������� �������"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.bulletSpeed.AddModifier(0.3f);
    }
}
