public class MoneyLuckUP : ItemScript
{
    public override string GetName { get { return "Ѕольше монет с врагов!"; } }

    public override string GetDescription { get { return "+10% шанс выпадени€ монет с врагов"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.moneyLuck += 10;
    }
}
