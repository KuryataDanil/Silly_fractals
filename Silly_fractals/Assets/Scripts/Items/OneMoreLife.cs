public class OneMoreLife : ItemScript
{
    public override string GetName { get { return "+1 ���� �����"; } }

    public override string GetDescription { get { return "������ ������ �� ������������� � ����� ����������� ��������"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.lifes++;
    }
}
