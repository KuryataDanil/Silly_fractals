using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    float _timer = 5;

    private void Update()
    {
        if (Vector2.Distance((Vector2)PlayerManager.instance.player.transform.position, (Vector2)transform.position) < 3 || _timer < 0)
        {
            StartCoroutine(TriggerDialogue());
            this.enabled = false;
        }
        _timer -= Time.deltaTime;
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
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, false);
    }
}
