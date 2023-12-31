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

    public bool IsEndless;

    public List<GameObject> items;

    public GameObject trader;

    public GameObject spawner;

    public Hatch[] hatches;

    public GameObject TraderEnd;

    private List<EnemyModifiers.AddModifier> listOfModifiers;

    private List<GameObject> objectsOnScene;

    private int depth = 1;
    public int Depth { get { return depth; } }
    public void IncDepth() { depth++; }

    private void Start()
    {
        listOfModifiers = EnemyModifiers.listOfModifiers;
        objectsOnScene = new List<GameObject>();
    }

    public void CheckEnemiesAreDead()
    {
        if (listOfEnemies.TrueForAll(x => !x.activeSelf))
        {
            if (Depth == 9 && !IsEndless)
            {
                EndOfGame();
                return;
            }
            trader.SetActive(true);
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        int r = Random.Range(0, items.Count);
        GameObject item = Instantiate(items[r], new Vector3(0, -5, 0), Quaternion.identity);
    }

    public void OpenHatches()
    {
        Debug.Log("OPEN");
        int rand = Random.Range(0, 100);
        int cntOfMods = 1;

        if (rand == 0)
            cntOfMods = 3;
        else if (rand <= 9)
            cntOfMods = 2;

        foreach (Hatch hatch in hatches)
        {
            for (int i = 0; i < cntOfMods; i++)
            {
                int mod_ind = Random.Range(0, listOfModifiers.Count);
                hatch.AddModifier(listOfModifiers[mod_ind]);
            }
            hatch.OpenHatch();
        }
    }

    public void CloseHatches()
    {
        trader.SetActive(false);
        foreach (Hatch hatch in hatches)
        {
            hatch.CloseHatch();
        }
    }

    public void HatchesTextOff()
    {
        foreach (Hatch hatch in hatches)
        {
            hatch.TextOff();
        }
    }

    public void AddActiveObj(GameObject gameObject)
    {
        objectsOnScene.Add(gameObject);
    }

    public void RemoveActiveObj(GameObject gameObject)
    {
        objectsOnScene.Remove(gameObject);
    }

    public void DestroyActiveObjs()
    {
        foreach (GameObject obj in objectsOnScene)
        {
            Debug.Log(obj);
            Destroy(obj);
            objectsOnScene = new List<GameObject>();
        }
    }

    private void EndOfGame()
    {
        TraderEnd.SetActive(true);
    }
}
