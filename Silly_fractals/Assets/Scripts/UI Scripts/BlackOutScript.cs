using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Blackout());
    }
    

    IEnumerator Blackout()
    {
        UnityEngine.UI.Image sprite_rend = GetComponent<UnityEngine.UI.Image>();
        Color tempColor = sprite_rend.color;

        while (tempColor.a > 0f)
        {
            yield return new WaitForEndOfFrame();
            tempColor.a = tempColor.a - 0.01f;
            sprite_rend.color = tempColor;
        }
    }

}
