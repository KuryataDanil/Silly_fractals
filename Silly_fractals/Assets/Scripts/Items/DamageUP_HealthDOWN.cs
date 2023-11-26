public class DamageUP_HealthDOWN : ItemScript
{
    public override string GetName { get { return "+���� -�������"; } }

    public override string GetDescription { get { return "+50% �����   -1 ��������� ��������"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.damage.AddModifier(0.5f);
        stats.max_health -= 2;
        if (stats.Health > stats.max_health)
            stats.Heal(stats.Health - stats.max_health);
    }
}
