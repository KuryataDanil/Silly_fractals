public class HpLuckUP : ItemScript
{
    public override string GetName { get { return "������ �������� � ������!"; } }

    public override string GetDescription { get { return "+10% ���� ��������� �������� � ������"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.heartLuck += 10;
    }
}
