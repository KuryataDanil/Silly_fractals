public class SpeedUpAfterDamage : ItemScript
{
    public override string GetName { get { return "Адреналин"; } }

    public override string GetDescription { get { return "Ускорение после получения урона"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.speedUpAfterDamage += 0.5f;
    }
}
