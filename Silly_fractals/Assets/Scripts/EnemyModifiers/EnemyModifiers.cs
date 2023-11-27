using System.Collections.Generic;

public static class EnemyModifiers
{
    public delegate string AddModifier(bool get_description);
    public static List<AddModifier> listOfModifiers = new List<AddModifier> { 
    SpeedModifier, 
    DamageBase, 
    SpeedBase,
    Multishot,
    FireRate,
    MaxHealth,
    LookDistance,
    ShootDistance,
    BulletSpeed,
    Rico,
    BulletPenetr
    };

    public static string SpeedModifier(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.speed.AddModifier(0.1f));
        return "Скорость врагов увеличена на 10%";
    }

    public static string DamageBase(bool get_description)
    {
        if (!get_description)
        {
            foreach (var stat in EnemiesManager.instance.listOfStats)
            {
                stat.damage.AddBaseValue(1);
                stat.speed.AddModifier(-0.1f);
            }
        }
        return "Урон врагов увеличен на 1, скорость -10%";
    }

    public static string SpeedBase(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.speed.AddBaseValue(0.5f));
        return "Базовая скорость врагов увеличена на 0.5";
    }

    public static string Multishot(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.multyshot++);
        return "Мультивыстрел врагов +1";
    }

    public static string FireRate(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.fire_rate.AddBaseValue(0.1f));
        return "Скоростельность врагов увеличена на 10%";
    }

    public static string MaxHealth(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.max_health.AddModifier(0.1f));
        return "Здоровье врагов увеличено на 10%";
    }

    public static string LookDistance(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.lookRadius.AddBaseValue(0.07f));
        return "Радиус зрения врагов увеличен на 7%";
    }

    public static string ShootDistance(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.shootDistance.AddBaseValue(0.07f));
        return "Дальность атаки врагов увеличена на 7%";
    }

    public static string BulletSpeed(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.bulletSpeed.AddBaseValue(0.10f));
        return "Скорость пуль врагов увеличена на 10%";
    }

    public static string Rico(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.rico++);
        return "Рикошет пуль врагов +1";
    }

    public static string BulletPenetr(bool get_description)
    {
        if (!get_description)
            EnemiesManager.instance.listOfStats.ForEach(x => x.bulletPenetration++);
        return "Пули врагов пробивают насквозь на 1 раз больше";
    }
}





