using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject blackOut;

    public void SwitchScene(string sceneName)
    {
        blackOut.SetActive(true);
        StartCoroutine(Blackout(sceneName));
    }

    IEnumerator Blackout(string sceneName)
    {
        UnityEngine.UI.Image sprite_rend = blackOut.GetComponent<UnityEngine.UI.Image>();
        Color tempColor = sprite_rend.color;

        while (tempColor.a < 1f)
        {
            yield return new WaitForEndOfFrame();
            tempColor.a = tempColor.a + 0.01f;
            sprite_rend.color = tempColor;
        }

        SceneManager.LoadScene(sceneName);
    }

}
