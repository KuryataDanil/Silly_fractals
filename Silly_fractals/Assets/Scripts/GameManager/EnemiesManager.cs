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

}
