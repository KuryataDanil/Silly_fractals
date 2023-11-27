public class HP1 : ItemScript
{
    public override string GetName { get { return "++Урон 1 но..."; } }

    public override string GetDescription { get { return "+100% урона   но остается 1 контейнер здоровья"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.damage.AddModifier(1f);
        stats.max_health = 2;
        if (stats.Health > stats.max_health - 1)
            stats.Heal(stats.max_health - stats.Health - 1);

    }
}
