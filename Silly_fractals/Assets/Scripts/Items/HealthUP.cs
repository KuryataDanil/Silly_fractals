public class HealthUP : ItemScript
{
    public override string GetName { get { return "+Макс. здоровье"; } }

    public override string GetDescription { get { return "+1 контейнер здоровья"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.max_health += 2;
        stats.Heal(2);
    }
}