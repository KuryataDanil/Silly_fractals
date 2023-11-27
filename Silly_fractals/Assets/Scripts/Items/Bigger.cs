using System.Threading.Tasks;
using UnityEngine;

public class Bigger : ItemScript
{
    public override string GetName { get { return "����������"; } }

    public override string GetDescription { get { return "�� ��������������   +30% �����   -30% ��������"; } }

    public override void UpdateStats(PlayerStats stats)
    {
        stats.damage.AddModifier(0.3f);
        stats.speed.AddModifier(-0.3f);
        ChangeSize(stats.transform);
    }

    private async void ChangeSize(Transform target)
    {
        float Timer = 0;
        Vector3 Base = PlayerManager.instance.player.transform.localScale;
        while (Timer < 1)
        {
            PlayerManager.instance.player.transform.localScale = Vector3.Lerp(Base, Base * 1.1f, Timer);
            Timer += Time.deltaTime;
            await Task.Yield();
        }
    }
}
