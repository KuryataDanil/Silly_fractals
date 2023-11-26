public class BulletPenetration : ItemScript
{
    public override string GetName { get { return "Пули навылет"; } }

    public override string GetDescription { get { return "Пуля пролетает врага насквозь"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.bulletPenetration++;
    }
}
