public class FirerateUP : ItemScript
{
    public override string GetName { get { return "+Скорострельность"; } }

    public override string GetDescription { get { return "+20% скорострельности"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.speed.AddModifier(0.2f);
    }
}
