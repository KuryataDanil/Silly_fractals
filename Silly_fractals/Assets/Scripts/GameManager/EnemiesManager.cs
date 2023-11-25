using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    #region Singleton

    public static EnemiesManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [HideInInspector]
    public List<GameObject> listOfEnemies;

    [HideInInspector]
    public List<EnemyStats> listOfStats;

    public GameObject spawner;

    public Hatch[] hatches;

    private List<EnemyModifiers.AddModifier> listOfModifiers;

    private void Start()
    {
        listOfModifiers = EnemyModifiers.listOfModifiers;
    }

    public void CheckEnemiesAreDead()
    {
        if (listOfEnemies.TrueForAll(x => !x.activeSelf))
        {
            OpenHatches();
        }
    }

    public void OpenHatches()
    {
        foreach (Hatch hatch in hatches)
        {
            hatch.OpenHatch();
        }
    }
}
