public class HpLuckUP : ItemScript
{
    public override string GetName { get { return "Больше здоровья с врагов!"; } }

    public override string GetDescription { get { return "+10% шанс выпадения здоровья с врагов"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.heartLuck += 10;
    }
}
