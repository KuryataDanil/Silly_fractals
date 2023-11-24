using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField]
    Sprite fullheart, halfheart, emptyheart;
    Image heartImg;

    private void Awake()
    {
        heartImg = GetComponent<Image>();
    }

    public void SetImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                heartImg.sprite = emptyheart;
                break;
            case HeartStatus.Half:
                heartImg.sprite = halfheart;
                break;
            case HeartStatus.Full:
                heartImg.sprite = fullheart;
                break;
        }
    }

}

public enum HeartStatus
{ 
    Empty = 0,
    Half,
    Full
}
