public class DashUP : ItemScript
{
    public override string GetName { get { return "Рывок"; } }

    public override string GetDescription { get { return "Нажмите shift, больше предметов - меньше перезарядка"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.dashCooldown -= 1;
        PlayerManager.instance.player.GetComponent<PlayerDash>().enabled = true;
    }
}
