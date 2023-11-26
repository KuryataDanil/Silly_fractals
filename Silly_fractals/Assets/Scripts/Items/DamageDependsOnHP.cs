public class DamageDependsOnHP : ItemScript
{
    public override string GetName { get { return "Риск"; } }

    public override string GetDescription { get { return "Меньше здоровья - больше урона"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.damageDependsOnHp += 0.5f;
    }
}
