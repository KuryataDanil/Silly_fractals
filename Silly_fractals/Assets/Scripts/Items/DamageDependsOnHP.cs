public class DamageDependsOnHP : ItemScript
{
    public override string GetName { get { return "����"; } }

    public override string GetDescription { get { return "������ �������� - ������ �����"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.damageDependsOnHp += 0.5f;
    }
}
