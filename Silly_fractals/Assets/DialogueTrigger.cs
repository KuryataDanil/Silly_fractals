using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Update()
    {
        if (Vector2.Distance((Vector2)PlayerManager.instance.player.transform.position, (Vector2)transform.position) < 3)
        {
            StartCoroutine(TriggerDialogue());
            this.enabled = false;
        }
    }

    IEnumerator TriggerDialogue()
    {
        DialogueManager manager = FindObjectOfType<DialogueManager>();
        while (manager.transform.position.y > 250)
        {
            manager.transform.position -= new Vector3(0, 4, 0);
            yield return null;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
