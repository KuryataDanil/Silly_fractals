public class BulletSpeedUP : ItemScript
{
    public override string GetName { get { return "+Скорость снаряда"; } }

    public override string GetDescription { get { return "+30% к скорости снаряда"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.bulletSpeed.AddModifier(0.3f);
    }
}
