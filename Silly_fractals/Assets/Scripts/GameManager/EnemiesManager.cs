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

    public List<GameObject> listOfEnemies;
}
