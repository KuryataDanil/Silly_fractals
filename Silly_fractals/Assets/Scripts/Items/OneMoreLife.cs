public class OneMoreLife : ItemScript
{
    public override string GetName { get { return "+1 одна жизнь"; } }

    public override string GetDescription { get { return "Вместо смерти вы возрождаетесь с одним контейнером здоровья"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.lifes++;
    }
}
