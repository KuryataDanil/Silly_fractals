using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnEnable()
    {
        StartCoroutine(TriggerDialogue());
    }

    IEnumerator TriggerDialogue()
    {
        DialogueManager manager = FindObjectOfType<DialogueManager>();
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);


        RectTransform rectTransform = manager.GetComponent<RectTransform>();
        Vector3 destination = screenPoint + new Vector2(0, (Camera.main.pixelHeight / 4f));

       
        while (Vector2.Distance(rectTransform.position, destination) > 10)
        {
            rectTransform.position +=  (destination - rectTransform.position).normalized * 4;
            yield return null;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, true);
    }

    
}
