public class DamageUP : ItemScript
{
    public override string GetName { get { return "+����"; } }

    public override string GetDescription { get { return "+30% �����"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.damage.AddModifier(0.3f);
    }
}
