using System.Collections.Generic;

public static class EnemyModifiers
{
    public delegate string AddModifier();
    public static List<AddModifier> listOfModifiers = new List<AddModifier> { 
        SpeedModifier, 
        DamageBase, 
        SpeedBase };

    public static string SpeedModifier()
    {
        EnemiesManager.instance.listOfStats.ForEach(x => x.speed.AddModifier(0.2f));
        return "Скорость врагов увеличена на 20%";
    }

    public static string DamageBase()
    {
        EnemiesManager.instance.listOfStats.ForEach(x => x.damage.AddBaseValue(1));
        return "Урон врагов увеличен на 1";
    }

    public static string SpeedBase()
    {
        EnemiesManager.instance.listOfStats.ForEach(x => x.speed.AddBaseValue(1f));
        return "Базовая скорость врагов увеличена на 1";
    }
}





