using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthOfLevelText : MonoBehaviour
{
    private void OnEnable()
    {
        Hatch.OnLevelChanged += DrawLevelDepth;
    }

    private void OnDisable()
    {
        Hatch.OnLevelChanged -= DrawLevelDepth;
    }

    private void DrawLevelDepth()
    {
        GetComponent<Text>().text = EnemiesManager.instance.Depth.ToString(); ;
    }
}