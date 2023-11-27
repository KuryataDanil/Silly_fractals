public class DamageUP_FrDOWN : ItemScript
{
    public override string GetName { get { return "+Урон -Скорострельность"; } }

    public override string GetDescription { get { return "+50% урона   -20% скорострельности"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.damage.AddModifier(0.5f);
        stats.speed.AddModifier(-0.2f);
    }
}
