using System.Collections.Generic;

public static class EnemyModifiers
{
    public delegate string AddModifier(bool get_description);
    public static List<AddModifier> listOfModifiers = new List<AddModifier> { 
        SpeedModifier, 
        DamageBase, 
        SpeedBase };

    public static string SpeedModifier(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.speed.AddModifier(0.2f));
        return "Скорость врагов увеличена на 20%";
    }

    public static string DamageBase(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.damage.AddBaseValue(1));
        return "Урон врагов увеличен на 1";
    }

    public static string SpeedBase(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.speed.AddBaseValue(1f));
        return "Базовая скорость врагов увеличена на 1";
    }
}





