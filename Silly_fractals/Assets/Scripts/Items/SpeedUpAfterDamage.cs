public class SpeedUpAfterDamage : ItemScript
{
    public override string GetName { get { return "���������"; } }

    public override string GetDescription { get { return "��������� ����� ��������� �����"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.speedUpAfterDamage += 0.5f;
    }
}
